   M S B A M L   `   `   `  ���� T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  D @BoyeoZoom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:BoyeoZoom	BoyeoZoom    BoyeoZoom.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:BoyeoZoom       � Title$  
보여ZOOM��$	��800��$
��1400��$��1q�$	��500��$	��400�� � WindowStartupLocation$ CenterScreen=����	#FF2E2E30$��맑은 고딕)� � WindowState$ 	Maximized=�(   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush Z�  � 	Resources    FocusVisual �� Property �� Value J� SnapsToDevicePixels �� StrokeDashArray  Button.Static.Background	 �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 ButtonStyle1
 �� 
TargetType �� 
TargetType ��Name ��Name �� Triggers P� Property P� Value �� 
TargetName��%x  &	        &	 N     &	 c     &	 x     &	 �     &	 �     &	 �     &	 �     &	 �     &		 �     &	
     7   7  7  7  7  7  7  7  7  7 	 �� .���  � �� �� .R��� $��2q� . #��� ��$��1��$	 1 2R��� $	 	#FF2e2e30���� $	 	#FF2e2e30���� $	 	#FF9e9e9e���� $	 	#FF2e2e30���� $	 	#FF2e2e30���� $	 	#FF2e2e30���� $	 	#FF2e2e30���� $	 	#FF2e2e30���� $	 	#FF838383���� "
 ��.���  �@�FocusVisualStyle8   ��  � ��8  ��  � ��8  ��  � ��# � ����  � ��$ 1q���  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R��� $ border��#��z��#��z��#��z�� . ._��� $ contentPresenter��|�.  #��z��#��z����. # z #��z�� P�  �@��IsDefaulted . . ��� $ border��# � �� � ��P�  �@J�IsMouseOver . . ��� $ border��8   � ���� $ border��8   � ��P�  � �� . . ��� $ border��8   � ���� $ border��8   � ��P�  � {� .  . ��� $ border��8   � ���� $ border��8   � ���� $ contentPresenter��8 	  � ��.���  � ColumnDefinitions �� $
��248* ��� $
��199* ��� $
��248* � � RowDefinitions �� $	��31* ��� $	��28* ��� $
��708* �.+�� -    �Name$ Grid_inputCode��$��2��$��0��$��
20,5,20,20q�� -   $ Grid_visualize��$��20,20,20,290.5q�$��2��$��1��� -   $ Grid_efficiency��$��
20,0,20,20q�$��2��$��Bottom=�$��1��$��247.5�� J� RenderTransformOrigin$ 0.5,0.5&�� -   $ Grid_diagrammatic��$��2��$��2��$��20q�]� $��0��$��3��.+�o� ��Z� .@�m� $��파일��
���������Z� .@�m� -   $��_Exit��
���   �m� $��	디버그��
���������Z� .@�m� $��_Manage users��
���   �m� $��_Show groups�� m� IsCheckable .  m� 	IsChecked . 
���   �