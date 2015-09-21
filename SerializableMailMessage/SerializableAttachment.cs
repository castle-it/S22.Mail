using System;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace S22.Mail
{
  [Serializable]
  public class SerializableAttachment
  {
    /// <summary>
    ///   Initializes a new instance of the <see cref="SerializableAttachment" /> class.
    /// </summary>
    /// <param name="attachment">The attachment.</param>
    private SerializableAttachment(Attachment attachment)
    {
      Name = attachment.Name;
      NameEncoding = attachment.NameEncoding;
      ContentDisposition = attachment.ContentDisposition;
      ContentId = attachment.ContentId;
      ContentStream = new MemoryStream();
      attachment.ContentStream.CopyTo(ContentStream);
      attachment.ContentStream.Position = 0;
      ContentType = attachment.ContentType;
      TransferEncoding = attachment.TransferEncoding;
    }

    /// <summary>
    ///   Gets the content disposition.
    /// </summary>
    /// <value>The content disposition.</value>
    public SerializableContentDisposition ContentDisposition { get; }

    /// <summary>
    ///   Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    public string Name { get; set; }

    /// <summary>
    ///   Gets or sets the name encoding.
    /// </summary>
    /// <value>The name encoding.</value>
    public Encoding NameEncoding { get; set; }

    /// <summary>
    ///   Gets or sets the content identifier.
    /// </summary>
    /// <value>The content identifier.</value>
    public string ContentId { get; set; }

    /// <summary>
    ///   Gets the content stream.
    /// </summary>
    /// <value>The content stream.</value>
    public Stream ContentStream { get; }

    /// <summary>
    ///   Gets or sets the type of the content.
    /// </summary>
    /// <value>The type of the content.</value>
    public SerializableContentType ContentType { get; set; }

    /// <summary>
    ///   Gets or sets the transfer encoding.
    /// </summary>
    /// <value>The transfer encoding.</value>
    public TransferEncoding TransferEncoding { get; set; }

    /// <summary>
    ///   Performs an implicit conversion from <see cref="SerializableAttachment" /> to <see cref="Attachment" />.
    /// </summary>
    /// <param name="attachment">The attachment.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator Attachment(SerializableAttachment attachment)
    {
      if (attachment == null)
        return null;
      var a = new Attachment(attachment.ContentStream, attachment.Name);

      a.ContentStream.Position = 0;
      a.ContentDisposition.CreationDate = attachment.ContentDisposition.CreationDate;
      a.ContentDisposition.DispositionType = attachment.ContentDisposition.DispositionType;
      a.ContentDisposition.FileName = attachment.ContentDisposition.FileName;
      a.ContentDisposition.Inline = attachment.ContentDisposition.Inline;
      a.ContentDisposition.ModificationDate = attachment.ContentDisposition.ModificationDate;
      a.ContentDisposition.ReadDate = attachment.ContentDisposition.ReadDate;
      a.ContentDisposition.Size = attachment.ContentDisposition.Size;
      foreach (string k in attachment.ContentDisposition.Parameters.Keys)
        a.ContentDisposition.Parameters.Add(k, attachment.ContentDisposition.Parameters[k]);

      a.NameEncoding = attachment.NameEncoding;
      a.Name = attachment.Name;
      a.ContentId = attachment.ContentId;
      a.ContentType = attachment.ContentType;
      a.TransferEncoding = attachment.TransferEncoding;
      return a;
    }

    /// <summary>
    ///   Implements the operator implicit SerializableAttachment.
    /// </summary>
    /// <param name="attachment">The attachment.</param>
    /// <returns>The result of the operator.</returns>
    public static implicit operator SerializableAttachment(Attachment attachment)
      => attachment == null ? null : new SerializableAttachment(attachment);
  }
}