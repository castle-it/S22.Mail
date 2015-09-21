using System;
using System.Collections.Specialized;
using System.Net.Mime;

namespace S22.Mail
{
  [Serializable]
  public class SerializableContentDisposition
  {
    /// <summary>
    ///   Initializes a new instance of the <see cref="SerializableContentDisposition" /> class.
    /// </summary>
    /// <param name="disposition">The disposition.</param>
    private SerializableContentDisposition(ContentDisposition disposition)
    {
      CreationDate = disposition.CreationDate;
      DispositionType = disposition.DispositionType;
      FileName = disposition.FileName;
      Inline = disposition.Inline;
      ModificationDate = disposition.ModificationDate;
      Parameters = new StringDictionary();
      foreach (string k in disposition.Parameters.Keys)
        Parameters.Add(k, disposition.Parameters[k]);
      ReadDate = disposition.ReadDate;
      Size = disposition.Size;
    }

    /// <summary>
    ///   Gets or sets the creation date.
    /// </summary>
    /// <value>The creation date.</value>
    public DateTime CreationDate { get; set; }

    /// <summary>
    ///   Gets or sets the type of the disposition.
    /// </summary>
    /// <value>The type of the disposition.</value>
    public string DispositionType { get; set; }

    /// <summary>
    ///   Gets or sets the name of the file.
    /// </summary>
    /// <value>The name of the file.</value>
    public string FileName { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether this <see cref="SerializableContentDisposition" /> is inline.
    /// </summary>
    /// <value><c>true</c> if inline; otherwise, <c>false</c>.</value>
    public bool Inline { get; set; }

    /// <summary>
    ///   Gets or sets the modification date.
    /// </summary>
    /// <value>The modification date.</value>
    public DateTime ModificationDate { get; set; }

    /// <summary>
    ///   Gets the parameters.
    /// </summary>
    /// <value>The parameters.</value>
    public StringDictionary Parameters { get; }

    /// <summary>
    ///   Gets or sets the read date.
    /// </summary>
    /// <value>The read date.</value>
    public DateTime ReadDate { get; set; }

    /// <summary>
    ///   Gets or sets the size.
    /// </summary>
    /// <value>The size.</value>
    public long Size { get; set; }

    /// <summary>
    ///   Performs an implicit conversion from <see cref="SerializableContentDisposition" /> to
    ///   <see cref="ContentDisposition" />.
    /// </summary>
    /// <param name="disposition">The disposition.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator ContentDisposition(SerializableContentDisposition disposition)
    {
      if (disposition == null)
        return null;
      var d = new ContentDisposition();

      d.CreationDate = disposition.CreationDate;
      d.DispositionType = disposition.DispositionType;
      d.FileName = disposition.FileName;
      d.Inline = disposition.Inline;
      d.ModificationDate = disposition.ModificationDate;
      foreach (string k in disposition.Parameters.Keys)
        d.Parameters.Add(k, disposition.Parameters[k]);
      d.ReadDate = disposition.ReadDate;
      d.Size = disposition.Size;
      return d;
    }

    /// <summary>
    ///   Implements the operator implicit SerializableContentDisposition.
    /// </summary>
    /// <param name="disposition">The disposition.</param>
    /// <returns>The result of the operator.</returns>
    public static implicit operator SerializableContentDisposition(ContentDisposition disposition)
      => disposition == null ? null : new SerializableContentDisposition(disposition);
  }
}