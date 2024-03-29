﻿#pragma checksum "..\..\DoctorsWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "93917D5CB22FE4BCE1C34A864F531F4C7076687F5501D877076F680174E6902B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DoctorsView;
using DoctorsView.Converters;
using DoctorsView.ViewModels;
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


namespace DoctorsView {
    
    
    /// <summary>
    /// DoctorsWindow
    /// </summary>
    public partial class DoctorsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 52 "..\..\DoctorsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel container;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\DoctorsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label userInfoLabel;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\DoctorsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label currentQueueNo;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\DoctorsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button nextPerson;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\DoctorsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button previousPerson;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\DoctorsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton breakBtn;
        
        #line default
        #line hidden
        
        
        #line 148 "..\..\DoctorsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox forceQueueNoTextBox;
        
        #line default
        #line hidden
        
        
        #line 162 "..\..\DoctorsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button forceQueueSubmitBtn;
        
        #line default
        #line hidden
        
        
        #line 178 "..\..\DoctorsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox additionalMessageTextBox;
        
        #line default
        #line hidden
        
        
        #line 191 "..\..\DoctorsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button clearAddMessageBtn;
        
        #line default
        #line hidden
        
        
        #line 197 "..\..\DoctorsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button sendAddMessageSubmitBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/DoctorsView;component/doctorswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\DoctorsWindow.xaml"
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
            
            #line 47 "..\..\DoctorsWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.OptionsBtn_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.container = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 3:
            this.userInfoLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            
            #line 99 "..\..\DoctorsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Show_Options_ContextMenu);
            
            #line default
            #line hidden
            return;
            case 5:
            this.currentQueueNo = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.nextPerson = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.previousPerson = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.breakBtn = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            return;
            case 9:
            this.forceQueueNoTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 150 "..\..\DoctorsWindow.xaml"
            this.forceQueueNoTextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidation_PreviewTextBox);
            
            #line default
            #line hidden
            return;
            case 10:
            this.forceQueueSubmitBtn = ((System.Windows.Controls.Button)(target));
            return;
            case 11:
            this.additionalMessageTextBox = ((System.Windows.Controls.RichTextBox)(target));
            return;
            case 12:
            this.clearAddMessageBtn = ((System.Windows.Controls.Button)(target));
            return;
            case 13:
            this.sendAddMessageSubmitBtn = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

