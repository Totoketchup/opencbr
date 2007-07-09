using System;

namespace org.opencbr.core.testcase.method
{
	using org.opencbr.core.method;
	using org.opencbr.core.express;
	using org.opencbr.core.casebase;
	using System.Collections;
	using NUnit.Framework;
	/// <summary>
	/// testDefaultCaseRetrievalMethod 的摘要说明。
	/// </summary>
	[TestFixture]
	public class testDefaultCaseRetrievalMethod
	{
		Case c1 = new Case(1, "testcase", "testcase");
		Case c2 = new Case(1, "testcase", "testcase");
		Case c3 = new Case(1, "testCase", "testcase");
		Case c4 = new Case(1, "testCase", "testCase");
		Case c5 = new Case(1, "testCase", "testCase");
		DefaultCaseRetrievalMethod m = new DefaultCaseRetrievalMethod();
		ArrayList list = new ArrayList();
		IStat stat1 = null;
		IStat stat2 = null;
		IStat stat3 = null;
		public testDefaultCaseRetrievalMethod()
		{
		}
		[SetUp]public void Init()
		{
			c1.AddFeature("speed", FeatureType.TYPE_FEATURE_FLOAT,
				2.0, 0.5, false, false);
			c2.AddFeature("speed", FeatureType.TYPE_FEATURE_FLOAT,
				3.8, 0.5, false, false);
			c3.AddFeature("speed", FeatureType.TYPE_FEATURE_FLOAT,
				7.0, 0.5, false, false);
			c4.AddFeature("speed", FeatureType.TYPE_FEATURE_FLOAT,
				9.0, 0.5, false, false);
			c5.AddFeature("speed", FeatureType.TYPE_FEATURE_FLOAT,
				5.0, 0.5, false, false);


			c1.AddFeature("temperature", FeatureType.TYPE_FEATURE_FLOAT,
				3.0, 0.3, false, false);
			c2.AddFeature("temperature", FeatureType.TYPE_FEATURE_FLOAT,
				4.0, 0.3, false, false);
			c3.AddFeature("temperature", FeatureType.TYPE_FEATURE_FLOAT,
				2.0, 0.3, false, false);
			c4.AddFeature("temperature", FeatureType.TYPE_FEATURE_FLOAT,
				7.0, 0.3, false, false);
			c5.AddFeature("temperature", FeatureType.TYPE_FEATURE_FLOAT,
				1.0, 0.3, false, false);

			c1.AddFeature("quality", FeatureType.TYPE_FEATURE_FLOAT,
				1.0, 0.2, false, false);
			c2.AddFeature("quality", FeatureType.TYPE_FEATURE_FLOAT,
				2.0, 0.2, false, false);
			c3.AddFeature("quality", FeatureType.TYPE_FEATURE_FLOAT,
				5.0, 0.2, false, false);
			c4.AddFeature("quality", FeatureType.TYPE_FEATURE_FLOAT,
				7.0, 0.2, false, false);
			c5.AddFeature("quality", FeatureType.TYPE_FEATURE_FLOAT,
				3.0, 0.2, false, false);

			c1.AddFeature("result",FeatureType.TYPE_FEATURE_FLOAT,
				1.0, 0, true, false);
			c2.AddFeature("result", FeatureType.TYPE_FEATURE_FLOAT,
				2.0, 0, true, false);
			c3.AddFeature("result", FeatureType.TYPE_FEATURE_FLOAT,
				6.0, 0, true, false);
			c4.AddFeature("result", FeatureType.TYPE_FEATURE_FLOAT,
				8.0, 0, true, false);
			c5.AddFeature("result", FeatureType.TYPE_FEATURE_FLOAT,
				11.0, 0, true, false);


			IStat s1 = StatFactory.newInstance();
			s1.SetCBRCase(c1);
			s1.SetCaseSimilarity(400.03);
			list.Add(s1);
			
			IStat s2 = StatFactory.newInstance();
			s2.SetCBRCase(c2);
			s2.SetCaseSimilarity(300.3);
			list.Add(s2);

			IStat s3 = StatFactory.newInstance();
			s3.SetCBRCase(c3);
			s3.SetCaseSimilarity(200.4);
			list.Add(s3);

			IStat s4 = StatFactory.newInstance();
			s4.SetCBRCase(c4);
			s4.SetCaseSimilarity(100.45);
			list.Add(s4);

			IStat s5 = StatFactory.newInstance();
			s5.SetCBRCase(c5);
			s5.SetCaseSimilarity(80.23);
			list.Add(s5);


			//test case 1
			stat1 = StatFactory.newInstance();
			stat1.SetCBRCase(c1);
			stat1.SetCaseSimilarity(111.098);
			//test case 2 for upper bound
			stat2 = StatFactory.newInstance();
			stat2.SetCBRCase(c1);
			stat2.SetCaseSimilarity(50.098);
			//test case 3 for under bound
			stat3 = StatFactory.newInstance();
			stat3.SetCBRCase(c1);
			stat3.SetCaseSimilarity(1110.098);

		}
		[Test]public void testSortSimilarity1()
		{
			m.SortSimilarity(list, stat1);
			Assert.AreEqual(stat1.GetCaseSimilarity(), 
				((IStat)list[3]).GetCaseSimilarity());
		}
		[Test]public void testSortSimilarity2()
		{
			m.SortSimilarity(list, stat2);
			Assert.AreEqual(stat2.GetCaseSimilarity(), 
				((IStat)list[5]).GetCaseSimilarity());

		}
		[Test]public void testSortSimilarity3()
		{
			m.SortSimilarity(list, stat3);
			Assert.AreEqual(stat3.GetCaseSimilarity(), 
				((IStat)list[0]).GetCaseSimilarity());
		}
	}
}
