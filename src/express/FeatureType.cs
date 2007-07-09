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
#region Version Description
#endregion
using System;

namespace org.opencbr.core.express
{
	/// <summary>
	/// Feature type defintion 
	/// supporting the follow type:
	/// TYPE_FEATURE_BOOL
	/// TYPE_FEATURE_INT
	/// TYPE_FEATURE_STRING
	/// TYPE_FEATURE_FLOAT
	/// TYPE_FEATURE_MUTISTRING
	/// TYPE_UNDEFINED
	/// </summary>
	/// <author>xw_cn@163.com</author>
	/// <version>1.0</version>
	/// <creationdate>2005-12-15</creationdate>
	/// <modificationdate></modificationdate>>
	/// <history></history>
	public class FeatureType
	{
		/// <summary>
		/// The feature is of type bool
		/// </summary>
		/// <since>1.0</since>
		/// 
		public static readonly int TYPE_FEATURE_BOOL = 1;
		/// <summary>
		/// The feature is of type int
		/// </summary>
		/// <since>1.0</since>
		/// 
		public static readonly int TYPE_FEATURE_INT = 2;
		/// <summary>
		/// The feature is of type image
		/// </summary>
		/// <since>1.0</since>
		/// 
		public static readonly int TYPE_FEATURE_IMAGE = 3;
		/// <summary>
		/// The feature is of type float point
		/// </summary>
		/// <since>1.0</since>
		/// 
		public static readonly int TYPE_FEATURE_FLOAT = 4;
		/// <summary>
		/// The feature is of type string[]
		/// </summary>
		/// <since>1.0</since>
		/// 
		public static readonly int TYPE_FEATURE_MSTRING = 5;
		/// <summary>
		/// The feature is of type string
		/// </summary>
		/// <since>1.0</since>
		/// 
		public static readonly int TYPE_FEATURE_STRING = 6;
		/// <summary>
		/// The feature is of type unsupported
		/// </summary>
		/// <since>1.0</since>
		/// 
		public static readonly int TYPE_FEATURE_UNDEFINED = 7;
	}
}
