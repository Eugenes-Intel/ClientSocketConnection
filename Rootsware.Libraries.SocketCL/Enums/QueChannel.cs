namespace Rootsware.Libraries.SocketCL.Enums;

/// <summary>
///     A
///     channel
///     to
///     describe
///     the
///     queue
///     to
///     which
///     the
///     message
///     is
///     intended
///     to/from.
///     It
///     is
///     unicode
///     equivalent
///     to
///     starting
///     at
///     'A'.
/// </summary>
public enum QueChannel
{
    /// <summary>
    ///     Pending
    ///     messages
    ///     channel
    /// </summary>
    pnd = 65,

    /// <summary>
    ///     Succsess
    ///     messages
    ///     channel
    /// </summary>
    suc,

    /// <summary>
    ///     Failed
    ///     messages
    ///     channel
    /// </summary>
    fld
}