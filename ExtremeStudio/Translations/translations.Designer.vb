﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Public Class translations
        
        Private Shared resourceMan As Global.System.Resources.ResourceManager
        
        Private Shared resourceCulture As Global.System.Globalization.CultureInfo
        
        <Global.System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")>  _
        Friend Sub New()
            MyBase.New
        End Sub
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Public Shared ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("ExtremeStudio.translations", GetType(translations).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Public Shared Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to 
        '''
        '''Would you like to continue ?.
        '''</summary>
        Public Shared ReadOnly Property StartupForm_Button1_Click_WouldYouLikeToContinue() As String
            Get
                Return ResourceManager.GetString("StartupForm_Button1_Click_WouldYouLikeToContinue", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to That directory doesn&apos;t exist or there is a project with that name already there..
        '''</summary>
        Public Shared ReadOnly Property StartupForm_CreateProjectBtn_Click_DirError() As String
            Get
                Return ResourceManager.GetString("StartupForm_CreateProjectBtn_Click_DirError", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Invalid Name..
        '''</summary>
        Public Shared ReadOnly Property StartupForm_CreateProjectBtn_Click_InvalidName() As String
            Get
                Return ResourceManager.GetString("StartupForm_CreateProjectBtn_Click_InvalidName", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Invalid SAMP Folder.. 
        '''Must contain the pawno folder, gamemodes folder, plugins folder, all executables and the server config..
        '''</summary>
        Public Shared ReadOnly Property StartupForm_CreateProjectBtn_Click_InvalidSampFolder() As String
            Get
                Return ResourceManager.GetString("StartupForm_CreateProjectBtn_Click_InvalidSampFolder", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to You haven&apos;t selected a SAMP version to use..
        '''</summary>
        Public Shared ReadOnly Property StartupForm_CreateProjectBtn_Click_NoSampSelected() As String
            Get
                Return ResourceManager.GetString("StartupForm_CreateProjectBtn_Click_NoSampSelected", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to ERROR: That folder isn&apos;t a valid ExtremeStudio project. Make sure you haven&apos;t deleted or modified any file manually..
        '''</summary>
        Public Shared ReadOnly Property StartupForm_pathTextBox_TextChanged_InvalidESPrj() As String
            Get
                Return ResourceManager.GetString("StartupForm_pathTextBox_TextChanged_InvalidESPrj", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to None.
        '''</summary>
        Public Shared ReadOnly Property StartupForm_pathTextBox_TextChanged_None() As String
            Get
                Return ResourceManager.GetString("StartupForm_pathTextBox_TextChanged_None", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Project version is newer then ExtremeStudio&apos;s version, Please download latest ExtremeStudio package..
        '''</summary>
        Public Shared ReadOnly Property StartupForm_pathTextBox_TextChanged_ProjectVersionNewer() As String
            Get
                Return ResourceManager.GetString("StartupForm_pathTextBox_TextChanged_ProjectVersionNewer", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Project older then ExtremeStudio, Conversion will be done however it may bug with older versions so its recommended to not try..
        '''</summary>
        Public Shared ReadOnly Property StartupForm_pathTextBox_TextChanged_ProjectVersionOlder() As String
            Get
                Return ResourceManager.GetString("StartupForm_pathTextBox_TextChanged_ProjectVersionOlder", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Project version is the same as ExtremeStudio&apos;s version, No converion is needed..
        '''</summary>
        Public Shared ReadOnly Property StartupForm_pathTextBox_TextChanged_ProjectVersionSame() As String
            Get
                Return ResourceManager.GetString("StartupForm_pathTextBox_TextChanged_ProjectVersionSame", resourceCulture)
            End Get
        End Property
    End Class
End Namespace
