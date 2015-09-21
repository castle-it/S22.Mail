### Introduction

This repository contains a .NET assembly which adds a couple of extension methods to
the MailMessage class of the System.Net.Mail namespace. It also contains a serializable
replica of the MailMessage class.

### Usage & Examples

To use the library add the S22.Mail.dll assembly to your project references in Visual Studio.
The **SerializableMailMessage** class implements conversion operators to allow for implicit
conversion between SerializableMailMessage and MailMessage objects.

	using System;
	using System.IO;
	using System.Net.Mail;
	using System.Runtime.Serialization;
	using System.Runtime.Serialization.Formatters.Binary;
	using S22.Mail;

	namespace Test {
		class Program {
			static void Main() {
				MailMessage msg = MyMailMessage();

				IFormatter formatter = new BinaryFormatter();
				using(MemoryStream s = new MemoryStream()) {
					// Serialize MailMessage to memory stream
					formatter.Serialize(s, (SerializableMailMessage)message);

					// Rewind stream and deserialize MailMessage
					s.Seek(0, SeekOrigin.Begin);
					MailMessage Tmp = (SerializableMailMessage)formatter.Deserialize(s)

					Console.WriteLine(Tmp.Subject);
					Console.WriteLine(Tmp.Body);
				}
			}

			static MailMessage MyMailMessage() {
				MailMessage m = new MailMessage("John@Doe.com", "Jane@Doe.com");

				m.Subject = "Hello World";
				m.Body = "This is just a test";
				m.Attachments.Add(new Attachment("Test.cs""));

				return m;
			}
		}
	}

### Extension Methods

*System.Net.Mail.MailMessage*
- *Load(Stream stream)*
- *Load(string name)*
- *Save(Stream stream)*
- *Save(string name)*

*System.Net.Mail.Attachment*
- *SaveAs(string name)*


### Credits

This library is copyright © 2012 Torben Könke.

Modifications copyright © Ris Adams


### License

This library is released under the [MIT license](https://opensource.org/licenses/MIT)



The MIT License (MIT)

Copyright (c) 2012,2015 Torben Könke, Ris Adams

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
