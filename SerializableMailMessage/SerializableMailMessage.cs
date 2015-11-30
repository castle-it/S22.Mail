using System;
using System.Collections.Specialized;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace S22.Mail
{
  /// <summary>
  ///   A serializable replication of the MailMessage class of the
  ///   System.Net.Mail namespace. It implements conversion operators to allow for
  ///   implicit conversion between SerializableMailMessage and MailMessage objects.
  /// </summary>
  [Serializable]
  public class SerializableMailMessage
  {
    /// <summary>
    ///   Initializes a new instance of the <see cref="SerializableMailMessage" /> class.
    /// </summary>
    /// <param name="m">The m.</param>
    private SerializableMailMessage(MailMessage m)
    {
      AlternateViews = new SerializableAlternateViewCollection();
      foreach (var a in m.AlternateViews)
        AlternateViews.Add(a);
      Attachments = new SerializableAttachmentCollection();
      foreach (var a in m.Attachments)
        Attachments.Add(a);
      Bcc = new SerializableMailAddressCollection();
      foreach (var a in m.Bcc)
        Bcc.Add(a);
      Body = m.Body;
      BodyEncoding = m.BodyEncoding;
      BodyTransferEncoding = m.BodyTransferEncoding;
      CC = new SerializableMailAddressCollection();
      foreach (var a in m.CC)
        CC.Add(a);
      DeliveryNotificationOptions = m.DeliveryNotificationOptions;
      From = m.From;
      Headers = new NameValueCollection();
      Headers.Add(m.Headers);
      HeadersEncoding = m.HeadersEncoding;
      IsBodyHtml = m.IsBodyHtml;
      Priority = m.Priority;
      ReplyTo = m.ReplyTo;
      ReplyToList = new SerializableMailAddressCollection();
      foreach (var a in m.ReplyToList)
        ReplyToList.Add(a);
      Sender = m.Sender;
      Subject = m.Subject;
      SubjectEncoding = m.SubjectEncoding;
      To = new SerializableMailAddressCollection();
      foreach (var a in m.To)
        To.Add(a);
    }

    /// <summary>
    ///   Gets the alternate views.
    /// </summary>
    /// <value>The alternate views.</value>
    public SerializableAlternateViewCollection AlternateViews { get; }

    /// <summary>
    ///   Gets the attachments.
    /// </summary>
    /// <value>The attachments.</value>
    public SerializableAttachmentCollection Attachments { get; }

    /// <summary>
    ///   Gets the BCC.
    /// </summary>
    /// <value>The BCC.</value>
    public SerializableMailAddressCollection Bcc { get; }

    /// <summary>
    ///   Gets or sets the body.
    /// </summary>
    /// <value>The body.</value>
    public string Body { get; set; }

    /// <summary>
    ///   Gets or sets the body encoding.
    /// </summary>
    /// <value>The body encoding.</value>
    public Encoding BodyEncoding { get; set; }

    /// <summary>
    ///   Gets or sets the body transfer encoding.
    /// </summary>
    /// <value>The body transfer encoding.</value>
    public TransferEncoding BodyTransferEncoding { get; }

    /// <summary>
    ///   Gets the cc.
    /// </summary>
    /// <value>The cc.</value>
    public SerializableMailAddressCollection CC { get; }

    /// <summary>
    ///   Gets or sets the delivery notification options.
    /// </summary>
    /// <value>The delivery notification options.</value>
    public DeliveryNotificationOptions DeliveryNotificationOptions { get; set; }

    /// <summary>
    ///   Gets or sets from.
    /// </summary>
    /// <value>From.</value>
    public SerializableMailAddress From { get; set; }

    /// <summary>
    ///   Gets the headers.
    /// </summary>
    /// <value>The headers.</value>
    public NameValueCollection Headers { get; }

    /// <summary>
    ///   Gets or sets the headers encoding.
    /// </summary>
    /// <value>The headers encoding.</value>
    public Encoding HeadersEncoding { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether this instance is body HTML.
    /// </summary>
    /// <value><c>true</c> if this instance is body HTML; otherwise, <c>false</c>.</value>
    public bool IsBodyHtml { get; set; }

    /// <summary>
    ///   Gets or sets the priority.
    /// </summary>
    /// <value>The priority.</value>
    public MailPriority Priority { get; set; }

    /// <summary>
    ///   Gets or sets the reply to.
    /// </summary>
    /// <value>The reply to.</value>
    public SerializableMailAddress ReplyTo { get; set; }

    /// <summary>
    ///   Gets the reply to list.
    /// </summary>
    /// <value>The reply to list.</value>
    public SerializableMailAddressCollection ReplyToList { get; }

    /// <summary>
    ///   Gets or sets the sender.
    /// </summary>
    /// <value>The sender.</value>
    public SerializableMailAddress Sender { get; set; }

    /// <summary>
    ///   Gets or sets the subject.
    /// </summary>
    /// <value>The subject.</value>
    public string Subject { get; set; }

    /// <summary>
    ///   Gets or sets the subject encoding.
    /// </summary>
    /// <value>The subject encoding.</value>
    public Encoding SubjectEncoding { get; set; }

    /// <summary>
    ///   Gets to.
    /// </summary>
    /// <value>To.</value>
    public SerializableMailAddressCollection To { get; }

    /// <summary>
    ///   Performs an implicit conversion from <see cref="SerializableMailMessage" /> to <see cref="MailMessage" />.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator MailMessage(SerializableMailMessage message)
    {
      var m = new MailMessage();
      foreach (var a in message.AlternateViews)
        m.AlternateViews.Add(a);
      foreach (var a in message.Attachments)
        m.Attachments.Add(a);
      foreach (var a in message.Bcc)
        m.Bcc.Add(a);
      m.Body = message.Body;
      m.BodyEncoding = message.BodyEncoding;
      m.BodyTransferEncoding = message.BodyTransferEncoding;
      foreach (var a in message.CC)
        m.CC.Add(a);
      m.DeliveryNotificationOptions = message.DeliveryNotificationOptions;
        if (message.From != null)
        {
            m.From = message.From;
        }
        m.Headers.Add(message.Headers);
      m.HeadersEncoding = message.HeadersEncoding;
      m.IsBodyHtml = message.IsBodyHtml;
      m.Priority = message.Priority;
        if (message.ReplyTo != null)
        {
            m.ReplyTo = message.ReplyTo;
        }
        foreach (var a in message.ReplyToList)
        m.ReplyToList.Add(a);
        if (message.Sender != null)
        {
            m.Sender = message.Sender;
        }
        m.Subject = message.Subject;
      m.SubjectEncoding = message.SubjectEncoding;
      foreach (var a in message.To)
        m.To.Add(a);
      return m;
    }

    /// <summary>
    ///   Implements the operator implicit SerializableMailMessage.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <returns>The result of the operator.</returns>
    public static implicit operator SerializableMailMessage(MailMessage message) => new SerializableMailMessage(message);
  }
}