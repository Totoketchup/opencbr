using System;

namespace org.opencbr.core.testcase.file
{
	using org.opencbr.core.express;
	using NUnit.Framework;
	using org.opencbr.core.file;
	using System.Collections;
	/// <summary>
	/// testDefaultOCBRFile ¡£
	/// </summary>
	[TestFixture]
	public class testDefaultOCBRFile
	{

		DefaultOCBRFile file = new DefaultOCBRFile();
		public testDefaultOCBRFile()
		{
		}
		[SetUp]public void Init()
		{
			file.SetFilePath("F:\\topics\\doc\\casebase specification.txt");
		}
		[Test]public void testGetCases()
		{
			ArrayList list = file.GetCases();
			if (list != null && list.Count > 0)
			{
				for (int i = 0; i < list.Count; i++)
				{
					Case c = (Case)list[i];
					System.Console.WriteLine("case name: " + c.GetCaseName() 
						+ "\t" + c.GetCaseID());

					ArrayList features = c.GetFeatures();
					if (features != null && features.Count > 0)
					{
						for (int j = 0; j < features.Count; j++)
						{
							Feature f = (Feature)features[j];
							System.Console.WriteLine("\tfeature name:" 
							+ f.GetFeatureName());
							System.Console.WriteLine("\tfeature type:"
							+ f.GetFeatureType());
							System.Console.WriteLine("\tfeature value:"
							+ f.GetFeatureValue());
							System.Console.WriteLine("\tfeature isKey:"
							+ f.GetIsKey());
							System.Console.WriteLine("\tfeature isIndex:"
							+ f.GetIsIndex());
							System.Console.WriteLine("\tfeature weight:" 
							+ f.GetWeight());
						}
					}
				}
			}
		}
	}
}
