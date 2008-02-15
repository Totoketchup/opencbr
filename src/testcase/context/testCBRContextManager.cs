using System;

namespace org.opencbr.core.testcase.context
{
	using NUnit.Framework;
	using org.opencbr.core.context;
	using System.Reflection;
	/// <summary>
	/// testCBRContextManager 的摘要说明。
	/// </summary>
	[TestFixture]
	public class testCBRContextManager
	{
        //string path = @"../../context/config.xml";
        string path = @"C:\topics\org.opencbr.core\context\config.xml";
        public testCBRContextManager()
		{
			
		}
		[Test]public void Init()
		{
		}
		[Test]
		public void testGetCBRContext()
		{

			CBRContextManager.Load("engine1", path);
			ICBRContext ctx =  CBRContextManager.GetCBRContext("engine1");  //path);

			System.Console.WriteLine(ctx.GetCaseBase().ToString());
			System.Console.WriteLine(ctx.GetCaseBase().GetEnv());

			System.Console.WriteLine(ctx.GetCaseBaseInput().ToString());
			
			System.Console.WriteLine(ctx.GetCaseBaseInputType().ToString());

			System.Console.WriteLine(ctx.GetCaseRestoreMethod().ToString());
			System.Console.WriteLine(ctx.GetCaseRestoreMethod().GetEnv());
			
			System.Console.WriteLine(ctx.GetCaseRetrievalMethod().ToString());
			System.Console.WriteLine(ctx.GetCaseRetrievalMethod().GetEnv());

			System.Console.WriteLine(ctx.GetCaseReuseMethod().ToString());
			System.Console.WriteLine(ctx.GetCaseReuseMethod().GetEnv());

			System.Console.WriteLine(ctx.GetCaseReuseStrategy().ToString());
			System.Console.WriteLine(ctx.GetCaseReuseStrategy().GetEnv());

			System.Console.WriteLine(ctx.GetSimilarity().ToString());
			System.Console.WriteLine(ctx.GetSimilarity().GetEnv());

			System.Console.WriteLine(ctx.GetSimilarityThrehold().ToString());
			
		}
	}
}
