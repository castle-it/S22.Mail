using System;
using System.Collections.Specialized;
using System.Net.Mime;

namespace S22.Mail
{
  [Serializable]
  public class SerializableContentType
  {
    /// <summary>
    ///   Initializes a new instance of the <see cref="SerializableContentType" /> class.
    /// </summary>
    /// <param name="contentType">Type of the content.</param>
    private SerializableContentType(ContentType contentType)
    {
      Boundary = contentType.Boundary;
      CharSet = contentType.CharSet;
      MediaType = contentType.MediaType;
      Name = contentType.Name;
      Parameters = new StringDictionary();
      foreach (string k in contentType.Parameters.Keys)
      {
        if (contentType.Parameters.ContainsKey(k) == false)
          Parameters.Add(k, contentType.Parameters[k]);
      }
    }

    /// <summary>
    ///   Gets or sets the boundary.
    /// </summary>
    /// <value>The boundary.</value>
    public string Boundary { get; set; }

    /// <summary>
    ///   Gets or sets the character set.
    /// </summary>
    /// <value>The character set.</value>
    public string CharSet { get; set; }

    /// <summary>
    ///   Gets or sets the type of the media.
    /// </summary>
    /// <value>The type of the media.</value>
    public string MediaType { get; set; }

    /// <summary>
    ///   Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    public string Name { get; set; }

    /// <summary>
    ///   Gets the parameters.
    /// </summary>
    /// <value>The parameters.</value>
    public StringDictionary Parameters { get; }

    /// <summary>
    ///   Performs an implicit conversion from <see cref="SerializableContentType" /> to <see cref="ContentType" />.
    /// </summary>
    /// <param name="contentType">Type of the content.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator ContentType(SerializableContentType contentType)
    {
      if (contentType == null)
        return null;
      var ct = new ContentType
      {
        Boundary = contentType.Boundary,
        CharSet = contentType.CharSet,
        MediaType = contentType.MediaType,
        Name = contentType.Name
      };

      foreach (string k in contentType.Parameters.Keys)
        ct.Parameters.Add(k, contentType.Parameters[k]);
      return ct;
    }

    /// <summary>
    ///   Implements the operator implicit SerializableContentType.
    /// </summary>
    /// <param name="contentType">Type of the content.</param>
    /// <returns>The result of the operator.</returns>
    public static implicit operator SerializableContentType(ContentType contentType)
      => contentType == null ? null : new SerializableContentType(contentType);
  }
}