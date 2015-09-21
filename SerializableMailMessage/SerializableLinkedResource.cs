using System;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;

namespace S22.Mail
{
  [Serializable]
  public class SerializableLinkedResource
  {
    /// <summary>
    ///   Initializes a new instance of the <see cref="SerializableLinkedResource" /> class.
    /// </summary>
    /// <param name="resource">The resource.</param>
    private SerializableLinkedResource(LinkedResource resource)
    {
      ContentLink = resource.ContentLink;
      ContentId = resource.ContentId;
      resource.ContentStream.Position = 0;

      ContentBytes = ReadStream(resource.ContentStream);
      ContentStream = new MemoryStream(ContentBytes);

      ContentType = resource.ContentType;
      TransferEncoding = resource.TransferEncoding;
    }

    /// <summary>
    ///   Gets or sets the content link.
    /// </summary>
    /// <value>The content link.</value>
    public Uri ContentLink { get; set; }

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

    public byte[] ContentBytes { get; }

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
    ///   Performs an implicit conversion from <see cref="SerializableLinkedResource" /> to <see cref="LinkedResource" />.
    /// </summary>
    /// <param name="resource">The resource.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator LinkedResource(SerializableLinkedResource resource)
    {
      if (resource == null)
        return null;

      var r = new LinkedResource(new MemoryStream(resource.ContentBytes))
      {
        ContentId = resource.ContentId,
        ContentType = resource.ContentType,
        TransferEncoding = resource.TransferEncoding
      };

      return r;
    }

    /// <summary>
    ///   Performs an implicit conversion from <see cref="LinkedResource" /> to <see cref="SerializableLinkedResource" />.
    /// </summary>
    /// <param name="resource">The resource.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator SerializableLinkedResource(LinkedResource resource)
    {
      return resource == null ? null : new SerializableLinkedResource(resource);
    }

    private static byte[] ReadStream(Stream input)
    {
      var buffer = new byte[16 * 1024];
      using (var ms = new MemoryStream())
      {
        int read;
        while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
        {
          ms.Write(buffer, 0, read);
        }
        return ms.ToArray();
      }
    }
  }
}