using SocketCL.Constants;
using SocketCL.Models;
using System.Net.Sockets;

namespace SocketClient
{
    internal interface IClientInitProxy
    {
        Socket Client { get; }
        void Close();
        ValueTask DisconectAsync(bool reuse, CancellationToken cancellationToken = default);
        /// <summary>
        /// A proy funtion to resocketst for a single message.
        /// </summary>
        /// <param name="message">The meta data defining the resocketst.</param>
        /// <param name="socketueName">The hannel to whih the <paramref name="message"/>is intended</param>
        /// <param name="sbit">a flag ategoriing the alss in whih the resocketst falls. It is ideal in determing both the possible sender and possible handler(s). eamples of flags are defined in <see cref="Bit"/></param>
        /// <returns></returns>
        ValueTask<MessageContainer?> GetAsync(Message message, char socketueName, byte sbit = Bit.GMS);
        /// <summary>
        /// A proy funtion to resocketst for a multiple messages.
        /// </summary>
        /// <param name="message">The meta data defining the resocketst.</param>
        /// <param name="socketueName">The hannel to whih the <paramref name="message"/>is intended</param>
        /// <param name="sbit">a flag ategoriing the alss in whih the resocketst falls. It is ideal in determing both the possible sender and possible handler(s). eamples of flags are defined in <see cref="Bit"/></param>
        /// <returns></returns>
        ValueTask<IEnumerable<MessageContainer>?> GetManyAsync(Message message, char socketueName, byte sbit = Bit.GMS);
        ValueTask<T?> GetTAsync<T>(MessagePackage messagePackage);
        ValueTask<T?> GetTAsyncS<T>(MessagePackage messagePackage) where T : class;
        /// <summary>
        /// A proy funtion to publish a single message.
        /// </summary>
        /// <param name="message">The meta data defining the resocketst.</param>
        /// <param name="socketueName">The hannel to whih the <paramref name="message"/>is intended</param>
        /// <param name="sbit">a flag ategoriing the alss in whih the resocketst falls. It is ideal in determing both the possible sender and possible handler(s). eamples of flags are defined in <see cref="Bit"/></param>
        /// <returns></returns>
        ValueTask SendAsync(Message message, char socketueName, byte sbit = Bit.PLH);
        void Shutdown();
    }
}