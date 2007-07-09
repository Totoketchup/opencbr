using System;

namespace org.opencbr.core.method
{
	/// <summary>
	/// DefaultCaseReviseMethod ��ժҪ˵����
	/// </summary>
	public class DefaultCaseReviseMethod:ICaseReviseMethod
	{
		public DefaultCaseReviseMethod()
		{
			
		}
		#region IMethod ��Ա

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
			return obj;
		}

		public void SetMethodType(int methodType)
		{
			// TODO:  ��� DefaultCaseReviseMethod.SetMethodType ʵ��
		}

		public int GetMethodType()
		{
			// TODO:  ��� DefaultCaseReviseMethod.GetMethodType ʵ��
			return 0;
		}

		public void SetMethodName(string methodName)
		{
			// TODO:  ��� DefaultCaseReviseMethod.SetMethodName ʵ��
		}

		public string GetMethodName()
		{
			// TODO:  ��� DefaultCaseReviseMethod.GetMethodName ʵ��
			return null;
		}

		#endregion
	}
}
