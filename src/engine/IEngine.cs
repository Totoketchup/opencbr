using System;

namespace org.opencbr.core.engine
{
	using org.opencbr.core.context;
	using org.opencbr.core.express;
	/// <summary>
	/// IEngine  
	/// </summary>
	public interface IEngine
	{
		void SetEnvironmentVariable(string env);
		string GetEnvironmentVariable();
		void SetProblem(Case problem);
		Case GetProblem();
		bool Startup();
		void Run();
		void Destroy();
	}
}
