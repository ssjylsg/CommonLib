using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BanYuan.Framework.Bus
{
    public interface IBus<TMessage> : IDisposable
    {
        /// <summary>
        /// Publishes the specified message to the bus.
        /// </summary>
        /// <param name="message">The message to be published.</param>
        void Publish(TMessage message);
        /// <summary>
        /// Publishes a collection of messages to the bus.
        /// </summary>
        /// <param name="messages">The messages to be published.</param>
        void Publish(IEnumerable<TMessage> messages);
        /// <summary>
        /// Clears the published messages waiting for commit.
        /// </summary>
        void Clear();
    }
}
