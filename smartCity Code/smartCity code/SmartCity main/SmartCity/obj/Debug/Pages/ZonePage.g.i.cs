﻿#pragma checksum "..\..\..\Pages\ZonePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "826B3126C03A9E1454C150235C3CEB6B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Maps.MapControl.WPF;
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


namespace SmartCity.Pages {
    
    
    /// <summary>
    /// ZonePage
    /// </summary>
    public partial class ZonePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\Pages\ZonePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid1;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Pages\ZonePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border border_live;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Pages\ZonePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid_data;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Pages\ZonePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border border_data;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Pages\ZonePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border border_crime;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Pages\ZonePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border border_population;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Pages\ZonePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border border_environment;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Pages\ZonePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border border_fire;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\Pages\ZonePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame ZoneFrame;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\Pages\ZonePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image img_arrow;
        
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
            System.Uri resourceLocater = new System.Uri("/SmartCity;component/pages/zonepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\ZonePage.xaml"
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
            this.grid1 = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            
            #line 24 "..\..\..\Pages\ZonePage.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.onLiveEnter);
            
            #line default
            #line hidden
            return;
            case 3:
            this.border_live = ((System.Windows.Controls.Border)(target));
            
            #line 25 "..\..\..\Pages\ZonePage.xaml"
            this.border_live.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.onLiveVisualizationClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.grid_data = ((System.Windows.Controls.Grid)(target));
            
            #line 29 "..\..\..\Pages\ZonePage.xaml"
            this.grid_data.MouseEnter += new System.Windows.Input.MouseEventHandler(this.onGridDataEnter);
            
            #line default
            #line hidden
            return;
            case 5:
            this.border_data = ((System.Windows.Controls.Border)(target));
            
            #line 31 "..\..\..\Pages\ZonePage.xaml"
            this.border_data.MouseEnter += new System.Windows.Input.MouseEventHandler(this.onDataBorderEnter);
            
            #line default
            #line hidden
            
            #line 31 "..\..\..\Pages\ZonePage.xaml"
            this.border_data.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.onDataVisualizationClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.border_crime = ((System.Windows.Controls.Border)(target));
            
            #line 34 "..\..\..\Pages\ZonePage.xaml"
            this.border_crime.MouseEnter += new System.Windows.Input.MouseEventHandler(this.onCrimeEnter);
            
            #line default
            #line hidden
            
            #line 34 "..\..\..\Pages\ZonePage.xaml"
            this.border_crime.KeyUp += new System.Windows.Input.KeyEventHandler(this.onCrimeClick);
            
            #line default
            #line hidden
            
            #line 34 "..\..\..\Pages\ZonePage.xaml"
            this.border_crime.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.border_crime_MouseUp);
            
            #line default
            #line hidden
            return;
            case 7:
            this.border_population = ((System.Windows.Controls.Border)(target));
            
            #line 37 "..\..\..\Pages\ZonePage.xaml"
            this.border_population.MouseEnter += new System.Windows.Input.MouseEventHandler(this.onPopulationEnter);
            
            #line default
            #line hidden
            
            #line 37 "..\..\..\Pages\ZonePage.xaml"
            this.border_population.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.onPopulationClick);
            
            #line default
            #line hidden
            return;
            case 8:
            this.border_environment = ((System.Windows.Controls.Border)(target));
            
            #line 40 "..\..\..\Pages\ZonePage.xaml"
            this.border_environment.MouseEnter += new System.Windows.Input.MouseEventHandler(this.onEnvironmentEnter);
            
            #line default
            #line hidden
            return;
            case 9:
            this.border_fire = ((System.Windows.Controls.Border)(target));
            
            #line 43 "..\..\..\Pages\ZonePage.xaml"
            this.border_fire.MouseEnter += new System.Windows.Input.MouseEventHandler(this.onFireEnter);
            
            #line default
            #line hidden
            return;
            case 10:
            this.ZoneFrame = ((System.Windows.Controls.Frame)(target));
            return;
            case 11:
            this.img_arrow = ((System.Windows.Controls.Image)(target));
            
            #line 56 "..\..\..\Pages\ZonePage.xaml"
            this.img_arrow.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.onRightArroeClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

