using System.Windows;
using System.Windows.Controls;

namespace ExtremeStudio.Classes
{
    public class AutobinderTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Template { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            return Template;
        }
    }
}