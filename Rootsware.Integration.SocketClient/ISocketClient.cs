using Rootsware.Libraries.SocketCL.Constants;
using Rootsware.Libraries.SocketCL.Models;

namespace Rootsware.Integration.SocketClient;

public interface ISocketClient
{
    Task SendAsync(Message message, char socketueName, byte sbit = Bit.PLH);

    Task<MessageContainer?> GetAsync(Message message, char socketueName, byte sbit = Bit.GMS);

    Task<IEnumerable<MessageContainer>?> GetManyAsync(Message message, char socketueName, byte sbit = Bit.GMM);

    Task DisconectAsync(bool reuse, CancellationToken cancellationToken = default);

    void Shutdown();

    void Close();
    void Connect(short port);

    /// <summary>
    ///     Disconnects
    ///     the
    ///     client
    ///     and
    ///     closes
    ///     the
    ///     connection
    ///     releasing
    ///     all
    ///     resources
    ///     allocated
    ///     to
    ///     the
    ///     connection.
    /// </summary>
    /// <param
    ///     name="cancellationToken">
    /// </param>
    /// <returns></returns>
    Task ReleaseAsync(CancellationToken cancellationToken = default);
}