using System;

namespace org.opencbr.core.method
{
	using org.opencbr.core.express;
	using org.opencbr.core.context;
	using System.Collections;
	/// <summary>
	/// DefaultCaseReuse 的摘要说明。
	/// </summary>
	public class DefaultCaseReuse:ICaseReuse
	{
		public DefaultCaseReuse()
		{
		}
		#region ICaseReuse 成员

		private string _env = null;
		public void SetEnv(string env)
		{
			_env = env;
		}
		public string GetEnv()
		{
			return _env;
		}
		public Case ReuseCase(ArrayList stats)
		{
			if (_env == null)
				throw new ContextException("environment variable is not set");

			ICBRContext ctx = CBRContextManager.GetCBRContext(_env);
			if (ctx == null)
			{
				throw new ContextException("context is not set");
			}
			IMethod m = ctx.GetCaseReuseMethod();
			if (m == null)
			{
				throw new ContextException(
					"context's GetCaseRetrievalMethod is not set");
			}
			ctx.SetReuseCase((Case)m.Execute(stats));


			return (Case)m.Execute(stats);
		}
		#endregion
	}
}
