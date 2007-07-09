using System;

namespace org.opencbr.core.db
{
	using org.opencbr.core.express;
	using System.Collections;
	using System.Data.OleDb;
	/// <summary>
	/// AccessDatabase 的摘要说明。
	/// </summary>
	public class AccessDatabase:IDb
	{
		private DataSource _dataSource = null;

		public AccessDatabase(DataSource dataSource)
		{
			_dataSource = dataSource;
		}
		public ArrayList GetCases()
		{
			string dictionaryTable = _dataSource.GetDictionaryTable();
			string dataTable = _dataSource.GetDataTable();
			string caseID = _dataSource.GetCaseID();

			return DbHelper.GetCases(_dataSource, dictionaryTable, dataTable, caseID);
		}

		public void StoreCases(ArrayList cases)
		{			
		}
		public class DbHelper
		{
			private static readonly string FIELD_FEATURENAME = "FeatureName";
			private static readonly string FIELD_FEATURETYPE ="FeatureType";
			private static readonly string FIELD_KEY = "FeatureKey";
			private static readonly string FIELD_INDEX = "FeatureIndex";
			private static readonly string FIELD_WEIGHT = "FeatureWeight";
			private static readonly string FIELD_CASEID = "CaseID";
			private static OleDbDataReader ExecuteQuery(OleDbCommand cmd, string sql)
			{
				cmd.CommandText = sql;
				OleDbDataReader reader = cmd.ExecuteReader();

				return reader;
			}
			public static ArrayList GetCases(DataSource ds,
				string dictionaryTable,
				string dataTable, string caseID)
			{
				string sql = "select * from " + dictionaryTable 
					+ "	where " + FIELD_CASEID + "='" 
					+ caseID + "'";
				try
				{

					//read case structure
					Case c = CaseFactory.CreateInstance(caseID);
					OleDbConnection conn = new OleDbConnection(ds.GetConnectionString());
					OleDbCommand cmd = conn.CreateCommand();
					conn.Open();

					OleDbDataReader reader = ExecuteQuery(cmd, sql);
					while (reader.Read())
					{
						string name = reader[FIELD_FEATURENAME].ToString();
						string type = reader[FIELD_FEATURETYPE].ToString();
						string key = reader[FIELD_KEY].ToString();
						string index = reader[FIELD_INDEX].ToString();
						string weight = reader[FIELD_WEIGHT].ToString();
						c.AddFeature(name, GetType(type), null, 
							Convert.ToDouble(weight),GetBOOL(key),GetBOOL(index));
					}
					reader.Close();
				
					//read cases
					ArrayList features = c.GetFeatures();
					ArrayList cases = new ArrayList();
					if (ds.GetConditions() != null)
						sql = "select * from " + dataTable + " where " + FIELD_CASEID + "='"
							+ caseID + "' and " + ds.GetConditions();
					else
						sql = "select * from " + dataTable + " where " + FIELD_CASEID + "='"
							+ caseID + "'";

					reader = ExecuteQuery(cmd, sql);

					while (reader.Read())
					{
						Case theCase = CaseFactory.CreateInstance(caseID);
						foreach(Feature f in features)
						{
							string featureName = f.GetFeatureName();
							object featureValue = reader[featureName];
							theCase.AddFeature(f.GetFeatureName(), f.GetFeatureType(),
								featureValue, f.GetWeight(), 
								f.GetIsKey(), f.GetIsIndex());
						}
						cases.Add(theCase);
					}
					reader.Close();
					cmd.Cancel();
					conn.Close();

					return cases;

				}
				catch(Exception e)
				{
					System.Console.WriteLine(e.Message);
					return null;
				}
				
			}
			private static int GetType(string s)
			{
				if (s.Equals(Token.TYPE_BOOL))
				{
					return FeatureType.TYPE_FEATURE_BOOL;
				}
				else if (s.Equals(Token.TYPE_FLOAT))
				{
					return FeatureType.TYPE_FEATURE_FLOAT;
				}
				else if (s.Equals(Token.TYPE_IMAGE))
				{
					return FeatureType.TYPE_FEATURE_IMAGE;
				}
				else if (s.Equals(Token.TYPE_INT))
				{
					return FeatureType.TYPE_FEATURE_INT;
				}
				else if (s.Equals(Token.TYPE_MSTRING))
				{
					return FeatureType.TYPE_FEATURE_MSTRING;
				}
				else if (s.Equals(Token.TYPE_STRING))
				{
					return FeatureType.TYPE_FEATURE_STRING;
				}
				else  
				{
					return FeatureType.TYPE_FEATURE_UNDEFINED;
				}
			}
			private static bool GetBOOL(string s)
			{
				if (s.Equals(Token.TOKEN_TRUE))
				{
					return true;
				}
				return false;
			}
		}
		#region IDb 成员

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
