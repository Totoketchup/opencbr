using System;

namespace org.opencbr.core.casebase
{
	using org.opencbr.core.context;
	using org.opencbr.core.express;
	using org.opencbr.core.db;
	using System.Collections;

	/// <summary>
	/// DefaultCaseBase 的摘要说明。
	/// </summary>
	public class DefaultCaseBase:ICaseBase
	{
		public DefaultCaseBase()
		{
		}
		#region ICaseBase 成员

		private string _env;
		public void SetEnv(string env)
		{
			_env = env;
		}
		public string GetEnv()
		{
			return _env;
		}

		public ArrayList GetCases(Case c)
		{
			ArrayList cases = null;

			if (_env == null)
				throw new ContextException("environment variable is not set");

			ICBRContext ctx = CBRContextManager.GetCBRContext(_env);
			if (ctx == null)
			{
				throw new ContextException("not set the context");
			}
			
			int type = ctx.GetCaseBaseInputType();

			if (type == CaseBaseInputType.TYPE_DB
				|| type == CaseBaseInputType.TYPE_FILE
				)
			{
				ICaseBaseInput input = (ICaseBaseInput)ctx.GetCaseBaseInput();
				if (input == null)
				{
					throw new ContextException("not set the database input");
				}
				cases = input.GetCases(c);
			}
			else
			{
				throw new ContextException("not support case base type");
			}
			return cases;
		}

		public void RestoreCase(Case c)
		{
		}

		#endregion
	}
}
