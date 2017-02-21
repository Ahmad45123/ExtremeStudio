using System.Windows;
using System.Windows.Controls;
using ExtremeStudio.ViewModels.Panels;

namespace ExtremeStudio.Classes
{
    public class LayoutItemTemplateSelector : DataTemplateSelector
    {
	    public DataTemplate Template { get; set; }

	    public override DataTemplate SelectTemplate(object item, DependencyObject container)
	    {
		    if (item is ScriptEditorViewModel) {
			    return this.Template;
		    } else {
			    return base.SelectTemplate(item, container);
		    }
	    }

    }
}