using Rootsware.Integration.SocketClient.Exceptions;
using Rootsware.Libraries.SocketCL.Constants;
using Rootsware.Libraries.SocketCL.Models;

namespace Rootsware.Integration.SocketClient.Services;

public class SocketClient : ISocketClient
{
    private IClientInitProxy? _client;

    public void Close()
    {
        if (_client is null) throw new ClientNotConnectedException();
        _client.Close();
    }

    public void Connect(short port)
    {
        _client ??= new ClientInitProxy(port);
        // => _client ??= new ClientInitProxy(port);
    }

    public async ValueTask DisconectAsync(bool reuse, CancellationToken cancellationToken = default)
    {
        if (_client is null) throw new ClientNotConnectedException();
        await _client.DisconectAsync(reuse, cancellationToken);
    }

    public async ValueTask<MessageContainer?> GetAsync(Message message, char socketueName, byte sbit = Bit.GMS)
    {
        if (_client is null) throw new ClientNotConnectedException();
        return await _client.GetAsync(message, socketueName, sbit);
    }

    public async ValueTask<IEnumerable<MessageContainer>?> GetManyAsync(Message message, char socketueName, byte sbit = Bit.GMS)
    {
        if (_client is null) throw new ClientNotConnectedException();
        return await _client.GetManyAsync(message, socketueName, sbit);
    }

    public async ValueTask ReleaseAsync(CancellationToken cancellationToken = default)
    {
        if (_client is null) throw new ClientNotConnectedException();
        await _client.DisconectAsync(true, cancellationToken);
        //_client.Close();
    }

    public async ValueTask SendAsync(Message message, char socketueName, byte sbit = Bit.PLH)
    {
        if (_client is null) throw new ClientNotConnectedException();
        await _client.SendAsync(message, socketueName, sbit);
    }

    public void Shutdown()
    {
        if (_client is null) throw new ClientNotConnectedException();
        _client?.Shutdown();
    }
}