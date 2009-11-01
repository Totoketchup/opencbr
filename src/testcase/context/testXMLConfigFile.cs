using System;

namespace org.opencbr.core.testcase.context
{
	using org.opencbr.core.context;
	using NUnit.Framework;
	using System.Collections;
	/// <summary>
	/// testXMLConfigFile 的摘要说明。
	/// </summary>
	[TestFixture]
	public class testXMLConfigFile
	{
		XMLConfigFile file = null;
		string path = @"..\..\context\config.xml";
		//string path = @"C:\topics\org.opencbr.core\context\config.xml";
		public testXMLConfigFile()
		{
		}
		[SetUp]public void Init()
		{
			file = new XMLConfigFile(path);
		}
		[Test]public void testGetConfigInfo()
		{
			ConfigInfo config =  file.GetConfigInfo();
			Hashtable h = config.GetMappingEntries();
			
			IDictionaryEnumerator e = h.GetEnumerator();
			while (e.MoveNext())
			{
				DictionaryEntry d = (DictionaryEntry)e.Current;
				System.Console.WriteLine(d.Key + "-----" + d.Value);	
			}
			Hashtable h1 = config.GetOuterDLLPaths();
			IDictionaryEnumerator e1 = h1.GetEnumerator();
			while (e1.MoveNext())
			{
				DictionaryEntry d1 = (DictionaryEntry)e1.Current;
				System.Console.WriteLine(d1.Key + "-----" + d1.Value);	
			}

			Hashtable h2 = config.GetParameters();
			IDictionaryEnumerator e2 = h2.GetEnumerator();
			while (e2.MoveNext())
			{
				DictionaryEntry d2 = (DictionaryEntry)e2.Current;
				System.Console.WriteLine(d2.Key + "-----" + d2.Value);	
			}
		}
		 
	}
}
