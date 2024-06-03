namespace SocketCL.Constants
{
    public class Bit
    {
        /// <summary>
        /// Handshake request
        /// </summary>
        public const byte HNS = 0x01;

        /// <summary>
        /// Get single message request --> A get is one-diretional. It has NO absolute payload and epets an absolute response.
        /// </summary>
        public const byte GMS = 0x08;

        /// <summary>
        /// Get many messages request
        /// </summary>
        public const byte GMM = 0x09;

        /// <summary>
        /// Publish request --> A publish is one-diretional. It has absolute payload and epets NO absolute response.
        /// </summary>
        public const byte PLH = 0x10;

        /// <summary>
        /// Subscribe request
        /// </summary>
        public const byte SBS = 0x14;

        /// <summary>
        /// Transact request --> A transation is bi-diretional. It has absolute payload and epets an absolute response.
        /// </summary>
        public const byte TRM = 0x15;

        /// <summary>
        /// A Flag Bit that flags if a get request yielded an results from the queue. The default value is <see cref="0x00"/> represents that the queue yielded contents
        /// </summary>
        public const byte QFA = 0x00;

        /// <summary>
        /// A Get Flag Bit that flags if a get request yielded an results from the queue. The default value is <see cref="0x01"/> represents that the queue yielded no contents
        /// </summary>
        public const byte QFB = 0x01;

        /// <summary>
        /// Zimra Invoice Request
        /// </summary>
        public const byte XZV = 0x021;

        /// <summary>
        /// Device Serial Number Request
        /// </summary>
        public const byte DSN = 0x022;

        /// <summary>
        /// Device Registration Request
        /// </summary>
        public const byte DRR = 0x023;

        /// <summary>
        /// Day Switch Request. --> This represents either Fiscal day close or open
        /// </summary>
        public const byte DSR = 0x024;

        /// <summary>
        /// Day Close Request. --> This represents Fiscal day close
        /// </summary>
        public const byte DCR = 0x025;

        /// <summary>
        /// Fiscal Day Status Request.
        /// </summary>
        public const byte FST = 0x026;
    }
}
