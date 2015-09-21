using System;
using System.Net.Mail;

namespace S22.Mail
{
  [Serializable]
  public class SerializableMailAddress
  {
    /// <summary>
    ///   Initializes a new instance of the <see cref="SerializableMailAddress" /> class.
    /// </summary>
    /// <param name="address">The address.</param>
    private SerializableMailAddress(MailAddress address)
    {
      Address = address.Address;
      DisplayName = address.DisplayName;
    }

    /// <summary>
    ///   Gets the address.
    /// </summary>
    /// <value>The address.</value>
    public string Address { get; }

    /// <summary>
    ///   Gets the display name.
    /// </summary>
    /// <value>The display name.</value>
    public string DisplayName { get; }

    /// <summary>
    ///   Implements the operator implicit MailAddress.
    /// </summary>
    /// <param name="address">The address.</param>
    /// <returns>The result of the operator.</returns>
    public static implicit operator MailAddress(SerializableMailAddress address)
      => address == null ? null : new MailAddress(address.Address, address.DisplayName);

    /// <summary>
    ///   Implements the operator implicit SerializableMailAddress.
    /// </summary>
    /// <param name="address">The address.</param>
    /// <returns>The result of the operator.</returns>
    public static implicit operator SerializableMailAddress(MailAddress address)
      => address == null ? null : new SerializableMailAddress(address);
  }
}