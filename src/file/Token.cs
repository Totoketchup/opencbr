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
	using org.opencbr.core.express;
	/// <summary>
	/// Token 
	/// <author>xw_cn@163.com</author>
	/// <version>1.0</version>
	/// <creationdate>2005/11/31</creationdate>
	/// <modificationdate></modificationdate>>
	/// <history></history>
	/// </summary>
	public class Token
	{
		public static readonly string TYPE_FLOAT = "float";
		public static readonly string TYPE_STRING = "string";
		public static readonly string TYPE_BOOL = "bool";
		public static readonly string TYPE_INT = "int";
		public static readonly string TYPE_MSTRING = "string[]";
		public static readonly string TYPE_IMAGE = "image";
		public static readonly string TYPE_UNDEF = "undef";
		public static readonly string TOKEN_FEATURE = "@Feature";
		public static readonly string TOKEN_CASE = "@Case";
		public static readonly string TOKEN_DATA = "@Data";
		public static readonly string TOKEN_COMMENT = "#";
		public static readonly string TOKEN_BOOL_TRUE = "true";
		public static readonly string TOKEN_BOOL_FALSE = "false";
		public static int GetType(string token)
		{
			if (token.Equals(TYPE_BOOL))
			{
				return FeatureType.TYPE_FEATURE_BOOL;
			}
			else if (token.Equals(TYPE_FLOAT))
			{
				return FeatureType.TYPE_FEATURE_FLOAT;
			}
			else if (token.Equals(TYPE_STRING))
			{
				return FeatureType.TYPE_FEATURE_STRING;
			}
			else if (token.Equals(TYPE_INT))
			{
				return FeatureType.TYPE_FEATURE_INT;
			}
			else if (token.Equals(TYPE_IMAGE))
			{
				return FeatureType.TYPE_FEATURE_IMAGE;
			}
			else if (token.Equals(TYPE_MSTRING))
			{
				return FeatureType.TYPE_FEATURE_MSTRING;
			}
			else 
			{
				return FeatureType.TYPE_FEATURE_UNDEFINED;
			}
		}
	}
}
