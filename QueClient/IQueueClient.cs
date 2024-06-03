using QueComLib.Constants;
using QueComLib.Models;

namespace QueClient
{
    public interface IQueueClient
    {
        ValueTask SendAsync(Message message, char queueName, byte sbit = Bit.PLH);

        ValueTask<MessageContainer?> GetAsync(Message message, char queueName, byte sbit = Bit.GMS);

        ValueTask<IEnumerable<MessageContainer>?> GetManyAsync(Message message, char queueName, byte sbit = Bit.GMM);

        ValueTask DisconectAsync(bool reuse, CancellationToken cancellationToken = default);

        void Shutdown();

        void Close();
        void Connect(short port);

        /// <summary>
        /// Disconnects the client and closes the connection releasing all resources allocated to the connection.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask ReleaseAsync(CancellationToken cancellationToken = default);
    }
}