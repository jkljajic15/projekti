﻿#pragma checksum "..\..\wndProfesor.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2FFB2348BA580413329631F8773B45A160F9A12F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CodeFirst;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace CodeFirst {
    
    
    /// <summary>
    /// wndProfesor
    /// </summary>
    public partial class wndProfesor : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\wndProfesor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid grdProfesor;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\wndProfesor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtProfesorID;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\wndProfesor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtIme;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\wndProfesor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUnos;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\wndProfesor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnIzmena;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\wndProfesor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBrisanje;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CodeFirst;component/wndprofesor.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\wndProfesor.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.grdProfesor = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.txtProfesorID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtIme = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.btnUnos = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\wndProfesor.xaml"
            this.btnUnos.Click += new System.Windows.RoutedEventHandler(this.btnUnos_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnIzmena = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\wndProfesor.xaml"
            this.btnIzmena.Click += new System.Windows.RoutedEventHandler(this.btnIzmena_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnBrisanje = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\wndProfesor.xaml"
            this.btnBrisanje.Click += new System.Windows.RoutedEventHandler(this.btnBrisanje_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
