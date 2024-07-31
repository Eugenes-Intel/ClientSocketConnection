namespace Rootsware.Libraries.SocketCL.Constants;

/// <summary>
///     This
///     is
///     a
///     request
///     category
///     which
///     determines
///     the
///     request's
///     domain
///     options,
///     e.g,
///     which
///     objects
///     does
///     this
///     request
///     affect
///     or
///     is
///     limited
///     to
///     interact
///     with.
/// </summary>
public class RCatg
{
    /// <summary>
    ///     Request
    ///     is
    ///     designed
    ///     for
    ///     global
    ///     objects
    /// </summary>
    public const char GLB = 'L';

    /// <summary>
    ///     Request
    ///     is
    ///     device
    ///     oriented,
    ///     i.e.
    ///     it
    ///     is
    ///     limited
    ///     to
    ///     device
    ///     specific
    ///     objects
    /// </summary>
    public const char DVC = 'D';

    /// <summary>
    ///     Request
    ///     is
    ///     invoice
    ///     oriented,
    ///     i.e.
    ///     it
    ///     is
    ///     limited
    ///     to
    ///     invoice
    ///     specific
    ///     objects
    /// </summary>
    public const char IVC = 'V';

    /// <summary>
    ///     Request
    ///     is
    ///     fiscal
    ///     day
    ///     oriented,
    ///     i.e.
    ///     it
    ///     is
    ///     limited
    ///     to
    ///     fiscal
    ///     day
    ///     specific
    ///     objects
    /// </summary>
    public const char FSD = 'F';

    /// <summary>
    ///     Request
    ///     contains
    ///     hybrid
    ///     artifects
    ///     that
    ///     can
    ///     be
    ///     consumed
    ///     by
    ///     both
    ///     global
    ///     and
    ///     device
    ///     objects
    /// </summary>
    public const char HYB = 'B';
}