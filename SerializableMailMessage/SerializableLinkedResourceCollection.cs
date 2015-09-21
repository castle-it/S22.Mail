using System;
using System.Collections.ObjectModel;

namespace S22.Mail
{
  [Serializable]
  public class SerializableLinkedResourceCollection : Collection<SerializableLinkedResource>, IDisposable
  {
    /// <summary>
    ///   Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {
    }
  }
}