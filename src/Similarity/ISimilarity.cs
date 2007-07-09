using System;

namespace org.opencbr.core.Similarity
{
	using org.opencbr.core.express;
	using org.opencbr.core.context;
	/// <summary>
	/// ISimilarity ��ժҪ˵����
	/// </summary>
	public interface ISimilarity:IEnv
	{
		double Compare(Case problem, Case solution);
	}
}
