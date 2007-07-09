using System;

namespace org.opencbr.core.method
{
	/// <summary>
	/// DefaultCaseReviseMethod 的摘要说明。
	/// </summary>
	public class DefaultCaseReviseMethod:ICaseReviseMethod
	{
		public DefaultCaseReviseMethod()
		{
			
		}
		#region IMethod 成员

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
			// TODO:  添加 DefaultCaseReviseMethod.SetMethodType 实现
		}

		public int GetMethodType()
		{
			// TODO:  添加 DefaultCaseReviseMethod.GetMethodType 实现
			return 0;
		}

		public void SetMethodName(string methodName)
		{
			// TODO:  添加 DefaultCaseReviseMethod.SetMethodName 实现
		}

		public string GetMethodName()
		{
			// TODO:  添加 DefaultCaseReviseMethod.GetMethodName 实现
			return null;
		}

		#endregion
	}
}
