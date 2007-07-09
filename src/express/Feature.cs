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

namespace org.opencbr.core.express
{
	/// <summary>
	/// Feature 
	/// </summary>
	/// <author>xw_cn@163.com</author>
	/// <version>1.0</version>
	/// <creationdate>2005-12-15</creationdate>
	/// <modificationdate></modificationdate>>
	/// <history></history>
	/// 
	public class Feature
	{
		/// <summary>
		/// contains feature value
		/// </summary>
		/// <since>1.0</since>
		private object _featureValue;
		/// <summary>
		/// contains feature type
		/// </summary>
		/// <since>1.0</since>
		private int _featureType;
		/// <summary>
		/// contains feature name
		/// </summary>
		/// <since>1.0</since>
		private string _featureName;
		/// <summary>
		/// contains whether is a key feature of case
		/// </summary>
		private bool _isKey;
		/// <summary>
		/// contains whether is a index of case
		/// </summary>
		private bool _isIndex;
		/// <summary>
		/// contains the weight of feature in case
		/// </summary>
		private double _weight;
		public Feature()
		{
		}
		public Feature(string featureName, int featureType,
			object featureValue, double weight,
			bool isKey, bool isIndex
			)
		{
			_featureName = featureName;
			_featureType = featureType;
			_featureValue = featureValue;
			_weight = weight;
			_isKey = isKey;
			_isIndex = isIndex;
		}
		public void SetFeatureName(string featureName)
		{
			_featureName = featureName;
		}
		public void SetFeatureType(int featureType)
		{
			_featureType = featureType;
		}
		public void SetFeatureValue(object featureValue)
		{
			_featureValue = featureValue;
		}
		public void SetWeight(double weight)
		{
			_weight = weight;
		}
		public string GetFeatureName()
		{
			return _featureName;
		}
		public int GetFeatureType()
		{
			return _featureType;
		}
		public double GetWeight()
		{
			return _weight;
		}
		public object GetFeatureValue()
		{
			return _featureValue;
		}
		public void SetIsKey(bool isKey)
		{
			_isKey = isKey;
		}
		public bool GetIsKey()
		{
			return _isKey;
		}
		public void SetIsIndex(bool isIndex)
		{
			_isIndex = isIndex;
		}
		public bool GetIsIndex()
		{
			return _isIndex;
		}
	}
}
