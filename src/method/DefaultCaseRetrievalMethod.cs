using System;

namespace org.opencbr.core.method
{
	using org.opencbr.core.context;
	using org.opencbr.core.casebase;
	using org.opencbr.core.express;
	using System.Collections;
	using org.opencbr.core.Similarity;
	/// <summary>
	/// DefaultCaseRetrievalMethod 的摘要说明。
	/// </summary>
	public class DefaultCaseRetrievalMethod:ICaseRetrievalMethod
	{
		private int _methodType = MethodType.TYPE_RETRIEVAL;
		private string _methodName = 
				"org.opencbr.core.method.DefaultCaseRetrievalMethod";

		public DefaultCaseRetrievalMethod()
		{
		}
		#region IMethod 成员

		private string _env;
		public void SetEnv(string env)
		{
			_env = env;
		}
		public string GetEnv()
		{
			return _env;
		}
		public object Execute(object obj)
		{
			if (_env == null)
				throw new ContextException("environment variable is not set");

			ICBRContext ctx =  CBRContextManager.GetCBRContext(_env);
			if (ctx == null)
			{
				//throw NoContextException
				throw new ContextException("not set the context");
			}

			ICaseBase caseBase = ctx.GetCaseBase();
			if (caseBase == null)
			{
				//throw exception
				throw new ContextException("not set casebase");
			}

			ArrayList cases = caseBase.GetCases((Case)obj);
			if (cases == null || cases.Count <= 0)
			{
				if (Version.DEBUG)
				{
					System.Console.WriteLine("not found cases matched");
				}
				return null;
			}

			//compute the similarity and sort by similarity ascending
			return ComputeSimilarity(cases, (Case)obj);
		}

		/// <summary>
		/// compute the similarity of case base's cases and problem case
		/// 
		/// </summary>
		/// <param name="cases"></param>
		/// <param name="problem"></param>
		/// <returns></returns>
		public ArrayList ComputeSimilarity(ArrayList cases, Case problem)
		{
			if (_env == null)
				throw new ContextException("environment variable is not set");

			ICBRContext ctx = CBRContextManager.GetCBRContext(_env);
			if (ctx == null)
			{
				throw new ContextException("not set context");
			}

			ISimilarity sim = (ISimilarity)ctx.GetSimilarity();
			if (sim == null)
			{
				throw new ContextException("similarity method is not set");
			}

			ArrayList stats = new ArrayList();
			double similarityThrehold = ctx.GetSimilarityThrehold();
			for (int i = 0; i < cases.Count; i++)
			{
				Case solution = (Case)cases[i];
				double similarity = sim.Compare(problem, solution);
				//continue if the similarity by comparing is lower than the 
				//similarity threhold in context setting
				if (similarity < similarityThrehold)
					continue;
				IStat s = StatFactory.newInstance();
				s.SetCBRCase(solution);
				s.SetCaseSimilarity(similarity);
				//bi-sort similarity
				if (stats.Count <= 0)
				{
					stats.Add(s);
					continue;
				}
				SortSimilarity(stats, s);
			}

			return stats;
		}

		/// <summary>
		/// sort by bi-sort algorithm
		/// </summary>
		/// <param name="stats"></param>
		/// <param name="s"></param>
		public void SortSimilarity(ArrayList stats, IStat stat)
		{
			int len = stats.Count;
			int low = 0;
			int high = len - 1;
			int mid = 0;
			double similarity = stat.GetCaseSimilarity();
			#region only for test
//			if (Version.DEBUG)
//			{
//				System.Console.WriteLine(" init stats:");
//				for(int i = 0; i < stats.Count; i++)
//				{
//					IStat s = (IStat)stats[i];
//					System.Console.WriteLine(s.GetCaseSimilarity());
//				}
//			}
			#endregion
			while (low <= high)
			{
				mid = (low + high) / 2;
				if (Version.DEBUG)
					System.Console.WriteLine("low:" + low 
						+"	mid:" + mid 
						+"	high:" + high);


				IStat s = (IStat)stats[mid];
				if (s.GetCaseSimilarity() > similarity)
					low = mid + 1;
				else
					high = mid - 1;
			}
			stats.Insert(high + 1, stat);

			#region only for test
			if (Version.DEBUG)
			{
				System.Console.WriteLine("result stats:");
				for(int i = 0; i < stats.Count; i++)
				{
					IStat s = (IStat)stats[i];
					System.Console.WriteLine(s.GetCaseSimilarity());
				}
			}
			#endregion
		}

		public void SetMethodType(int methodType)
		{
			_methodType = methodType;
		}

		public int GetMethodType()
		{
			return _methodType;
		}

		public void SetMethodName(string methodName)
		{
			_methodName = methodName;
		}

		public string GetMethodName()
		{
			return _methodName;
		}

		#endregion
	}
}
