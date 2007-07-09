using System;

namespace org.opencbr.core.db
{
	using org.opencbr.core.express;
	/// <summary>
	/// IDatabase ��ժҪ˵����
	/// </summary>
	public interface IDatabase
	{
		Case[] GetCases(Case c, string sql);
		void StoreCases(Case[] cs);
	}
}
