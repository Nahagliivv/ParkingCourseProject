﻿#pragma checksum "..\..\..\Views\MyCarsPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B8A8A1D9F45B181C7A8176829B14714068876B11B61B7CB24178B112FE295239"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ParkingCourseProject.Views;
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


namespace ParkingCourseProject.Views {
    
    
    /// <summary>
    /// MyCarsPage
    /// </summary>
    public partial class MyCarsPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\Views\MyCarsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse EllipsePicture;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Views\MyCarsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.ImageBrush CarImage;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Views\MyCarsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxBrand;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Views\MyCarsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxNumber;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Views\MyCarsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxColor;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Views\MyCarsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ErrorMessage;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\Views\MyCarsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox IsSpecial;
        
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
            System.Uri resourceLocater = new System.Uri("/ParkingCourseProject;component/views/mycarspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\MyCarsPage.xaml"
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
            this.EllipsePicture = ((System.Windows.Shapes.Ellipse)(target));
            
            #line 12 "..\..\..\Views\MyCarsPage.xaml"
            this.EllipsePicture.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.EllipsePicture_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CarImage = ((System.Windows.Media.ImageBrush)(target));
            return;
            case 3:
            this.TextBoxBrand = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TextBoxNumber = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.TextBoxColor = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            
            #line 45 "..\..\..\Views\MyCarsPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ErrorMessage = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            
            #line 63 "..\..\..\Views\MyCarsPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 9:
            this.IsSpecial = ((System.Windows.Controls.CheckBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

