using Rootsware.Libraries.SocketCL.Constants;

namespace Rootsware.Libraries.SocketCL.Models;

public class MessageContainer
{
    /// <summary>
    ///     A
    ///     Get
    ///     Flag
    ///     Bit
    ///     that
    ///     flags
    ///     if
    ///     a
    ///     get
    ///     request
    ///     yielded
    ///     an
    ///     results
    ///     from
    ///     the
    ///     queue.
    ///     <see
    ///         cref="0x00" />
    ///     represents
    ///     that
    ///     the
    ///     queue
    ///     yielded
    ///     contents
    ///     <see
    ///         cref="0x01" />
    ///     represents
    ///     that
    ///     the
    ///     queue
    ///     yielded
    ///     no
    ///     contents
    /// </summary>
    public byte GFB { get; set; } = Bit.QFA;

    public Guid LockToken { get; set; }

    public Guid MessageId { get; set; }

    public Message Body { get; set; }
}