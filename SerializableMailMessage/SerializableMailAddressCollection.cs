using System;
using System.Collections.ObjectModel;

namespace S22.Mail
{
  /// <summary>
  ///   Class SerializableMailAddressCollection.
  /// </summary>
  [Serializable]
  public class SerializableMailAddressCollection : Collection<SerializableMailAddress>
  {
  }
}