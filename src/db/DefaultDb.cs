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
	using org.opencbr.core.express;
	using org.opencbr.core.context;
	/// <summary>
	/// Db 
	/// <author>xw_cn@163.com</author>
	/// <version>1.0</version>
	/// <creationdate>2006/0/5</creationdate>
	/// <modificationdate></modificationdate>>
	/// <history></history>
	/// </summary>
	public class DefaultDb:IDb
	{
		private string _url = null;
		private DataSource _dataSource = null;
		private DbHelper _helper = null;
		public DefaultDb(string url)
		{
			if (url != null 
				&& url.Length > 0 
				&& VerifyURL(url))
			{
				_url = url;
				_helper = new DbHelper();
			}
			else
			{
				throw new Exception("db url is invalid");
			}
		}
		/// <summary>
		/// verify the url string by pattern matching
		/// </summary>
		/// <param name="url"></param>
		/// <returns></returns>
		private bool VerifyURL(string url)
		{
			return true;
		}
		public string GetURL()
		{
			return _url; 
		}
		public void SetURL(string url)
		{
			_url = url;
		}
		#region IDb ³ÉÔ±

		public ArrayList GetCases()
		{
			if (_dataSource == null)
				return null;

			ArrayList cases = null;
			try
			{
				cases = DatabaseFactory.newInstance(_dataSource).GetCases();
			}
			catch(Exception e)
			{
				System.Console.WriteLine(e.Message);
				return null;
			}
			
			return cases;
		}

		public void StoreCases(ArrayList cases)
		{			
		}

		private string _env = null;
		public void SetEnv(string env)
		{
			_env = env;
			_helper.SetEnv(_env);
			_dataSource = _helper.GetDataSource(_url);
		}
		public string GetEnv()
		{
			return _env;
		}

		#endregion
		public class DbHelper
		{
			private static readonly string TOKEN_DATASOURCE = "$DataSource";
			private static readonly string TOKEN_DICTIONARY_TABLE = "$DictionaryTable";
			private static readonly string TOKEN_DATA_TABLE = "$DataTable";
			private static readonly string TOKEN_DB_TYPE = "$DbType";
			private static readonly string TOKEN_CASE_ID = "$CaseID";
			private static readonly string TOKEN_CONDITIONS = "$Conditions";
			private static readonly string TOKEN_ACCESS = "Access";
			private static readonly string TOKEN_MSSQL = "Mssql";
			private static readonly string TOKEN_MYSQL = "Mysql";
			private static readonly string TOKEN_ORACLE = "Oracle";
			private static readonly string TOKEN_SHARP = "#";
			private string _env = null;
			public DbHelper()
			{
			}
			public void SetEnv(string env)
			{
				_env = env;
			}
			public  DataSource GetDataSource(string url)
			{
				char[] separator = new char[1];
				DataSource ds = new DataSource();
				separator[0] = '&';

				string[] tokens = url.Trim().Split(separator);
				if (tokens != null && tokens.Length > 0)
				{
					foreach(string s in tokens)
					{

						if (s.Trim().StartsWith(TOKEN_DATASOURCE))
						{
							ds.SetConnectionString( 
								s.Trim().Substring(TOKEN_DATASOURCE.Length + 1));
						}
						if (s.Trim().StartsWith(TOKEN_DICTIONARY_TABLE))
						{
							ds.SetDictionaryTable(s.Trim().Substring(
								TOKEN_DICTIONARY_TABLE.Length + 1));
						}
						if (s.Trim().StartsWith(TOKEN_CONDITIONS))
						{
							ds.SetConditions(
								ParseConditions(s.Trim().Substring(
								TOKEN_CONDITIONS.Length + 1)));
						}
						if (s.Trim().StartsWith(TOKEN_DATA_TABLE))
						{
							 ds.SetDataTable(s.Trim().Substring(
								 TOKEN_DATA_TABLE.Length + 1));
						}
						if (s.Trim().StartsWith(TOKEN_CASE_ID))
						{
							ds.SetCaseID(s.Trim().Substring(
								TOKEN_CASE_ID.Length + 1));
						}
						if (s.Trim().StartsWith(TOKEN_DB_TYPE))
						{
							string t = s.Trim().Substring(TOKEN_DB_TYPE.Length + 1);
							if (t.Trim().Equals(TOKEN_ACCESS))
							{
								ds.SetDbType(DbType.TYPE_ACCESS);
							}
							else if (t.Trim().Equals(TOKEN_MSSQL))
							{
								ds.SetDbType(DbType.TYPE_MSSQL);
							}
							else if (t.Trim().Equals(TOKEN_MYSQL))
							{
								ds.SetDbType(DbType.TYPE_MYSQL);
							}
							else if (t.Trim().Equals(TOKEN_ORACLE))
							{
								ds.SetDbType(DbType.TYPE_ORACLE);
							}
						}

					}
				}

				return ds;
			}

			public string ParseConditions(string src)
			{
				if (src == null 
					|| src.Trim().Length <= 0)
				{
					return null;
				}
				string dst = src;
				ICBRContext ctx = CBRContextManager.GetCBRContext(_env);
				Case c = ctx.GetCurrentCase();

				ArrayList features = c.GetFeatures();
				foreach(Feature f in features)
				{
					string name = TOKEN_SHARP + f.GetFeatureName() + TOKEN_SHARP;
					if (f.GetFeatureValue() != null)
						dst = dst.Replace(name, f.GetFeatureValue().ToString());
				}
				return dst;
			}
		}
	}
}
