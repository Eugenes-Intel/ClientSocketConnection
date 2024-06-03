

using SocketCL.Constants;
using SocketCL.Models;

namespace SocketClient
{
    public interface ISocketClient
    {
        ValueTask SendAsync(Message message, char socketueName, byte sbit = Bit.PLH);

        ValueTask<MessageContainer?> GetAsync(Message message, char socketueName, byte sbit = Bit.GMS);

        ValueTask<IEnumerable<MessageContainer>?> GetManyAsync(Message message, char socketueName, byte sbit = Bit.GMM);

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