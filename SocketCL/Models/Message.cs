using SocketCL.Enums;

namespace SocketCL.Models;

public class Message
{
    /// <summary>
    /// The module which is sending the message. It is an one of the <seealso cref="Constants.Mdl"/>.
    /// </summary>
    public char Module { get; set; }

    /// <summary>
    /// The drive to handle the message.
    /// </summary>
    public char Drive { get; set; }

    /// <summary>
    /// Actual contents or details or data of the request.
    /// </summary>
    public byte[]? Contents { get; set; }

    public string? Title { get; set; }

    /// <summary>
    /// The actual object sending the request
    /// </summary>
    public string? Sender { get; set; }

    /// <summary>
    /// Distingiushes requests based on the category on which they are processed. It is influenced by elements in <seealso cref="SocketCL.Constants.RCatg"/>
    /// </summary>
    public char Catg { get; set; }

    /// <summary>
    /// A flag to define an object category that handle API messages.
    /// </summary>
    public byte Itxn { get; set; }

    public MTyp MTyp { get; set; }

    public string? MGrp { get; set; }

}


