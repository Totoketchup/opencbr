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

namespace org.opencbr.core.file
{
	using System.IO;
	using System.Collections;
	using org.opencbr.core.express;
	/// <summary>
	/// DefaultOCBRFile 
	/// <author>xw_cn@163.com</author>
	/// <version>1.0</version>
	/// <creationdate>2005/11/31</creationdate>
	/// <modificationdate></modificationdate>>
	/// <history></history>
	/// </summary>
	public class DefaultOCBRFile:IOCBRFile
	{
		private string _path = null;
		private string _caseName = null;
		private string[] _featureNames = null;
		private ArrayList _cases = null;
		private ArrayList _features = null;
		private int _status = 0;
		private static readonly int STATUS_COMMENT = 1;
		private static readonly int STATUS_FEATURE = 2;
		private static readonly int STATUS_CASE = 3;
		private static readonly int STATUS_DATA = 4;
		private static int _caseID = 1;
		public DefaultOCBRFile()
		{
			_cases = new ArrayList();
			_features = new ArrayList();
		}
		public DefaultOCBRFile(string path)
		{
			_path = path;
			_cases = new ArrayList();
			_features = new ArrayList();
		}
		public ArrayList GetCases()
		{
			Read();
			return _cases;
		}
		public void StoreCases(ArrayList cases)
		{
		}
		private void Read()
		{
			System.IO.StreamReader reader = File.OpenText(_path);
			if (reader == null)
			{
				System.Console.WriteLine("file open failed " + _path);
				return;
			}

			while (true)
			{
				string s = reader.ReadLine();
				if (s == null)
					break;
				if (s.StartsWith(Token.TOKEN_CASE))
				{
					_status = STATUS_CASE;
					ParseCase(s);
				}
				else if (s.StartsWith(Token.TOKEN_FEATURE))
				{
					_status = STATUS_FEATURE;
					ParseFeature(s);
				}
				else if (s.StartsWith(Token.TOKEN_DATA))
				{
					_status = STATUS_DATA;
				}
				else if (s.StartsWith(Token.TOKEN_COMMENT))
				{
					//skip
					_status = STATUS_COMMENT;
				}
				else
				{
					ParseData(s);
				}
			}
			reader.Close();
		}
		private void ParseCase(string token)
		{
			string t = token.Substring(Token.TOKEN_CASE.Length).Trim();
			int pstart = t.IndexOf("(",0);
			int pend = t.IndexOf(")", pstart);
			_caseName = t.Substring(0, pstart).Trim();

			string features = t.Substring(pstart + 1, pend - pstart - 1).Trim();
			char[] separator = new char[1];
			separator[0] = ',';
			_featureNames = features.Split(separator);
		}
		private void ParseFeature(string token)
		{
			string t = token.Substring(Token.TOKEN_FEATURE.Length).Trim();
			int pstart = t.IndexOf("(",0);
			int pend = t.IndexOf(")", pstart);
			string name = t.Substring(0, pstart).Trim();

			string s = t.Substring(pstart + 1, pend - pstart - 1).Trim();
			char[] separator = new char[1];
			separator[0] = ',';
			string[] featureProperties = s.Split(separator);
			if (featureProperties == null || featureProperties.Length <= 0)
			{
				return;
			}

			if (featureProperties.Length != 4)
			{
				if (Version.DEBUG)
					System.Console.WriteLine(
						"parse file error. feature field number is not equal to 4");
				return;
			}

			//construct feature
			string type = featureProperties[0];
			int typeValue = Token.GetType(type);

			string isKey = featureProperties[1];
			bool isKeyValue = false;
			if (isKey.Equals(Token.TOKEN_BOOL_TRUE))
			{
				isKeyValue = true;
			}

			string isIndex = featureProperties[2];
			bool isIndexValue = false;
			if (isIndex.Equals(Token.TOKEN_BOOL_TRUE))
			{
				isIndexValue = true;
			}

			string weight = featureProperties[3];
			double weightValue = Convert.ToDouble(weight);

			Feature f = new Feature(name, typeValue, null, weightValue,
									isKeyValue, isIndexValue);
			_features.Add(f);

		}
		private void ParseData(string token)
		{
			if (VerifyFile() == false)
			{
				if (Version.DEBUG)
				{
					System.Console.WriteLine("file verify error");
				}
				return;
			}

			char[] separator = new char[1];
			separator[0] = ',';
			string[] values = token.Trim().Split(separator);
			if (values != null 
				&& values.Length > 0 
				&&values.Length == _featureNames.Length)
			{
				CreateCase(values);
			}
		}
		private void CreateCase(string[] values)
		{
			Case c = CaseFactory.CreateInstance(_caseName);
			c.SetCaseID(_caseID);
			for (int i = 0; i < _featureNames.Length; i++)
			{
				string name = _featureNames[i];
				string v = values[i];
				Feature f = Find(name);
				if (f != null)
				{
					if (f.GetFeatureType() == FeatureType.TYPE_FEATURE_BOOL)
					{
					}
					if (f.GetFeatureType() == FeatureType.TYPE_FEATURE_FLOAT)
					{
						double fValue = Convert.ToDouble(v);
						c.AddFeature(f.GetFeatureName(), f.GetFeatureType(),
							fValue, f.GetWeight(), f.GetIsKey(),
							f.GetIsIndex());
					}
					if (f.GetFeatureType() == FeatureType.TYPE_FEATURE_IMAGE)
					{
					}
					if (f.GetFeatureType() == FeatureType.TYPE_FEATURE_INT)
					{
					}
					if (f.GetFeatureType() == FeatureType.TYPE_FEATURE_MSTRING)
					{
					}
					if (f.GetFeatureType() == FeatureType.TYPE_FEATURE_STRING)
					{
					}
					if (f.GetFeatureType() == FeatureType.TYPE_FEATURE_UNDEFINED)
					{
					}
				}
			}
			_cases.Add(c);
			_caseID++;
		}
		private Feature Find(string featureName)
		{
			for (int i = 0; i < _features.Count; i++)
			{
				Feature f = (Feature)_features[i];
				if (f.GetFeatureName().Equals(featureName))
				{
					return f;
				}
			}
			return null;
		}
		private bool VerifyFile()
		{
			return true;
		}

		public void SetFilePath(string path)
		{
			_path = path;
		}

		public string GetFilePath()
		{
			return _path;
		}
		}
}
