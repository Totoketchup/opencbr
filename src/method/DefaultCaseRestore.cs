using System;

namespace org.opencbr.core.method
{
	using org.opencbr.core.express;
	using org.opencbr.core.context;
	/// <summary>
	/// DefaultCaseRestore ��ժҪ˵����
	/// </summary>
	public class DefaultCaseRestore:ICaseRestore
	{
		public DefaultCaseRestore()
		{
		}
		#region ICaseRestore ��Ա

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
			// TODO:  ��� DefaultCaseRestore.RestoreCase ʵ��
		}

		#endregion
	}
}
