   M S B A M L   `   `   `  ����d  `Microsoft.Maps.MapControl.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPFMicrosoft.Maps.MapControl.WPF  5       	SmartCity    SmartCity.Pages.Population   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      `mRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPF     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� 	KeepAlive  .  N� Title$ 
Population��5
      .��5      � .+�5   
   '   !Microsoft.Maps.MapControl.WPF.Map  -   5          Name$ myMap��5      +   %Microsoft.Maps.MapControl.WPF.MapCore   Center<   6Microsoft.Maps.MapControl.WPF.Design.LocationConverter$ 21.183843,72.808218 5         	ZoomLevel$ 14Q�6*      CredentialsProviderT   NMicrosoft.Maps.MapControl.WPF.Design.ApplicationIdCredentialsProviderConverter$F @Av7tjDXQcLWVTdASoYHbGpaL7kTtAjjoAs0Or0FGcNmbQYLB-87f5lt_RvZ0JKeq 5      $��
0,-10,0,10q�6d   �� 5   
   $	��220��6   ���	#FF020202$	��250��65    J� Opacity$ .3Q�6A   $	��Top=�6N   $
��Left=�6f   ._�5      �  � ShowGridLines .  � ColumnDefinitions 5      �� 5      $	��180 �6'   65   �� 5      $��* �6'   63   	 � RowDefinitions	 5      �� 5      $��70 �6$   62   �� 5      $��* �6$   61   �� 5      $��* �6$   61   �� 5      $��* �6$   61   .+�5      � $��0��6   $��0��6'   .+�5      �� $��
Population��6   
�������$��22(�6D   $��	ExtraBold"�6R   $��Center=�6i   6�   5      � 5      $��0��6   $��1��6'   .+�5       �� $��less than 2 Lac��6   
�������$��16(�6I   $��Center=�6W   6t   5!      � 5"      $��0��6   $��2��6'   .+�5#      �� $��between 2 lac and 5 lac��6   
�������$��16(�6Q   $��Center=�6_   6|   5%      � 5&      $��0��6   $��3��6'   .+�5'      �� $��more than 5 lac��6   
�������$��16(�6I   $��Center=�6W   6t   5(      � 5)      $��1��6   $��1��6'   .+�5*      �� $��30��6   $��30��6)   
��� � �6I   5+      � 5,      $��1��6   $��2��6'   .+�5-      �� $��30��6   $��30��6)   
��� ���6J   5.      � 5/      $��1��6   $��3��6'   .+�50      �� $��30��6   $��30��6)   
���  ��6G   51      53      54      �� 56   
   $��30��6   $	��100��6   $	��Top=�6(   $��Right=�6@   $��14(�6\   $��0,0,30,0q�6j   .��6|   Select Year6�   �� 57   
   $��25��6   ���	#FF020202$��50��64   $ .3Q�6?   $	��Top=�6L   $��Right=�6d   ._�59      �� -   5        
 ��Name$
 comboboxyear��59      .@�5:      �� $
��1991��6   �� 5;      $
��2001��6   �� 5<      $
��2011��6   5=      5>      5@      5A      