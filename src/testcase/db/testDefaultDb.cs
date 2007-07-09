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

namespace org.opencbr.core.testcase.db
{
	using System.Collections;
	using org.opencbr.core.express;
	using NUnit.Framework;
	using org.opencbr.core.db;
	/// <summary>
	/// testDefaultDb 
	/// <author>xw_cn@163.com</author>
	/// <version>1.0</version>
	/// <creationdate>2006/0/5</creationdate>
	/// <modificationdate></modificationdate>>
	/// <history></history>
	/// </summary>
	[TestFixture]
	public class testDefaultDb
	{
		DefaultDb _db = null;
		public testDefaultDb()
		{
		}
		[SetUp]public void Init()
		{
			string url = 
@"$CaseID=cooling & $DbType=Access & $DataSource=Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\xw\ÏîÄ¿\topics\org.opencbr.core\db\casebase.mdb & $DictionaryTable=tbl_dic & $DataTable=tbl_data";
			_db = new DefaultDb(url);

		}
		[Test]public void testDbHelper()
		{
			ArrayList cases = _db.GetCases();
			foreach(Case c in cases)
			{
				System.Console.WriteLine(c.GetCaseID());
				foreach(Feature f in c.GetFeatures())
				{
					System.Console.WriteLine("\t " + f.GetFeatureName() 
						+ "\t" + f.GetFeatureValue());
				}
			}
		}
	}
}
