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
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("BioNovoGene.Analytical.MassSpectrometry.Math.Insilicon.Resources", GetType(Resources).Assembly)
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
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Bonds,H0*,bounds.n,atom1,atom2,comments
        '''H-H,104.2,1,H,H,
        '''C-C,83,1,C,C,
        '''N-N,38.4,1,N,N,
        '''O-O,35,1,O,O,
        '''F-F,36.6,1,F,F,
        '''Si-Si,52,1,Si,Si,
        '''P-P,51,1,P,P,
        '''S-S,54,1,S,S,
        '''Cl-Cl,58,1,Cl,Cl,
        '''Br-Br,46,1,Br,Br,
        '''I-I,36,1,I,I,
        '''H-C,99,1,H,C,
        '''H-N,93,1,H,N,
        '''H-O,111,1,H,O,
        '''H-F,135,1,H,F,
        '''H-Cl,103,1,H,Cl,
        '''H-Br,87.5,1,H,Br,
        '''H-I,71,1,H,I,
        '''H-B,90,1,H,B,
        '''H-S,81,1,H,S,
        '''H-Si,70,1,H,Si,
        '''H-P,77,1,H,P,
        '''B-F,154,1,B,F,
        '''B-O,123,1,B,O,
        '''C-N,73,1,C,N,
        '''N-CO,86,1,N,CO,
        '''C-O,85.5,1,C,O,
        '''O-CO,110,1,O,CO,
        '''C-S,65,1,C,S [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property Standard_bond_energies() As String
            Get
                Return ResourceManager.GetString("Standard_bond_energies", resourceCulture)
            End Get
        End Property
    End Module
End Namespace
