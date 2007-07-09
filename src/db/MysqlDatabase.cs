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

namespace org.opencbr.core.db
{
	using System.Collections;
	/// <summary>
	/// MysqlDatabase 
	/// <author>xw_cn@163.com</author>
	/// <version>1.0</version>
	/// <creationdate>2006/0/5</creationdate>
	/// <modificationdate></modificationdate>>
	/// <history></history>
	/// </summary>
	public class MysqlDatabase:IDb
	{
		private DataSource _dataSource = null;
		public MysqlDatabase(DataSource dataSource)
		{
			_dataSource = dataSource;
		}
		public ArrayList GetCases()
		{
			return null;
		}

		public void StoreCases(ArrayList cases)
		{			
		}
		#region IDb 成员

		public void SetEnv(string env)
		{
			// TODO:  添加 MysqlDatabase.SetEnv 实现
		}

		public string GetEnv()
		{
			// TODO:  添加 MysqlDatabase.GetEnv 实现
			return null;
		}

		#endregion
	}
}
