using System;

namespace org.opencbr.core.engine
{
	using org.opencbr.core.context;
	using org.opencbr.core.express;
	using org.opencbr.core.casebase;
	using org.opencbr.core.method;
	using System.Collections;
	/// <summary>
	/// DefaultEngine 的摘要说明。
	/// </summary>
	public class DefaultEngine:IEngine
	{
		private ICBRContext _ctx = null;
		private string _name = null;
		private static int _engineCounter;
		public DefaultEngine()
		{
			_engineCounter++;
			_name = "Engine" + _engineCounter;
		}
		public  ICBRContext GetCBRContext()
		{
			if (_env == null)
			{
				throw new Exception("not set environment variable of cbr context");
			}
			return CBRContextManager.GetCBRContext(_name);
		}
		#region IEngine 成员

		private string _env = null;
		public void SetEnvironmentVariable(string env)
		{
			 _env = env;
			try
			{
				CBRContextManager.Load(_name, _env);
			}
			catch(Exception ex)
			{
				System.Console.WriteLine(ex.Message);
			}
		}

		public string GetEnvironmentVariable()
		{
			return _env;
		}

		private Case _problem = null;
		public void SetProblem(Case problem)
		{
			_problem = problem;

			_ctx = CBRContextManager.GetCBRContext(_name);
			if (_problem == null)
			{
				System.Console.WriteLine("problem is not set");
				return;
			}
			_ctx.SetCurrentCase(_problem);
		}
		public Case GetProblem()
		{
			return _problem;
		}

		public bool Startup()
		{
			if (_env == null 
				|| CBRContextManager.GetCBRContext(_name) == null)
			{
				System.Console.WriteLine("environment is not set or context is null");
				return false;
			}

			_ctx = CBRContextManager.GetCBRContext(_name);
			if (_problem == null)
			{
				System.Console.WriteLine("problem is not set");
				return false;
			}
			_ctx.SetCurrentCase(_problem);
			#region only for test
			if (Version.DEBUG)
			{
				System.Console.WriteLine("=====context detail=====");
				System.Console.WriteLine("Reasoning Engine startup successfully!");
				System.Console.WriteLine("problem case is:");
				for (int i = 0; i < _problem.GetFeatures().Count; i++)
				{
					Feature f = (Feature)_problem.GetFeatures()[i];
					System.Console.WriteLine("\t" + f.GetFeatureName() + ":" + f.GetFeatureValue());
				}
				System.Console.WriteLine("context is:");
				System.Console.WriteLine("case base\t" + _ctx.GetCaseBase().ToString());
				System.Console.WriteLine("case base input\t" + _ctx.GetCaseBaseInput().ToString());
				System.Console.WriteLine("case base input type\t" + _ctx.GetCaseBaseInputType().ToString());
				System.Console.WriteLine("case base url\t" + _ctx.GetCaseBaseURL().ToString());
				System.Console.WriteLine("case restore method\t" + _ctx.GetCaseRestoreMethod().ToString());
				System.Console.WriteLine("case retrieval method\t" + _ctx.GetCaseRetrievalMethod().ToString());
				System.Console.WriteLine("case reuse method\t" + _ctx.GetCaseReuseMethod().ToString());
				System.Console.WriteLine("case reuse strategy\t" + _ctx.GetCaseReuseStrategy().ToString());
				System.Console.WriteLine("case revise method\t" + _ctx.GetCaseReviseMethod().ToString());
				System.Console.WriteLine("current case\t" + _ctx.GetCurrentCase().ToString());
				System.Console.WriteLine("similarity\t" + _ctx.GetSimilarity().ToString());
				System.Console.WriteLine("similarity threhold\t" + _ctx.GetSimilarityThrehold().ToString());
				System.Console.WriteLine("=====end of context detail=====");
			}
			#endregion 
			return true;
		}

		public void Run()
		{
			//retrieve similarity case
			ICaseRetrieval caseRetrieval = CasePhaseFactory.GetCaseRetrieval();
			caseRetrieval.SetEnv(_name);
			ArrayList cases = caseRetrieval.RetrievalCases(_problem);
			//reuse case
			ICaseReuse caseReuse = CasePhaseFactory.GetCaseReuse();
			caseReuse.SetEnv(_name);
			Case solution = caseReuse.ReuseCase(cases);
			#region only for test
			if (Version.DEBUG && solution != null)
			{

				System.Console.WriteLine("=====case reuse result====");
				foreach(Feature f in solution.GetFeatures())
				{
					System.Console.WriteLine(f.GetFeatureName() + "\t" + f.GetFeatureValue());
				}
				System.Console.WriteLine("=====end of case reuse result=====");
			}
			#endregion
			//revise case
			ICaseRevise caseRevise = CasePhaseFactory.GetCaseRevise();
			caseRevise.SetEnv(_name);
			Case evaluateSolution = caseRevise.ReviseCase(solution);
			//restore case
			ICaseRestore caseRestore = CasePhaseFactory.GetCaseRestore();
			caseRestore.SetEnv(_name);
			caseRestore.RestoreCase(evaluateSolution);
		}

		public void Destroy()
		{
			 
		}

		#endregion
	}
}
