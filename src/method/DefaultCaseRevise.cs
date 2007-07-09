using System;

namespace org.opencbr.core.method
{	
	using org.opencbr.core.express;
	using org.opencbr.core.context;
	/// <summary>
	/// DefaultRevise ��ժҪ˵����
	/// </summary>
	public class DefaultCaseRevise:ICaseRevise
	{
		public DefaultCaseRevise()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#region ICaseRevise ��Ա

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
