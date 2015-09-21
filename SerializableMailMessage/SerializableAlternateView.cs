using System;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;

namespace S22.Mail
{
  [Serializable]
  public class SerializableAlternateView
  {
    /// <summary>
    ///   Initializes a new instance of the <see cref="SerializableAlternateView" /> class.
    /// </summary>
    /// <param name="view">The view.</param>
    private SerializableAlternateView(AlternateView view)
    {
      BaseUri = view.BaseUri;
      LinkedResources = new SerializableLinkedResourceCollection();
      foreach (var res in view.LinkedResources)
        LinkedResources.Add(res);
      ContentId = view.ContentId;
      ContentStream = new MemoryStream();
      view.ContentStream.CopyTo(ContentStream);
      view.ContentStream.Position = 0;
      ContentType = view.ContentType;
      TransferEncoding = view.TransferEncoding;
    }

    /// <summary>
    ///   Gets or sets the base URI.
    /// </summary>
    /// <value>The base URI.</value>
    public Uri BaseUri { get; set; }

    /// <summary>
    ///   Gets the linked resources.
    /// </summary>
    /// <value>The linked resources.</value>
    public SerializableLinkedResourceCollection LinkedResources { get; }

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
    ///   Performs an implicit conversion from <see cref="SerializableAlternateView" /> to <see cref="AlternateView" />.
    /// </summary>
    /// <param name="view">The view.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator AlternateView(SerializableAlternateView view)
    {
      if (view == null)
        return null;

      var v = new AlternateView(view.ContentStream) {BaseUri = view.BaseUri};

      foreach (var res in view.LinkedResources)
        v.LinkedResources.Add(res);
      v.ContentId = view.ContentId;
      v.ContentType = view.ContentType;
      v.TransferEncoding = view.TransferEncoding;
      return v;
    }

    /// <summary>
    ///   Implements the operator implicit SerializableAlternateView.
    /// </summary>
    /// <param name="view">The view.</param>
    /// <returns>The result of the operator.</returns>
    public static implicit operator SerializableAlternateView(AlternateView view)
      => view == null ? null : new SerializableAlternateView(view);
  }
}