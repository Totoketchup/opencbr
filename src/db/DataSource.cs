using System;

namespace org.opencbr.core.db
{
	/// <summary>
	/// DataSource 的摘要说明。
	/// </summary>
	public class DataSource
	{
		private int _dbType;
		private string _connectionString;
		private string _userName;
		private string _password;
		public void SetDbType(int dbType)
		{
			_dbType = dbType;
		}
		public void SetConnectionString(string connectionString)
		{
			_connectionString = connectionString;
		}
		public void SetUserName(string userName)
		{
			_userName = userName;
		}
		public void SetPassword(string password)
		{
			_password = password;
		} 
		public int GetDbType()
		{
			return _dbType;
		}
		public string GetConnectionString()
		{
			return _connectionString;
		}
		public string GetUserName()
		{
			return _userName;
		}
		public string GetPassword()
		{
			return _password;
		}

		private string _dictionaryTable = null;
		public void SetDictionaryTable(string dictionaryTable)
		{
			_dictionaryTable =dictionaryTable;
		}
		public string GetDictionaryTable()
		{
			return _dictionaryTable;
		}
		private string _dataTable = null;
		public void SetDataTable(string dataTable)
		{
			_dataTable = dataTable;
		}
		public string GetDataTable()
		{
			return _dataTable;
		}
		private string _caseID = null;
		public void SetCaseID(string caseID)
		{
			_caseID = caseID;
		}
		public string GetCaseID()
		{
			return _caseID;
		}
		private string _conditions = null;
		public void SetConditions(string conditions)
		{
			_conditions = conditions;
		}
		public string GetConditions()
		{
			return _conditions;
		}
	}
}
