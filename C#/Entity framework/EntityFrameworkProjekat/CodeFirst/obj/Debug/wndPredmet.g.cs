﻿#pragma checksum "..\..\wndPredmet.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E2E230DCB85607A8B9AD6E8E47F627185F5E357B"
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
    /// wndPredmet
    /// </summary>
    public partial class wndPredmet : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\wndPredmet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid grdPredmet;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\wndPredmet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPredmetID;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\wndPredmet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNazivPredmeta;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\wndPredmet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUnos;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\wndPredmet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnIzmena;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\wndPredmet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBrisanje;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\wndPredmet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtProfesorID;
        
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
            System.Uri resourceLocater = new System.Uri("/CodeFirst;component/wndpredmet.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\wndPredmet.xaml"
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
            this.grdPredmet = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.txtPredmetID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtNazivPredmeta = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.btnUnos = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\wndPredmet.xaml"
            this.btnUnos.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnIzmena = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\wndPredmet.xaml"
            this.btnIzmena.Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnBrisanje = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\wndPredmet.xaml"
            this.btnBrisanje.Click += new System.Windows.RoutedEventHandler(this.Button_Click_2);
            
            #line default
            #line hidden
            return;
            case 7:
            this.txtProfesorID = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

