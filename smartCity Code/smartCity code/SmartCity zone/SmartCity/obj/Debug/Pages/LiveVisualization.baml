   M S B A M L   `   `   `  ����d  `Microsoft.Maps.MapControl.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPFMicrosoft.Maps.MapControl.WPF  5       	SmartCity'   !SmartCity.Pages.LiveVisualization   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      `mRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPF     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� 	KeepAlive  .  N� Title$ LiveVisualization��5
      .��5      � .+�5   
   '   !Microsoft.Maps.MapControl.WPF.Map  -   5          Name$ myMap��5      +   %Microsoft.Maps.MapControl.WPF.MapCore   Center<   6Microsoft.Maps.MapControl.WPF.Design.LocationConverter$ 21.183843,72.808218 5         	ZoomLevel$ 16Q�6*      CredentialsProviderT   NMicrosoft.Maps.MapControl.WPF.Design.ApplicationIdCredentialsProviderConverter$F @Av7tjDXQcLWVTdASoYHbGpaL7kTtAjjoAs0Or0FGcNmbQYLB-87f5lt_RvZ0JKeq 5      6�   �� 5   
   $	��280��6   ���	#FF020202$	��250��65    J� Opacity$ .3Q�6A   $	��Top=�6N   $
��Left=�6f   ._�5      �  � ShowGridLines .  � ColumnDefinitions 5      �� 5      $	��150 �6'   65   �� 5      $��* �6'   63   	 � RowDefinitions	 5      �� 5      $��70 �6$   62   �� 5      $��* �6$   61   �� 5      $��* �6$   61   �� 5      $��* �6$   61   �� 5      $��* �6$   61   �� 5      $��* �6$   61   �� 5      $��* �6$   61   .+�5!      � $��0��6   $��0��6'   .+�5"      �� $��
Athwa Zone��6   
�������$��22(�6D   $��	ExtraBold"�6R   $��Center=�6i   6�   5#      � 5$      $��0��6   $��1��6'   .+�5%      �� $��Temperature in °C:��6   
�������$��16(�6L   $��Center=�6Z   6w   5&      � 5'      $��0��6   $��2��6'   .+�5(      �� $��Pressure in Hg:��6   
�������$��16(�6I   $��Center=�6W   6t   5*      � 5+      $��0��6   $��3��6'   .+�5,      �� $��Humidity in gm/m3:��6   
�������$��16(�6L   $��Center=�6Z   6w   5-      � 5.      $��0��6   $��4��6'   .+�5/      �� $��Fire status:��6   
�������$��16(�6F   $��Center=�6T   6q   50      � 51      $��0��6   $��5��6'   .+�52      �� $��Rain1 status:��6   
�������$��16(�6G   $��Center=�6U   6r   53      � 54      $��0��6   $��6��6'   .+�55      �� $��Rain2 status:��6   
�������$��16(�6G   $��Center=�6U   6r   56      � 57      $��1��6   $��1��6'   .+�58      �� -   5        
 ��Name$
 lbl_temp��58      $��00��6.   
�������$��16(�6N   $��Center=�6\   $��Center=�6w   6�   59      � 5:      $��1��6   $��2��6'   .+�5;      �� -   5        $
 lbl_pressure��5;      $��00��62   
�������$��16(�6R   $��Center=�6`   $��Center=�6{   6�   5<      � 5=      $��1��6   $��3��6'   .+�5>      �� -   5        $
 lbl_humidity��5>      $��00��62   
�������$��16(�6R   $��Center=�6`   $��Center=�6{   6�   5?      � 5@      $��1��6   $��4��6'   .+�5A      �� -   5        $
 lbl_firestatus��5A      $��-��64   
�������$��16(�6S   $��Center=�6a   $��Center=�6|   6�   5B      � 5C      $��1��6   $��5��6'   .+�5D      �� -   5        $
 lbl_rain1status��5D      $��-��65   
�������$��16(�6T   $��Center=�6b   $��Center=�6}   6�   5E      � 5F      $��1��6   $��6��6'   .+�5G      �� -   5        $
 lbl_rain2status��5G      $��-��65   
�������$��16(�6T   $��Center=�6b   $��Center=�6}   6�   5H      5J      5K      5M      5N      