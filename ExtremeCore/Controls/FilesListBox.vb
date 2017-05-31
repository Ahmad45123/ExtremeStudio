
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports System.ComponentModel
Imports System.Collections
Imports System.Drawing
Imports System.Runtime.InteropServices
''' <summary>
''' Represents a ListBox control with file names as items.
''' </summary>
<Description("Display a list of files that the user can select from"), DefaultProperty("DirectoryName"), DefaultEvent("FileSelected")> _
Public Class FilesListBox
	Inherits ListBox
	#Region "Events"

	''' <summary>
	''' Occures whenever a file is selected by a double click on the control.
	''' </summary>
	<Description("Occures whenever a file is selected by a double click on the control"), Category("Action")> _
	Public Event FileSelected As FileSelectedEventHandler

	#End Region

	#Region "Properties"

	Private _selectedPath As String = "C:\"
	''' <summary>
	''' Gets or sets the directory name that the files should relate to
	''' </summary>        
	<Description("Gets or sets the directory name that the files should relate to"), DefaultValue("C:\"), Category("Data")> _
	Public Property SelectedPath() As String
		Get
			Return _selectedPath
		End Get
		Set
			If value <> String.Empty Then
				_selectedPath = value
				PopulatingItems()
			End If
		End Set
	End Property

    Private _mainDirectory As String = "C:\"
    	''' <summary>
	''' Gets or sets the directory that the user can't go behind.
    ''' ONLY useful when _showBackIcon is True.
	''' </summary>        
	<Description("Gets or sets the directory that the user can't go behind."), DefaultValue("C:\"), Category("Data")> _
	Public Property MainDir() As String
		Get
			Return _mainDirectory
		End Get
		Set
			If value <> String.Empty Then
				_mainDirectory = value
			End If
		End Set
	End Property

	Private _showDirectories As Boolean = True
	''' <summary>
	''' Gets or sets a value indicating wheater to show directories on the control
	''' </summary>        
	<Description("Gets or sets a value indicating wheater to show directories on the control"), DefaultValue(True), Category("Behavior")> _
	Public Property ShowDirectories() As Boolean
		Get
			Return _showDirectories
		End Get
		Set
			_showDirectories = value
			PopulatingItems()
		End Set
	End Property

	Private _showBackIcon As Boolean = True
	''' <summary>
	''' Gets or sets a value indicating wheater to show the back directory icon
	''' on the control (when the IsToShowDirectories property is true)
	''' </summary>        
	<Description("Gets or sets a value indicating wheater to show the back directory icon on the control (when the IsToShowDirectories property is true)"), DefaultValue(True), Category("Behavior")> _
	Public Property ShowBackIcon() As Boolean
		Get
			Return _showBackIcon
		End Get
		Set
			_showBackIcon = value
			PopulatingItems()
		End Set
	End Property

	''' <summary>
	''' Gets the currently selected file in the FilesListBox
	''' </summary>
	<Browsable(False)> _
	Public ReadOnly Property SelectedFile() As String
		Get
            Return GetFullName(SelectedItem?.ToString())
		End Get
	End Property

	Private _fileIconSize As IconSize = IconSize.Small
	''' <summary>
	''' Gets or sets the icon size, this value also sets the item heigth
	''' </summary>
	<Description("Specifies the size of the icon of each file - small or large"), DefaultValue(GetType(IconSize), "IconSize.Small"), Category("Appearance")> _
	Public Property FileIconSize() As IconSize
		Get
			Return _fileIconSize
		End Get
		Set
			_fileIconSize = value
			Select Case _fileIconSize
				Case IconSize.Small
					MyBase.ItemHeight = 16
					Exit Select
				Case IconSize.Large
					MyBase.ItemHeight = 32
					Exit Select
			End Select
			Invalidate()
		End Set
	End Property

	''' <summary>
	''' Gets or sets the item height. can only be 32 or 16.
	''' </summary>
	<Browsable(False)> _
	Public Overrides Property ItemHeight() As Integer
		Get
			Return MyBase.ItemHeight
		End Get
		Set
			If value = 32 Then
				FileIconSize = IconSize.Large
				MyBase.ItemHeight = 32
			Else
				FileIconSize = IconSize.Small
				MyBase.ItemHeight = 16

			End If
		End Set
	End Property

	#End Region

	#Region "Ctor(s)"

	''' <summary>
	''' Intializes a new instance of the FilesListBox class, to view a list of
	''' files inside a ListBox control.
	''' </summary>
	Public Sub New()
		DrawMode = DrawMode.OwnerDrawFixed
	End Sub
	''' <summary>
	''' Intializes a new instance of the FilesListBox class, to view a list of
	''' files inside a ListBox control.
	''' </summary>
	''' <param name="directoryName">The directory to start from</param>
	Public Sub New(directoryName As String)
		Me.New()
		_selectedPath = SelectedPath
		PopulatingItems()
	End Sub

	#End Region

	#Region "Private Methods"
	''' <summary>
	''' Adds the specified directory to the list.
	''' </summary>
	''' <param name="directoryName"></param>
	Private Sub AddDirectory(directoryName As String)
		Items.Add(directoryName)
	End Sub

	''' <summary>
	''' Adds the specified file to the list.
	''' </summary>
	''' <param name="fileName"></param>
	Private Sub AddFile(fileName As String)
		Items.Add(fileName)
	End Sub

	''' <summary>
	''' Gets the full file name, by adding the directory name to the file specified.
	''' </summary>
	''' <param name="fileNameOnly"></param>
	''' <returns></returns>
	Private Function GetFullName(fileNameOnly As String) As String
        If fileNameOnly Is Nothing Then Return Nothing
        Return Path.Combine(_selectedPath, fileNameOnly)
	End Function

	''' <summary>
	''' Populate the list box with files and directories according to the 
	''' directoryName property
	''' </summary>
	Private Sub PopulatingItems()
		' Ignore when in desing mode
		If DesignMode Then
			Return
		End If

		Me.Items.Clear()
		' Shows the back directory item (            
		If _showBackIcon AndAlso _selectedPath.Length > 3 AndAlso _selectedPath <> _mainDirectory Then
			Items.Add("..")
		End If
		Try
			' Fills all directory items
			If _showDirectories Then
				Dim dirNames As String() = Directory.GetDirectories(_selectedPath)
				For Each dir As String In dirNames
					Dim realDir As String = Path.GetFileName(dir)
					Items.Add(realDir)
				Next
			End If
			' Fills all list items
			Dim fileNames As String() = Directory.GetFiles(_selectedPath)
			For Each file As String In fileNames
				Dim fileName As String = Path.GetFileName(file)
				Items.Add(fileName)
			Next
				' eat this - back is still optional even when no other items exists
		Catch
		End Try
		Invalidate()
	End Sub

	#End Region

	#Region "Event Handlers"
	''' <summary>
	''' Overrides, when double click on the list - fires the FileSelected event,
	''' or, for directory, move into it.
	''' </summary>
	''' <param name="e"></param>
	Protected Overrides Sub OnMouseDoubleClick(e As System.Windows.Forms.MouseEventArgs)
		If SelectedItem Is Nothing Then
			Return
		End If
		Dim selectedFile As String = GetFullName(SelectedItem.ToString())
		' .. ---> go back one level
		If selectedFile.EndsWith("..") Then
			' Removes the \ in the end, so that the parent will return the real parent.
			If _selectedPath.EndsWith("\") Then
				_selectedPath = _selectedPath.Remove(_selectedPath.Length - 1, 1)
			End If
			_selectedPath = Directory.GetParent(_selectedPath).FullName
			PopulatingItems()
		' go inside the directory
		ElseIf Directory.Exists(selectedFile) Then
			_selectedPath = selectedFile & Convert.ToString("\")
			PopulatingItems()
		Else
			OnFileSelected(New FileSelectEventArgs(selectedFile))
		End If
		MyBase.OnMouseDoubleClick(e)
	End Sub
	''' <summary>
	''' Fires the FileSelected event.
	''' </summary>
	''' <param name="fse"></param>
	Protected Sub OnFileSelected(fse As FileSelectEventArgs)
		RaiseEvent FileSelected(Me, fse)
	End Sub

	#End Region

	#Region "Painting"
	''' <summary>
	''' Paints each file with its icon.
	''' </summary>
	''' <param name="e"></param>
	Protected Overrides Sub OnDrawItem(e As DrawItemEventArgs)
		e.DrawBackground()
		e.DrawFocusRectangle()
		Dim bounds As Rectangle = e.Bounds
		If e.Index > -1 AndAlso e.Index < Items.Count Then
            'Check if exists.
            Dim imageSize As Size
            Dim fileNameOnly As String = Items(e.Index).ToString()
            Dim fullFileName As String = GetFullName(fileNameOnly)

            If File.Exists(fullFileName) = False And Directory.Exists(fullFileName) = False Then
                Items.RemoveAt(e.Index)
                Exit Sub
            End If

            Dim fileIcon As Icon = Nothing
                Dim imageRectangle As New Rectangle(bounds.Left + 1, bounds.Top + 1, ItemHeight - 2, ItemHeight - 2)
                If fileNameOnly.Equals("..") Then
                    ' When .. is the string - draws directory icon                    
                    fileIcon = IconExtractor.GetFileIcon(Application.StartupPath, _fileIconSize)
                    e.Graphics.DrawIcon(fileIcon, imageRectangle)
                Else
                    fileIcon = IconExtractor.GetFileIcon(fullFileName, _fileIconSize)
                    ' Icon.ExtractAssociatedIcon(item);
                    e.Graphics.DrawIcon(fileIcon, imageRectangle)
                End If
                imageSize = imageRectangle.Size
                fileIcon.Dispose()


                Dim fileNameRec As New Rectangle(bounds.Left + imageSize.Width + 3, bounds.Top, bounds.Width - imageSize.Width - 3, bounds.Height)
                Dim format As New StringFormat()
                format.LineAlignment = StringAlignment.Center
                e.Graphics.DrawString(fileNameOnly, e.Font, New SolidBrush(e.ForeColor), fileNameRec, format)
            End If

            MyBase.OnDrawItem(e)
	End Sub

	#End Region
End Class

#Region "Enums"
''' <summary>
''' Specifies the icon size (16 or 32)
''' </summary>
Public Enum IconSize
	''' <summary>
	''' 16X16 icon
	''' </summary>
	Small
	''' <summary>
	''' 32X32 icon
	''' </summary>
	Large
End Enum
#End Region

#Region "FileSelectEventArgs"
''' <summary>
''' Represents the method that is used to handle file selected event.
''' </summary>
''' <param name="sender"></param>
''' <param name="fse"></param>
Public Delegate Sub FileSelectedEventHandler(sender As Object, fse As FileSelectEventArgs)


''' <summary>
''' Provides for FileSelect event.
''' </summary>
Public Class FileSelectEventArgs
	Inherits EventArgs
	Private m_fileName As String

	''' <summary>
	''' Gets or sets the file name that trigered the event.
	''' </summary>
	Public Property FileName() As String
		Get
			Return m_fileName
		End Get
		Set
			m_fileName = FileName
		End Set
	End Property
	''' <summary>
	''' Initializes a new instance of the FileSelectEventArgs in order to provide
	''' data for FileSelected event.
	''' </summary>
	''' <param name="fileName"></param>
	Public Sub New(fileName As String)
		Me.m_fileName = fileName
	End Sub

End Class
#End Region

#Region "Icon Extractor"
''' <summary>
''' Util class to extract icons from files or directories.
''' </summary>
Class IconExtractor
	<StructLayout(LayoutKind.Sequential)> _
	Public Structure SHFILEINFO
		Public hIcon As IntPtr
		Public iIcon As IntPtr
		Public dwAttributes As UInteger
		<MarshalAs(UnmanagedType.ByValTStr, SizeConst := 260)> _
		Public szDisplayName As String
		<MarshalAs(UnmanagedType.ByValTStr, SizeConst := 80)> _
		Public szTypeName As String
	End Structure

	Private Class Win32
		Public Const SHGFI_ICON As UInteger = &H100
		Public Const SHGFI_LARGEICON As UInteger = &H0
		' 'Large icon
		Public Const SHGFI_SMALLICON As UInteger = &H1
		' 'Small icon
		<DllImport("shell32.dll")> _
		Public Shared Function SHGetFileInfo(pszPath As String, dwFileAttributes As UInteger, ByRef psfi As SHFILEINFO, cbSizeFileInfo As UInteger, uFlags As UInteger) As IntPtr
		End Function
	End Class

	''' <summary>
	''' Gets the icon asotiated with the filename.
	''' </summary>
	''' <param name="fileName"></param>
	''' <returns></returns>
	Public Shared Function GetFileIcon(fileName As String, _iconSize As IconSize) As Icon
		Dim myIcon As System.Drawing.Icon = Nothing
		Try
			Dim hImgSmall As IntPtr
			'the handle to the system image list
			Dim shinfo As New SHFILEINFO()

			'Use this to get the small Icon
			hImgSmall = Win32.SHGetFileInfo(fileName, 0, shinfo, CUInt(Marshal.SizeOf(shinfo)), Win32.SHGFI_ICON Or (If(_iconSize = IconSize.Small, Win32.SHGFI_SMALLICON, Win32.SHGFI_LARGEICON)))

			'The icon is returned in the hIcon member of the shinfo
			'struct
			myIcon = System.Drawing.Icon.FromHandle(shinfo.hIcon)
		Catch
			Return Nothing
		End Try
		Return myIcon
	End Function
End Class
#End Region