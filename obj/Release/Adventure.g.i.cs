﻿#pragma checksum "..\..\Adventure.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D0D6018AA62A227F2C957330146135131DB6B5F5FF66581AE8707C9DBA396234"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SurvivalBuilderApp;
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


namespace SurvivalBuilderApp {
    
    
    /// <summary>
    /// Adventure
    /// </summary>
    public partial class Adventure : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\Adventure.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label playerName;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\Adventure.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label playerHealth;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\Adventure.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label playerTemp;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\Adventure.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label playerHunger;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\Adventure.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label goldCount;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\Adventure.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label foodCount;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\Adventure.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label woodCount;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\Adventure.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label stoneCount;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\Adventure.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label worldClockLabel;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\Adventure.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image currentLocation;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\Adventure.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label currentLocationText;
        
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
            System.Uri resourceLocater = new System.Uri("/SurvivalBuilderApp;component/adventure.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Adventure.xaml"
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
            this.playerName = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.playerHealth = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.playerTemp = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.playerHunger = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.goldCount = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.foodCount = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.woodCount = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.stoneCount = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            
            #line 80 "..\..\Adventure.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.save_click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 81 "..\..\Adventure.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.menu_click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 82 "..\..\Adventure.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.quit_click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.worldClockLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 13:
            this.currentLocation = ((System.Windows.Controls.Image)(target));
            return;
            case 14:
            this.currentLocationText = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

