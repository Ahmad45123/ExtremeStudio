using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ExtremeCore.Controls_And_Tools
{
    /// <summary>
    /// Represents a ListBox control with file names as items.
    /// </summary>
    [Description("Display a list of files that the user can select from"), DefaultProperty("DirectoryName"), DefaultEvent("FileSelected")]
    public class FilesListBox : ListBox
    {
        #region Events
	
        /// <summary>
        /// Occures whenever a file is selected by a double click on the control.
        /// </summary>
        [Description("Occures whenever a file is selected by a double click on the control"), Category("Action")]private FileSelectedEventHandler FileSelectedEvent;
        public event FileSelectedEventHandler FileSelected
        {
            add
            {
                FileSelectedEvent = (FileSelectedEventHandler) Delegate.Combine(FileSelectedEvent, value);
            }
            remove
            {
                FileSelectedEvent = (FileSelectedEventHandler) Delegate.Remove(FileSelectedEvent, value);
            }
        }
	
	
        #endregion
	
        #region Properties
	
        private string _selectedPath = "C:\\";
        /// <summary>
        /// Gets or sets the directory name that the files should relate to
        /// </summary>
        [Description("Gets or sets the directory name that the files should relate to"), DefaultValue("C:\\") ,  Category("Data")]public string SelectedPath
        {
            get
            {
                return _selectedPath;
            }
            set
            {
                if (value != string.Empty)
                {
                    _selectedPath = value;
                    PopulatingItems();
                }
            }
        }

        public IEnumerable<string> IgnoredNames { get; set; }

        private string _mainDirectory = "C:\\";
        /// <summary>
        /// Gets or sets the directory that the user can't go behind.
        /// ONLY useful when _showBackIcon is True.
        /// </summary>
        [Description("Gets or sets the directory that the user can't go behind."), DefaultValue("C:\\") ,  Category("Data")]public string MainDir
        {
            get
            {
                return _mainDirectory;
            }
            set
            {
                if (value != string.Empty)
                {
                    _mainDirectory = value;
                }
            }
        }
	
        private bool _showDirectories = true;
        /// <summary>
        /// Gets or sets a value indicating wheater to show directories on the control
        /// </summary>
        [Description("Gets or sets a value indicating wheater to show directories on the control"), DefaultValue(true), Category("Behavior")]public bool ShowDirectories
        {
            get
            {
                return _showDirectories;
            }
            set
            {
                _showDirectories = value;
                PopulatingItems();
            }
        }
	
        private bool _showBackIcon = true;
        /// <summary>
        /// Gets or sets a value indicating wheater to show the back directory icon
        /// on the control (when the IsToShowDirectories property is true)
        /// </summary>
        [Description("Gets or sets a value indicating wheater to show the back directory icon on the control (when the IsToShowDirectories property is true)"), DefaultValue(true), Category("Behavior")]public bool ShowBackIcon
        {
            get
            {
                return _showBackIcon;
            }
            set
            {
                _showBackIcon = value;
                PopulatingItems();
            }
        }
	
        /// <summary>
        /// Gets the currently selected file in the FilesListBox
        /// </summary>
        [Browsable(false)]public string SelectedFile
        {
            get
            {
                return GetFullName(Convert.ToString(SelectedItem?.ToString()));
            }
        }
	
        private IconSize _fileIconSize = IconSize.Small;
        /// <summary>
        /// Gets or sets the icon size, this value also sets the item heigth
        /// </summary>
        [Description("Specifies the size of the icon of each file - small or large"), DefaultValue(typeof(IconSize), "IconSize.Small"), Category("Appearance")]public IconSize FileIconSize
        {
            get
            {
                return _fileIconSize;
            }
            set
            {
                _fileIconSize = value;
                switch (_fileIconSize)
                {
                    case IconSize.Small:
                        base.ItemHeight = 16;
                        break;
                    case IconSize.Large:
                        base.ItemHeight = 32;
                        break;
                }
                Invalidate();
            }
        }
	
        /// <summary>
        /// Gets or sets the item height. can only be 32 or 16.
        /// </summary>
        [Browsable(false)]public override int ItemHeight
        {
            get
            {
                return base.ItemHeight;
            }
            set
            {
                if (value == 32)
                {
                    FileIconSize = IconSize.Large;
                    base.ItemHeight = 32;
                }
                else
                {
                    FileIconSize = IconSize.Small;
                    base.ItemHeight = 16;
				
                }
            }
        }
	
        #endregion
	
        #region Ctor(s)
	
        /// <summary>
        /// Intializes a new instance of the FilesListBox class, to view a list of
        /// files inside a ListBox control.
        /// </summary>
        public FilesListBox()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
        }
        /// <summary>
        /// Intializes a new instance of the FilesListBox class, to view a list of
        /// files inside a ListBox control.
        /// </summary>
        /// <param name="directoryName">The directory to start from</param>
        public FilesListBox(string directoryName) : this()
        {
            _selectedPath = SelectedPath;
            PopulatingItems();
        }
	
        #endregion
	
        #region Private Methods
        /// <summary>
        /// Adds the specified directory to the list.
        /// </summary>
        /// <param name="directoryName"></param>
        private void AddDirectory(string directoryName)
        {
            Items.Add(directoryName);
        }
	
        /// <summary>
        /// Adds the specified file to the list.
        /// </summary>
        /// <param name="fileName"></param>
        private void AddFile(string fileName)
        {
            Items.Add(fileName);
        }
	
        /// <summary>
        /// Gets the full file name, by adding the directory name to the file specified.
        /// </summary>
        /// <param name="fileNameOnly"></param>
        /// <returns></returns>
        private string GetFullName(string fileNameOnly)
        {
            if (ReferenceEquals(fileNameOnly, null))
            {
                return null;
            }
            return Path.Combine(_selectedPath, fileNameOnly);
        }
	
        /// <summary>
        /// Populate the list box with files and directories according to the
        /// directoryName property
        /// </summary>
        private void PopulatingItems()
        {
            // Ignore when in desing mode
            if (DesignMode)
            {
                return ;
            }
		
            Items.Clear();
            // Shows the back directory item (
            if (_showBackIcon && _selectedPath.Length > 3 && _selectedPath != _mainDirectory)
            {
                Items.Add("..");
            }
            try
            {
                // Fills all directory items
                if (_showDirectories)
                {
                    string[] dirNames = Directory.GetDirectories(_selectedPath);
                    foreach (string dir in dirNames)
                    {
                        string realDir = Path.GetFileName(dir);
                        if (IgnoredNames.Contains(realDir) && SelectedPath == MainDir)
                            continue;
                        Items.Add(realDir);
                    }
                }
                // Fills all list items
                string[] fileNames = Directory.GetFiles(_selectedPath);
                foreach (string file in fileNames)
                {
                    string fileName = Path.GetFileName(file);
                    if (IgnoredNames.Contains(fileName) && SelectedPath == MainDir)
                        continue;
                    Items.Add(fileName);
                }
                // eat this - back is still optional even when no other items exists
            }
            catch
            {
            }
            Invalidate();
        }
	
        #endregion
	
        #region Event Handlers
        /// <summary>
        /// Overrides, when double click on the list - fires the FileSelected event,
        /// or, for directory, move into it.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            if (ReferenceEquals(SelectedItem, null))
            {
                return ;
            }
            string selectedFile = GetFullName(Convert.ToString(SelectedItem.ToString()));
            // .. ---> go back one level
            if (selectedFile.EndsWith(".."))
            {
                // Removes the \ in the end, so that the parent will return the real parent.
                if (_selectedPath.EndsWith("\\"))
                {
                    _selectedPath = _selectedPath.Remove(_selectedPath.Length - 1, 1);
                }
                _selectedPath = Directory.GetParent(_selectedPath).FullName;
                PopulatingItems();
                // go inside the directory
            }
            else if (Directory.Exists(selectedFile))
            {
                _selectedPath = selectedFile + Convert.ToString("\\");
                PopulatingItems();
            }
            else
            {
                OnFileSelected(new FileSelectEventArgs(selectedFile));
            }
            base.OnMouseDoubleClick(e);
        }
        /// <summary>
        /// Fires the FileSelected event.
        /// </summary>
        /// <param name="fse"></param>
        protected void OnFileSelected(FileSelectEventArgs fse)
        {
            if (FileSelectedEvent != null)
                FileSelectedEvent(this, fse);
        }
	
        #endregion
	
        #region Painting
        /// <summary>
        /// Paints each file with its icon.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            Rectangle bounds = e.Bounds;
            if (e.Index > -1 && e.Index < Items.Count)
            {
                //Check if exists.
                Size imageSize = default(Size);
                string fileNameOnly = Convert.ToString(Items[e.Index].ToString());
                string fullFileName = GetFullName(fileNameOnly);
			
                if (File.Exists(fullFileName) == false && Directory.Exists(fullFileName) == false)
                {
                    Items.RemoveAt(e.Index);
                    return;
                }
			
                Icon fileIcon = null;
                Rectangle imageRectangle = new Rectangle(bounds.Left + 1, bounds.Top + 1, ItemHeight - 2, ItemHeight - 2);
                if (fileNameOnly.Equals(".."))
                {
                    // When .. is the string - draws directory icon
                    fileIcon = IconExtractor.GetFileIcon(Convert.ToString(Application.StartupPath), _fileIconSize);
                    e.Graphics.DrawIcon(fileIcon, imageRectangle);
                }
                else
                {
                    fileIcon = IconExtractor.GetFileIcon(fullFileName, _fileIconSize);
                    // Icon.ExtractAssociatedIcon(item);
                    e.Graphics.DrawIcon(fileIcon, imageRectangle);
                }
                imageSize = imageRectangle.Size;
                fileIcon.Dispose();
			
			
                Rectangle fileNameRec = new Rectangle(Convert.ToInt32(bounds.Left + imageSize.Width) + 3, bounds.Top, Convert.ToInt32(bounds.Width - imageSize.Width) - 3, bounds.Height);
                StringFormat format = new StringFormat
                {
                    LineAlignment = StringAlignment.Center
                };
                e.Graphics.DrawString(fileNameOnly, e.Font, new SolidBrush(e.ForeColor), fileNameRec, format);
            }
		
            base.OnDrawItem(e);
        }
	
        #endregion
    }

    #region Enums
    /// <summary>
    /// Specifies the icon size (16 or 32)
    /// </summary>
    public enum IconSize
    {
        /// <summary>
        /// 16X16 icon
        /// </summary>
        Small,
        /// <summary>
        /// 32X32 icon
        /// </summary>
        Large
    }
    #endregion

    #region FileSelectEventArgs
    /// <summary>
    /// Represents the method that is used to handle file selected event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="fse"></param>
    public delegate void FileSelectedEventHandler(object sender, FileSelectEventArgs fse);


    /// <summary>
    /// Provides for FileSelect event.
    /// </summary>
    public class FileSelectEventArgs : EventArgs
    {
        private string m_fileName;
	
        /// <summary>
        /// Gets or sets the file name that trigered the event.
        /// </summary>
        public string FileName
        {
            get
            {
                return m_fileName;
            }
            set
            {
                m_fileName = FileName;
            }
        }
        /// <summary>
        /// Initializes a new instance of the FileSelectEventArgs in order to provide
        /// data for FileSelected event.
        /// </summary>
        /// <param name="fileName"></param>
        public FileSelectEventArgs(string fileName)
        {
            m_fileName = fileName;
        }
	
    }
    #endregion

    #region Icon Extractor
    /// <summary>
    /// Util class to extract icons from files or directories.
    /// </summary>
    public class IconExtractor
    {
        [StructLayout(LayoutKind.Sequential)]public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public IntPtr iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]public string szTypeName;
        }
	
        private class Win32
        {
            public const uint SHGFI_ICON = 0x100;
            public const uint SHGFI_LARGEICON = 0x0;
            // 'Large icon
            public const uint SHGFI_SMALLICON = 0x1;
            // 'Small icon
            [DllImport("shell32.dll")]public static  extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);
        }
	
        /// <summary>
        /// Gets the icon asotiated with the filename.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static Icon GetFileIcon(string fileName, IconSize _iconSize)
        {
            Icon myIcon = null;
            try
            {
                IntPtr hImgSmall;
                //the handle to the system image list
                SHFILEINFO shinfo = new SHFILEINFO();
			
                //Use this to get the small Icon
                hImgSmall = Win32.SHGetFileInfo(fileName, 0, ref shinfo, Convert.ToUInt32((uint) (Marshal.SizeOf(shinfo))), Win32.SHGFI_ICON | (_iconSize == IconSize.Small ? Win32.SHGFI_SMALLICON : Win32.SHGFI_LARGEICON));
			
                //The icon is returned in the hIcon member of the shinfo
                //struct
                myIcon = Icon.FromHandle(shinfo.hIcon);
            }
            catch
            {
                return null;
            }
            return myIcon;
        }
    }
    #endregion
}