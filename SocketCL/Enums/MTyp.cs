namespace SocketCL.Enums
{
    /// <summary>
    /// The type of the message which determines at which stage is the message created and directed to and from.
    /// </summary>
    public enum MTyp
    {
        /// <summary>
        /// Message is intended for topic
        /// </summary>
        tpc,

        /// <summary>
        /// Message is intended for direct
        /// </summary>
        drc
    }
}
