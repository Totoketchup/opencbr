using System;

namespace org.opencbr.core.method
{	
	using org.opencbr.core.express;
	using org.opencbr.core.context;
	/// <summary>
	/// DefaultRevise 的摘要说明。
	/// </summary>
	public class DefaultCaseRevise:ICaseRevise
	{
		public DefaultCaseRevise()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region ICaseRevise 成员

		private string _env = null;
		public void SetEnv(string env)
		{
			_env = env;
		}
		public string GetEnv()
		{
			return _env;
		}

		public Case ReviseCase(Case solution)
		{
			ICBRContext ctx = CBRContextManager.GetCBRContext(_env);
			if (ctx == null)
			{
				throw new ContextException("context is not set");
			}
			ctx.SetSolutionCase(solution);

			return solution;
		}
		#endregion
	}
}
