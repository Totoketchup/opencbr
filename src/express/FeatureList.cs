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
	using System.Collections;
	/// <summary>
	/// FeatureList 
	/// <author>xw_cn@163.com</author>
	/// <version>1.0</version>
	/// <creationdate>2005/11/15</creationdate>
	/// <modificationdate></modificationdate>>
	/// <history></history>
	/// </summary>
	public class FeatureList
	{
		private ArrayList _features;
		public FeatureList()
		{
			_features = new ArrayList();
		}
		public FeatureList(ArrayList features)
		{
			if (features != null)
				_features = features;
			else
				_features = new ArrayList();
		}
		public void AddFeature(Feature feature)
		{
			_features.Add(feature);
		}
		/// <summary>
		/// Remove feature
		/// </summary>
		/// <param name="name"></param>
		public void RemoveFeature(string name)
		{
			for (int i = 0; i < _features.Count; i++)
			{
				Feature f = (Feature)_features[i];
				if (f.GetFeatureName().CompareTo(name) == 0)
				{
					_features.RemoveAt(i);
					return;
				}
			}
		}
		/// <summary>
		/// Modify feature elements
		/// </summary>
		/// <param name="feature"></param>
		public void ModifyFeature(Feature feature)
		{
			for (int i = 0; i < _features.Count; i++)
			{
				Feature f = (Feature)_features[i];
				string oldName = feature.GetFeatureName();
				if (f.GetFeatureName().CompareTo(oldName) == 0)
				{
					_features.RemoveAt(i);
					_features.Add(feature);
				}
			}
		}
		public Feature GetFeature(string name)
		{
			for (int i = 0; i < _features.Count; i++)
			{
				Feature f = (Feature)_features[i];
				if (f.GetFeatureName().CompareTo(name) == 0)
				{
					return f;
				}
			}
			return null;
		}
		public ArrayList GetFeatures()
		{
			return _features;
		}
	}
}
