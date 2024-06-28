using SocketCL.Constants;
using SocketCL.Models;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace SocketClient.Services
{
    internal class ClientInitProxy : IClientInitProxy
    {
        private readonly Socket _client;

        private readonly IPEndPoint _endPoint;

        private const ushort BUFFER_SIZE = 1024;
        public Socket Client => _client;

        private readonly short _port;

        internal ClientInitProxy(short port)
        {
            IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName(), AddressFamily.InterNetwork);

            _endPoint = new IPEndPoint(hostEntry.AddressList[0], port);

            //_client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //_client.Connect(_endPoint);

            _port = port;
        }

        public async ValueTask SendAsync(Message message, char socketueName, byte sbit = Bit.PLH)
        {
            var buffer = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(new MessagePackage { SBit = sbit, Channel = socketueName, Message = message }));

            var b = _client.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, (asyncResult) =>
            {
                var socket = asyncResult.AsyncState as Socket;

                _ = socket!.EndSend(asyncResult);

            }, _client);

            await Task.CompletedTask;
        }

        public async ValueTask<MessageContainer?> GetAsync(Message message, char socketueName, byte sbit = Bit.GMS)
        {
            //return GetTAsyncS<MessageContainer>(new MessagePackage { SBit = Bit.GMS, Channel = socketueName, Message = message });

            return await GetTAsyncS<MessageContainer>(new MessagePackage { SBit = sbit, Channel = socketueName, Message = message });
        }

        public async ValueTask<IEnumerable<MessageContainer>?> GetManyAsync(Message message, char socketueName, byte sbit = Bit.GMS)
        {
            return await GetTAsyncS<IEnumerable<MessageContainer>>(new MessagePackage { SBit = sbit, Channel = socketueName, Message = message });
        }

        public void Shutdown() => _client.Shutdown(SocketShutdown.Both);

        public void Close() => _client.Close();

        public ValueTask DisconectAsync(bool reuse, CancellationToken cancellationToken = default) => _client.DisconnectAsync(reuse, cancellationToken);

        public async ValueTask<T?> GetTAsync<T>(MessagePackage messagePackage)
        {
            T? t = default(T);

            var buffer = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(messagePackage));

            var b = _client.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, (asyncResult) =>
            {
                var socket = asyncResult.AsyncState as Socket;

                _ = socket!.EndSend(asyncResult);

                var receiveBuffer = new byte[BUFFER_SIZE * 32];

                var handler = socket!.BeginReceive(receiveBuffer, 0, receiveBuffer.Length, SocketFlags.None, (asyncResult) =>
                {
                    var socket = asyncResult.AsyncState as Socket;

                    var receiveSize = socket!.EndReceive(asyncResult);

                    t = JsonSerializer.Deserialize<T>(Encoding.UTF8.GetString(receiveBuffer, 0, receiveSize));
                }, socket);

                //_ = socket!.EndSend(asyncResult);

            }, _client);

            await Task.CompletedTask;

            return t;
        }

        public async ValueTask<T?> GetTAsyncS<T>(MessagePackage messagePackage) where T : class
        {
            var _client = new Socket(_endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                if (!_client.Connected) await _client.ConnectAsync(_endPoint);

                var buffer = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(messagePackage));

                await _client.SendAsync(buffer, SocketFlags.None);

                var receiveBuffer = new byte[BUFFER_SIZE * 32];

                var receiveSize = await _client.ReceiveAsync(receiveBuffer, SocketFlags.None);

                _client.Shutdown(SocketShutdown.Both);

                var bufferData = new byte[receiveSize];

                Array.Copy(receiveBuffer, bufferData, receiveSize);

                return JsonSerializer.Deserialize<T>(Encoding.UTF8.GetString(bufferData, 0, receiveSize));
            }
            catch (SocketException) { return null; }
        }
    }
}
