namespace SocketCL.Constants
{
    /// <summary>
    /// This is a Message Group which determines the message's accessibility options, e.g, how many times the message should be read before being removed from queue.
    /// </summary>
    public class MGrp
    {
        /// <summary>
        /// Message is NOT dequeued after being read
        /// </summary>
        public const string IDN = "0001";

        /// <summary>
        /// Message is dequeued after being read
        /// </summary>
        public const string ODN = "0002";

        /// <summary>
        /// Message is read by a specified number of receiver and dequeued.
        /// NB: The number is specified on the Number of Readers (NR) attribute.
        /// </summary>
        public const string RDN = "0002";
    }
}
