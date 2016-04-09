using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
namespace TinhBao55
{
	public static class myModule
	{
		public static string myCTPara = "CT.para";
		public static string myComputerName = "localhost";
		public static string myServerComputer = "127.0.0.1";
		public const int PORT_NUM = 10062;
		[DllImport("kernel32", CharSet = CharSet.Ansi, EntryPoint = "GetComputerNameW", ExactSpelling = true, SetLastError = true)]
		public static extern void GetComputerName([MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpBuffer, ref int nSize);
		public static string GetComputerName()
		{
			StringBuilder stringBuilder = new StringBuilder(50);
			int maxCapacity = stringBuilder.MaxCapacity;
			myModule.GetComputerName(stringBuilder, ref maxCapacity);
			return stringBuilder.ToString();
		}
		public static bool LoadPara(string pFileName)
		{
			bool result = false;
			try
			{
				XmlTextReader xmlTextReader = new XmlTextReader(pFileName);
				myModule.XML2Para(xmlTextReader);
				xmlTextReader.Close();
				result = true;
			}
			catch (Exception expr_19)
			{
				throw expr_19;
							}
			return result;
		}
		private static void XML2Para(XmlTextReader rr)
		{
			try
			{
				while (rr.Read())
				{
					XmlNodeType nodeType = rr.NodeType;
					XmlNodeType xmlNodeType = nodeType;
					if (xmlNodeType == XmlNodeType.Element)
					{
						string name = rr.Name;
						if (name == "PARA" && rr.AttributeCount > 0)
						{
							while (rr.MoveToNextAttribute())
							{
								string name2 = rr.Name;
								if (name2 == "ServerComputer")
								{
									myModule.myServerComputer = rr.Value;
								}
								else if (name2 == "SoundDir")
								{
									modSound.mySoundDir = rr.Value;
								}
								else if (name2 == "Tempo")
								{
									modSound.Tempo = Convert.ToSingle(rr.Value);
								}
								else if (name2 == "DurationMax")
								{
									modSound.DurationMax = Convert.ToDouble(rr.Value);
								}
							}
						}
					}
				}
			}
			catch (Exception expr_DB)
			{
				throw expr_DB;
				Exception ex = expr_DB;
				throw ex;
			}
		}
		private static void readline(string path)
		{
			try
			{
				using (StreamReader streamReader = new StreamReader(path))
				{
					string text;
					do
					{
						text = streamReader.ReadLine();
						Console.WriteLine(text);
					}
					while (text != null);
					streamReader.Close();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("The file could not be read:");
				Console.WriteLine(ex.Message);
                throw ex;
            }
		}
		private static void writeline(string path)
		{
			try
			{
				if (File.Exists(path))
				{
					File.Delete(path);
				}
				StreamWriter streamWriter = new StreamWriter(path);
				streamWriter.WriteLine("This");
				streamWriter.WriteLine("is some text");
				streamWriter.WriteLine("to test");
				streamWriter.WriteLine("Reading");
				streamWriter.Close();
				StreamReader streamReader = new StreamReader(path);
				while (streamReader.Peek() >= 0)
				{
					Console.WriteLine(streamReader.ReadLine());
				}
				streamReader.Close();
			}
			catch (Exception ex)
			{
                Console.WriteLine("The process failed: {0}", ex.ToString());
				throw ex;
            }
		}
	}
}