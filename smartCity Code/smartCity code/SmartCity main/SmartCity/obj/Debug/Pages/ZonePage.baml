   M S B A M L   `   `   `  ����d  `Microsoft.Maps.MapControl.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPFMicrosoft.Maps.MapControl.WPF  5       	SmartCity   SmartCity.Pages.ZonePage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      `mRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPF     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $	��400��5	      $	��700��6     N� Title$  ZonePage��5
      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��auto �6   6.   �� 5      $��* �6   6+   .+�5   
   � -   5         �Name$ grid1��5      $��0��6    � RowDefinitions 5      �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   .+�5      � -   5        $��0��5      .+�5      �� -   5         ��Name$ border_live��5      ���	#FF3399FF$��50��6F   ._�5      �� $��Center=�6   $��Center=�68   
�������$��20(�6h   $
��Bold"�6v   .��6�   Live Visualization6�   5      5      � 5      -   5        $ 	grid_data��5      $��1��6&   $��0,10,0,0q�63   .+�5      ��  �� Orientation$ Vertical=�6   .+�5      �� -   5        $ border_data��5      ���	#FF3399FF$��50��6F   ._�5       �� $��Center=�6   $��Center=�68   
�������$��20(�6h   $
��Bold"�6v   .��6�   Data Visualization6�   5!      �� 5"      -   5        $ border_crime��5"      ���	#FF020202 J� Opacity$ .5Q�6J   ._�5#      �� $��Center=�6!   $��Center=�6<   
�������$��18(�6l   .��6{   
Crime Rate6�   5$      �� 5%      -   5        $ border_population��5%      ���	#FF020202$ .5Q�6O   ._�5&      �� $��Center=�6!   $��Center=�6<   
�������$��18(�6l   .��6{   
Population6�   5'      �� 5(      -   5        $ border_environment��5(      ���	#FF020202$ .5Q�6P   ._�5)      �� $��Center=�6!   $��Center=�6<   
�������$��18(�6l   .��6{   Environment6�   5*      �� 5+      -	   5        $ border_fire��5+      ���	#FF020202$ .5Q�6I   ._�5,      �� $��Center=�6!   $��Center=�6<   
�������$��18(�6l   .��6{   Fire History6�   5-      5/      50      53      � 54   
   $��1��6   .+�56       � -
   5          �Name$ 	ZoneFrame��56        � Source$7 1/SmartCity;component/Pages/LiveVisualization.xaml?�6'   6d   �� 58      -   5        	 ��Name$	 	img_arrow��58      $��..\Images\rightarrow.png��6'   $��50��6I   $��50��6U   $��Uniform=�6`   $
��Left=�6�   6�   5:      5<      5=      