using System;

namespace org.opencbr.core.Similarity
{
	using org.opencbr.core.express;
	using org.opencbr.core.context;
	/// <summary>
	/// ISimilarity 的摘要说明。
	/// </summary>
	public interface ISimilarity:IEnv
	{
		double Compare(Case problem, Case solution);
	}
}
