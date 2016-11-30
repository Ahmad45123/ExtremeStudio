using System.Collections.Generic;
using System.Windows.Forms;
using ExtremeStudio.Core;

//NOTE: This is not generally meant to be used for complex stuff, I'd rather you just fork the project and add your
//desired feature natively then open a pull request.. This plugin system is to be used for stuff that are a bit not IDE
//related like SAMP ID browser and such.

namespace ExtremeStudio.Core
{
	public interface IExtremePlugin
	{	
		//Unique Plugin Name.
		string PluginName {get;}
		
		//This list should be filled in the 'OnPluginInit' function.
		//BUG: List<RibbonButton> ToolStripButtons {get; set;}
		
		//To be called as a class.. All available functions are the "funcsHandler" in the ExtremeStudio project.
		IPluginContext ExtremeStudioFuncs {get; set;}
		
		//This is meant to be used to fill the list above with needed buttons which will be added to the tool-strip.
		void OnPluginInit(); //NOTE: Any other stuff can be done here too...
		
	}
	
}
