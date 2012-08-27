using System;
using System.Diagnostics;
using Castle.DynamicProxy;
using log4net;
using log4net.Repository.Hierarchy;

namespace BanYuan.Framework
{
    public class ServiceInterceptor : Castle.DynamicProxy.IInterceptor
    {
        private static ILog _plog;
        private IExceptionSystem _exceptionSystem;
        private ILoggerFactory _loggerFactory;
        static ServiceInterceptor()
        {
            _plog = log4net.LogManager.GetLogger(typeof(ServiceInterceptor));
        }
        public ServiceInterceptor(ILoggerFactory fatory, IExceptionSystem es)
        {
            this._loggerFactory = fatory;
            this._exceptionSystem = es;
        }

        #region IInterceptor 成员
        public void Intercept(IInvocation invocation)
        {
            var watch = new Stopwatch();
            watch.Start();
            try
            {
                invocation.Proceed();
                //HACK:以下写法累赘且可能带来死循环问题 by houkun
                //object service = invocation.InvocationTarget;
                //invocation.ReturnValue = invocation.Method.Invoke(service, invocation.Arguments);
            }
            catch (Exception e)
            {
                this.LogError(e, invocation);
                throw e;
            }
            finally
            {
                watch.Stop();
                this.MeasurePerformance(watch.Elapsed, invocation);
            }
        }
        #endregion

        private void LogError(Exception e, IInvocation invocation)
        {
            var log = log4net.LogManager.GetLogger(invocation.Method.DeclaringType);

            var format = "Method'{0}' in class'{1}' happened an error. Environment info:{2}";
            if (this._exceptionSystem.IsKnown(e))
                log.Info(string.Format(format
                    , invocation.Method.Name
                    , invocation.Method.DeclaringType
                    , this.GeneratEenvironmentInfo())
                    , e);
            else
                log.Error(string.Format(format
                    , invocation.Method.Name
                    , invocation.Method.DeclaringType
                    , this.GeneratEenvironmentInfo())
                    , e);
        }
        private void MeasurePerformance(TimeSpan time, IInvocation invocation)
        {
            if (time >= new TimeSpan(0, 0, 0, 0, 500))
            {
                var arguments = string.Empty;
                foreach (object argument in invocation.Arguments)
                    arguments += argument ?? "Null" + "%____%";
                _plog.WarnFormat("耗时方法：class={0}|method={1}|time={2}ms|arguments={3}|请于近期查明并修正"
                    , invocation.Method.DeclaringType.FullName
                    , invocation.Method.Name
                    , time.TotalMilliseconds, arguments);
            }
        }
        private string GeneratEenvironmentInfo()
        {
            return string.Format("App={0}|MachineName={1}|"
                , SystemConfig.Settings.AppName
                , Environment.MachineName);
        }
    }
}
