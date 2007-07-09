using System;

namespace org.opencbr.core.casebase
{
	using System.Collections;
	using org.opencbr.core.express;
	using org.opencbr.core.context;
	/// <summary>
	/// ICaseBase 的摘要说明。
	/// </summary>
	public interface ICaseBase:IEnv
	{
		ArrayList GetCases(Case c);
		void RestoreCase(Case c);
	}
}
