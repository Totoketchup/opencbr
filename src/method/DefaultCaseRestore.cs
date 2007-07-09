using System;

namespace org.opencbr.core.method
{
	using org.opencbr.core.express;
	using org.opencbr.core.context;
	/// <summary>
	/// DefaultCaseRestore 的摘要说明。
	/// </summary>
	public class DefaultCaseRestore:ICaseRestore
	{
		public DefaultCaseRestore()
		{
		}
		#region ICaseRestore 成员

		private string _env = null;
		public void SetEnv(string env)
		{
			_env = env;
		}
		public string GetEnv()
		{
			return _env;
		}
		public void RestoreCase(Case solution)
		{
			// TODO:  添加 DefaultCaseRestore.RestoreCase 实现
		}

		#endregion
	}
}
