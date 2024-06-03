using QueComLib.Constants;
using QueComLib.Models;
using System.Net.Sockets;

namespace QueClient
{
    internal interface IClientInitProxy
    {
        Socket Client { get; }
        void Close();
        ValueTask DisconectAsync(bool reuse, CancellationToken cancellationToken = default);
        /// <summary>
        /// A proy funtion to request for a single message.
        /// </summary>
        /// <param name="message">The meta data defining the request.</param>
        /// <param name="queueName">The hannel to whih the <paramref name="message"/>is intended</param>
        /// <param name="sbit">a flag ategoriing the alss in whih the request falls. It is ideal in determing both the possible sender and possible handler(s). eamples of flags are defined in <see cref="Bit"/></param>
        /// <returns></returns>
        ValueTask<MessageContainer?> GetAsync(Message message, char queueName, byte sbit = Bit.GMS);
        /// <summary>
        /// A proy funtion to request for a multiple messages.
        /// </summary>
        /// <param name="message">The meta data defining the request.</param>
        /// <param name="queueName">The hannel to whih the <paramref name="message"/>is intended</param>
        /// <param name="sbit">a flag ategoriing the alss in whih the request falls. It is ideal in determing both the possible sender and possible handler(s). eamples of flags are defined in <see cref="Bit"/></param>
        /// <returns></returns>
        ValueTask<IEnumerable<MessageContainer>?> GetManyAsync(Message message, char queueName, byte sbit = Bit.GMS);
        ValueTask<T?> GetTAsync<T>(MessagePackage messagePackage);
        ValueTask<T?> GetTAsyncS<T>(MessagePackage messagePackage) where T : class;
        /// <summary>
        /// A proy funtion to publish a single message.
        /// </summary>
        /// <param name="message">The meta data defining the request.</param>
        /// <param name="queueName">The hannel to whih the <paramref name="message"/>is intended</param>
        /// <param name="sbit">a flag ategoriing the alss in whih the request falls. It is ideal in determing both the possible sender and possible handler(s). eamples of flags are defined in <see cref="Bit"/></param>
        /// <returns></returns>
        ValueTask SendAsync(Message message, char queueName, byte sbit = Bit.PLH);
        void Shutdown();
    }
}