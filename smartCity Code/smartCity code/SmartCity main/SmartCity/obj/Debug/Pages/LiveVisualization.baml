   M S B A M L   `   `   `  ����d  `Microsoft.Maps.MapControl.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPFMicrosoft.Maps.MapControl.WPF  5       	SmartCity'   !SmartCity.Pages.LiveVisualization   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      `mRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPF     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� 	KeepAlive  .  N� Title$ LiveVisualization��5
      .��5      � .+�5   
   '   !Microsoft.Maps.MapControl.WPF.Map  -   5          Name$ myMap��5      +   %Microsoft.Maps.MapControl.WPF.MapCore   Center<   6Microsoft.Maps.MapControl.WPF.Design.LocationConverter$ 21.183843,72.808218 5         	ZoomLevel$ 16Q�6*      CredentialsProviderT   NMicrosoft.Maps.MapControl.WPF.Design.ApplicationIdCredentialsProviderConverter$F @Av7tjDXQcLWVTdASoYHbGpaL7kTtAjjoAs0Or0FGcNmbQYLB-87f5lt_RvZ0JKeq 5      $��
0,10,0,-10q�6d   �� 5   
   $	��220��6   ���	#FF020202$	��250��65    J� Opacity$ .3Q�6A   $	��Top=�6N   $
��Left=�6f   ._�5      �  � ShowGridLines .  � ColumnDefinitions 5      �� 5      $	��150 �6'   65   �� 5      $��* �6'   63   	 � RowDefinitions	 5      �� 5      $��70 �6$   62   �� 5      $��* �6$   61   �� 5      $��* �6$   61   �� 5      $��* �6$   61   .+�5      � $��0��6   $��0��6'   .+�5      �� -   5        
 ��Name$
 
zone1_name��5      
�������$��22(�6C   $��	ExtraBold"�6Q   $��Center=�6h   6�   5       � 5!      $��0��6   $��1��6'   .+�5"      �� $��Temperature in °C:��6   
�������$��16(�6L   $��Center=�6Z   6w   5#      � 5$      $��0��6   $��2��6'   .+�5%      �� $��Pressure in Hg:��6   
�������$��16(�6I   $��Center=�6W   6t   5'      � 5(      $��0��6   $��3��6'   .+�5)      �� $��Humidity in gm/m3:��6   
�������$��16(�6L   $��Center=�6Z   6w   5*      � 5+      $��1��6   $��1��6'   .+�5,      �� -   5        $
 lbl_temp��5,      $��00��6.   
�������$��16(�6N   $��Center=�6\   $��Center=�6w   6�   5-      � 5.      $��1��6   $��2��6'   .+�5/      �� -   5        $
 lbl_pressure��5/      $��00��62   
�������$��16(�6R   $��Center=�6`   $��Center=�6{   6�   50      � 51      $��1��6   $��3��6'   .+�52      �� -   5        $
 lbl_humidity��52      $��00��62   
�������$��16(�6R   $��Center=�6`   $��Center=�6{   6�   53      55      56      �� 5:   
   $	��220��6   ���	#FF020202$	��250��65   $ .3Q�6A   $��Bottom=�6N   $
��Left=�6i   ._�5;      �  .  5<      �� 5=      $	��150 �6'   65   �� 5>      $��* �6'   63   	 5@      �� 5A      $��70 �6$   62   �� 5B      $��* �6$   61   �� 5C      $��* �6$   61   �� 5D      $��* �6$   61   .+�5F      � $��0��6   $��0��6'   .+�5G      �� $��Adajan Zone��6   
�������$��22(�6E   $��	ExtraBold"�6S   $��Center=�6j   6�   5H      � 5I      $��0��6   $��1��6'   .+�5J      �� $��Temperature in °C:��6   
�������$��16(�6L   $��Center=�6Z   6w   5K      � 5L      $��0��6   $��2��6'   .+�5M      �� $��Pressure in Hg:��6   
�������$��16(�6I   $��Center=�6W   6t   5O      � 5P      $��0��6   $��3��6'   .+�5Q      �� $��Humidity in gm/m3:��6   
�������$��16(�6L   $��Center=�6Z   6w   5R      � 5T      $��1��6   $��1��6'   .+�5U      �� -   5        $
 lbl_temp_zone2��5U      $��00��64   
�������$��16(�6T   $��Center=�6b   $��Center=�6}   6�   5V      � 5W      $��1��6   $��2��6'   .+�5X      �� -   5        $
 lbl_pressure_zone2��5X      $��00��68   
�������$��16(�6X   $��Center=�6f   $��Center=�6�   6�   5Y      � 5Z      $��1��6   $��3��6'   .+�5[      �� -   5        $
 lbl_humidity_zone2��5[      $��00��68   
�������$��16(�6X   $��Center=�6f   $��Center=�6�   6�   5\      5]      5^      5_      5`      