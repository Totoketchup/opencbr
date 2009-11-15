using System;

namespace Sample
{
	using org.opencbr.core.engine;
	using org.opencbr.core.express;	
	using System.IO;

	/// <summary>
	/// Class1 的摘要说明。
	/// </summary>
	class Sample
	{
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			// Initialize the case base
			org.opencbr.core.engine.DefaultEngine _engine = new org.opencbr.core.engine.DefaultEngine();
			string _env = @"D:\projects\opencbr\sample\workspace\config.xml"; 
			_engine.SetEnvironmentVariable(_env);
			

			// Initialize the problem
			Case _problem = new Case(1, "cooling", "cooling problem");
			
			_problem.AddFeature("speed", FeatureType.TYPE_FEATURE_FLOAT,
				19.0, 0.3, false, false);
			_problem.AddFeature("temp", FeatureType.TYPE_FEATURE_FLOAT,
				44.0, 0.7, false, false);   ////initialize to 51 or 44 to demo retrieval of closest cases (3 versus 4) from Database
			_problem.AddFeature("quality", FeatureType.TYPE_FEATURE_FLOAT,
				232.0, 1.0, false, false);
			_engine.SetProblem(_problem);
			
			
			// Run the reasoning engine
			_engine.Startup();
			_engine.Run();
			
			// Print the result of reasoning
			org.opencbr.core.context.ICBRContext ctx = _engine.GetCBRContext();
			org.opencbr.core.express.Case c = ctx.GetSolutionCase();
			
			Console.WriteLine(c);
		}
	}
}
