using System;

namespace org.opencbr.core.context
{
	using org.opencbr.core.Similarity;
	using org.opencbr.core.express;
	using org.opencbr.core.file;
	using org.opencbr.core.method;
	using org.opencbr.core.strategy;
	using org.opencbr.core.casebase;
	using System.Collections;
	/// <summary>
	/// DefaultCBRContext
	/// </summary>
	public class DefaultCBRContext:ICBRContext
	{
		private ISimilarity _similarity = null;
		private IMethod _caseRetrievalMethod = null;
		private IMethod _caseReuseMethod = null;
		private IMethod _caseReviseMethod = null;
		private IMethod _caseRestoreMethod = null;
		private ICaseReuseStrategy _caseReuseStrategy = null;
		private int _caseBaseInputType;
		private ICaseBaseInput _caseBaseInput = null;
		private ICaseBase _caseBase = null;
		private double _similarityThrehold = 0;
		private Case _problem = null;
		private string _url = null;
		public DefaultCBRContext()
		{

		}
		#region ICBRContext ≥…‘±

		public void SetSimilarity(ISimilarity similarity)
		{
			_similarity = similarity;
		}

		public ISimilarity GetSimilarity()
		{
			return _similarity;
		}

		public IMethod GetCaseRetrievalMethod()
		{
			return _caseRetrievalMethod;
		}

		public void SetCaseRetrievalMethod(IMethod method)
		{
			_caseRetrievalMethod = method;
		}

		public IMethod GetCaseReuseMethod()
		{
			return _caseReuseMethod;
		}

		public void SetCaseReuseMethod(IMethod method)
		{
			_caseReuseMethod = method;
		}
		public IMethod GetCaseReviseMethod()
		{
			return _caseReviseMethod;
		}
		public void SetCaseReviseMethod(IMethod method)
		{
			_caseReviseMethod = method;
		}

		public IMethod GetCaseRestoreMethod()
		{
			return _caseRestoreMethod;
		}
		public void SetCaseRestoreMethod(IMethod method)
		{
			_caseRestoreMethod = method;
		}

		public ICaseReuseStrategy GetCaseReuseStrategy()
		{
			return _caseReuseStrategy;
		}

		public void SetCaseReuseStrategy(ICaseReuseStrategy strategy)
		{
			_caseReuseStrategy = strategy;
		}

		public void SetCaseBaseInputType(int type)
		{
			_caseBaseInputType = type;
		}

		public int GetCaseBaseInputType()
		{
			return _caseBaseInputType;
		}

		public void SetCaseBaseInput(ICaseBaseInput input)
		{
			_caseBaseInput = input;
		}

		public ICaseBaseInput GetCaseBaseInput()
		{
			return _caseBaseInput;
		}

		public void SetCaseBase(ICaseBase caseBase)
		{
			_caseBase = caseBase;
		}

		public ICaseBase GetCaseBase()
		{
			return _caseBase;
		}

		public void SetCaseBaseURL(string url)
		{
			_url = url;
		}
		public string GetCaseBaseURL()
		{
			return _url;
		}
		public void SetSimilarityThrehold(double similarityThrehold)
		{
			_similarityThrehold = similarityThrehold;
		}

		public double GetSimilarityThrehold()
		{
			return _similarityThrehold;
		}

		public void SetCurrentCase(Case problem)
		{
			_problem = problem;
		}

		public Case GetCurrentCase()
		{
			return _problem;
		}
		private Case _solution = null;
		public void SetSolutionCase(Case solution)
		{
			_solution = solution;
		}
		public Case GetSolutionCase()
		{
			return _solution;
		}

		private ArrayList _cases = null;
		public void SetMatchedCase(ArrayList cases)
		{
			_cases = cases;
		}
		public ArrayList GetMatchedCase()
		{
			return _cases;
		}


		private Case _reuseCase = null;
		public void SetReuseCase(Case reuseCase)
		{
			_reuseCase = reuseCase;
		}
		public Case GetReuseCase()
		{
			return _reuseCase;
		}

		#endregion
	}
}
