#region copyright (C) xia wu,pian jin xiang
/************************************************************************************
' Copyright (C) 2005 xia wu,pian jin xiang 
'
' This software is provided 'as-is', without any express or implied warranty. In no 
' event will the authors be held liable for any damages arising from the use of this 
' software.
' 
' Permission is granted to anyone to use this software for any purpose, including 
' commercial applications, and to alter it and redistribute it freely, subject to the 
' following restrictions:
'
' 1. The origin of this software must not be misrepresented; you must not claim that 
' you wrote the original software. If you use this software in a product, an 
' acknowledgment (see the following) in the product documentation is required.
'
' 2. Altered source versions must be plainly marked as such, and must not be 
' misrepresented as being the original software.
'
' 3. This notice may not be removed or altered from any source distribution.
'
'***********************************************************************************/
#endregion
using System;

namespace org.opencbr.core.casebase
{
	using org.opencbr.core.express;
	using System.Collections;
	using org.opencbr.core.context;
	using org.opencbr.core.file;
	using org.opencbr.core.db;

	/// <summary>
	/// DefaultCaseBaseInput 
	/// <author>xw_cn@163.com</author>
	/// <version>1.0</version>
	/// <creationdate>2006/0/3</creationdate>
	/// <modificationdate></modificationdate>>
	/// <history></history>
	/// </summary>
	public class DefaultCaseBaseInput:ICaseBaseInput
	{
		public DefaultCaseBaseInput()
		{
		}
		#region ICaseBaseInput 成员

		/// <summary>
		/// find case from case base
		/// return null if not suitable case
		/// otherwise retrurn case list
		/// note that only *.ocbr and db type are supported
		/// </summary>
		/// <param name="c"></param>
		/// <returns></returns>
		public ArrayList GetCases(Case c)
		{
			if (_env == null)
			{
				System.Console.WriteLine("environment is not set");
				return null;
			}

			ICBRContext ctx = CBRContextManager.GetCBRContext(_env);
			if (ctx == null)
			{
				throw new ContextException("context is null");
			}

			int type = ctx.GetCaseBaseInputType();
			string url = ctx.GetCaseBaseURL();

			if (type == CaseBaseInputType.TYPE_FILE)
			{
				IOCBRFile file = OCBRFileFactory.newInstance(url);
				return file.GetCases();
			}
			else if (type == CaseBaseInputType.TYPE_DB)
			{
				IDb db = DbFactory.newInstance(url);
				db.SetEnv(_env);//set the conditions rules

				return db.GetCases();
			}
			else
			{
				System.Console.WriteLine("input case base type unsupported");
			}
			return null;
		}

		public void StoreCases(ArrayList cases)
		{
			 
		}

		#endregion

		#region IEnv 成员

		private string _env = null;
		public void SetEnv(string env)
		{
			_env = env;
		}

		public string GetEnv()
		{
			
			return _env;
		}

		#endregion
	}
}
