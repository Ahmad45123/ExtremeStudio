﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExtremeStudio.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ExtremeStudio.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap correct_projexplorer {
            get {
                object obj = ResourceManager.GetObject("correct_projexplorer", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;Colors&quot;: {
        ///    &quot;SDefault&quot;: {
        ///      &quot;Font&quot;: &quot;Courier New, 10pt&quot;,
        ///      &quot;ForeColor&quot;: &quot;Black&quot;,
        ///      &quot;BackColor&quot;: &quot;Transparent&quot;
        ///    },
        ///    &quot;SInteger&quot;: {
        ///      &quot;Font&quot;: null,
        ///      &quot;ForeColor&quot;: &quot;Purple&quot;,
        ///      &quot;BackColor&quot;: &quot;Transparent&quot;
        ///    },
        ///    &quot;SString&quot;: {
        ///      &quot;Font&quot;: null,
        ///      &quot;ForeColor&quot;: &quot;Firebrick&quot;,
        ///      &quot;BackColor&quot;: &quot;Transparent&quot;
        ///    },
        ///    &quot;SSymbols&quot;: {
        ///      &quot;Font&quot;: null,
        ///      &quot;ForeColor&quot;: &quot;Purple&quot;,
        ///      &quot;BackColor&quot;: &quot;Transparent&quot;
        ///    },
        ///    &quot;SSlComments&quot;: {
        ///      &quot;F [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string defaultThemeInfo {
            get {
                return ResourceManager.GetString("defaultThemeInfo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap dirs_projexplorer {
            get {
                object obj = ResourceManager.GetObject("dirs_projexplorer", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-16&quot;?&gt;
        ///&lt;!--DockPanel configuration file. Author: Weifen Luo, all rights reserved.--&gt;
        ///&lt;!--!!! AUTOMATICALLY GENERATED FILE. DO NOT MODIFY !!!--&gt;
        ///&lt;DockPanel FormatVersion=&quot;1.0&quot; DockLeftPortion=&quot;0.162884333821376&quot; DockRightPortion=&quot;0.181918008784773&quot; DockTopPortion=&quot;0.25&quot; DockBottomPortion=&quot;0.306198347107438&quot; ActiveDocumentPane=&quot;-1&quot; ActivePane=&quot;-1&quot;&gt;
        ///  &lt;Contents Count=&quot;3&quot;&gt;
        ///    &lt;Content ID=&quot;0&quot; PersistString=&quot;ExtremeStudio.DockPanelForms.MainFormDocks.ProjExplorerDock&quot; AutoHi [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string docksInfo {
            get {
                return ResourceManager.GetString("docksInfo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap file_projexplorer {
            get {
                object obj = ResourceManager.GetObject("file_projexplorer", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to // This is a comment
        ///// uncomment the line below if you want to write a filterscript
        /////#define FILTERSCRIPT
        ///
        ///#include &lt;a_samp&gt;
        ///
        ///#if defined FILTERSCRIPT
        ///
        ///public OnFilterScriptInit()
        ///{
        ///	print(&quot;\n--------------------------------------&quot;);
        ///	print(&quot; Blank Filterscript by your name here&quot;);
        ///	print(&quot;--------------------------------------\n&quot;);
        ///	return 1;
        ///}
        ///
        ///public OnFilterScriptExit()
        ///{
        ///	return 1;
        ///}
        ///
        ///#else
        ///
        ///main()
        ///{
        ///	print(&quot;\n----------------------------------&quot;);
        ///	print(&quot; Blank Gamemode by  [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string newfileTemplate {
            get {
                return ResourceManager.GetString("newfileTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///	&quot;user&quot;: &quot;{0}&quot;,
        ///	&quot;repo&quot;: &quot;{1}&quot;,
        ///	&quot;entry&quot;: &quot;gamemodes\\{2}&quot;,
        ///	&quot;output&quot;: &quot;gamemodes\\{3}&quot;,
        ///	&quot;dependencies&quot;: [
        ///		&quot;sampctl/samp-stdlib&quot;
        ///	]
        ///}.
        /// </summary>
        internal static string pawn {
            get {
                return ResourceManager.GetString("pawn", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ribbon_addIndent {
            get {
                object obj = ResourceManager.GetObject("ribbon_addIndent", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ribbon_autoIndent {
            get {
                object obj = ResourceManager.GetObject("ribbon_autoIndent", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ribbon_closeProject {
            get {
                object obj = ResourceManager.GetObject("ribbon_closeProject", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ribbon_compile {
            get {
                object obj = ResourceManager.GetObject("ribbon_compile", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ribbon_copy {
            get {
                object obj = ResourceManager.GetObject("ribbon_copy", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ribbon_cut {
            get {
                object obj = ResourceManager.GetObject("ribbon_cut", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ribbon_errors {
            get {
                object obj = ResourceManager.GetObject("ribbon_errors", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ribbon_esPlugins {
            get {
                object obj = ResourceManager.GetObject("ribbon_esPlugins", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ribbon_goto {
            get {
                object obj = ResourceManager.GetObject("ribbon_goto", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ribbon_includes {
            get {
                object obj = ResourceManager.GetObject("ribbon_includes", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ribbon_newFile {
            get {
                object obj = ResourceManager.GetObject("ribbon_newFile", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ribbon_objectExplrer {
            get {
                object obj = ResourceManager.GetObject("ribbon_objectExplrer", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ribbon_paste {
            get {
                object obj = ResourceManager.GetObject("ribbon_paste", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ribbon_plugins {
            get {
                object obj = ResourceManager.GetObject("ribbon_plugins", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ribbon_removeIndent {
            get {
                object obj = ResourceManager.GetObject("ribbon_removeIndent", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ribbon_saveFile {
            get {
                object obj = ResourceManager.GetObject("ribbon_saveFile", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ribbon_saveFileAll {
            get {
                object obj = ResourceManager.GetObject("ribbon_saveFileAll", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ribbon_search {
            get {
                object obj = ResourceManager.GetObject("ribbon_search", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ribbon_searchAndReplace {
            get {
                object obj = ResourceManager.GetObject("ribbon_searchAndReplace", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ribbon_settings {
            get {
                object obj = ResourceManager.GetObject("ribbon_settings", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        internal static byte[] SQLite_Interop {
            get {
                object obj = ResourceManager.GetObject("SQLite_Interop", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap warning_icon {
            get {
                object obj = ResourceManager.GetObject("warning_icon", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
    }
}
