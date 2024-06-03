using QueClient.Exceptions;
using QueComLib.Constants;
using QueComLib.Models;

namespace QueClient.Services
{
    public class QueueClient : IQueueClient
    {
        private IClientInitProxy? _client;

        public QueueClient() { }

        public void Close()
        {
            if (_client is null)
            {
                throw new ClientNotConnectedException();
            }
            _client.Close();
        }

        public void Connect(short port) => _client = new ClientInitProxy(port);// => _client ??= new ClientInitProxy(port);

        public async ValueTask DisconectAsync(bool reuse, CancellationToken cancellationToken = default)
        {
            if (_client is null)
            {
                throw new ClientNotConnectedException();
            }
            await _client.DisconectAsync(reuse, cancellationToken);
        }

        public async ValueTask<MessageContainer?> GetAsync(Message message, char queueName, byte sbit = Bit.GMS)
        {
            if (_client is null)
            {
                throw new ClientNotConnectedException();
            }
            return await _client.GetAsync(message, queueName, sbit);
        }

        public async ValueTask<IEnumerable<MessageContainer>?> GetManyAsync(Message message, char queueName, byte sbit = Bit.GMS)
        {
            if (_client is null)
            {
                throw new ClientNotConnectedException();
            }
            return await _client.GetManyAsync(message, queueName, sbit);
        }

        public async ValueTask ReleaseAsync(CancellationToken cancellationToken = default)
        {
            if (_client is null)
            {
                throw new ClientNotConnectedException();
            }
            await _client.DisconectAsync(false, cancellationToken);
            _client.Close();
        }

        public async ValueTask SendAsync(Message message, char queueName, byte sbit = Bit.PLH)
        {
            if (_client is null)
            {
                throw new ClientNotConnectedException();
            }
            await _client.SendAsync(message, queueName, sbit);
        }

        public void Shutdown()
        {
            if (_client is null)
            {
                throw new ClientNotConnectedException();
            }
            _client?.Shutdown();
        }
    }
}