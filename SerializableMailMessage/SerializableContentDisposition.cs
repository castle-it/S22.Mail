using System;
using System.Collections.Specialized;
using System.Net.Mime;

namespace S22.Mail
{
  [Serializable]
  public class SerializableContentDisposition
  {
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

    public DateTime CreationDate { get; set; }
    public string DispositionType { get; set; }
    public string FileName { get; set; }
    public bool Inline { get; set; }
    public DateTime ModificationDate { get; set; }
    public StringDictionary Parameters { get; }
    public DateTime ReadDate { get; set; }
    public long Size { get; set; }

    public static implicit operator ContentDisposition(SerializableContentDisposition disposition)
    {
      if (disposition == null)
        return null;
      var d = new ContentDisposition();
      disposition.CopyTo(d);
      return d;
    }

    public static implicit operator SerializableContentDisposition(ContentDisposition disposition)
    {
      if (disposition == null)
        return null;
      return new SerializableContentDisposition(disposition);
    }

    public void CopyTo(ContentDisposition disposition)
    {
      if (disposition == null)
        return;

      disposition.Inline = Inline;
      disposition.DispositionType = DispositionType;
      disposition.FileName = FileName;
      disposition.CreationDate = CreationDate;
      disposition.ModificationDate = ModificationDate;
      disposition.ReadDate = ReadDate;
      if (Size != -1L)
        disposition.Size = Size;

      foreach (string k in Parameters.Keys)
        if (disposition.Parameters.ContainsKey(k) == false)
          disposition.Parameters.Add(k, Parameters[k]);
    }
  }
}