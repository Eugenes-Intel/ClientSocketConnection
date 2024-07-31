namespace Rootsware.Libraries.SocketCL.Models;

public class MessagePackage
{
    /// <summary>
    ///     A
    ///     setter
    ///     bit
    /// </summary>
    public byte SBit { get; set; }

    /// <summary>
    ///     The
    ///     channel/queue
    ///     name
    ///     to
    ///     which
    ///     to
    ///     subscribe/publish
    ///     to.
    /// </summary>
    public char Channel { get; set; }

    /// <summary>
    ///     Message
    ///     object
    ///     with
    ///     meta
    ///     data
    ///     describing
    ///     the
    ///     message.
    /// </summary>
    public Message? Message { get; set; }
}