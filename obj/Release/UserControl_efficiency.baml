   M S B A M L   `   `   `  ���� D  @BoyeoZoom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:BoyeoZoom	BoyeoZoom  &     BoyeoZoom.UserControl_efficiency   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     )localclr-namespace:BoyeoZoom     .���   � RowDefinitions  �� $��5* ��� $	��57* �.+��� -    ��Name$ 	textBlock��$��0��$
��Left=�$
��Wrap=�$��STATUS��$��80�� �� TextAlignment$ Center=����	#FFFF6A00
��������� ���	#FF848484$��1,0,1,1q�$��1�����	#FF252621�� $��1�����	#FFFF6A00$��3��$	��Top=����	#FFFF6A00$��1���� $
��Left=�$��15.999,23.163,0,0q�$��1��$��24��$��20��$��1��$	��Top=� J� RenderTransformOrigin$ -0.083,0.119&�����  �� ImageSource$ image/img_runtime.png�� j� Stretch$ Uniform=��� $
��Left=�$��20��$��15.999,54.053,0,0q�$��1��$��1��$	��Top=�$��24������ $ image/img_memory.png��$ Uniform=��� -    ��Name$ label_execute��$��Execute Time : ��$
��Left=�$��44.332,20.183,0,0q�$	��Top=�
�������$��1���� -   $ label_memory��$��Used Memory : ��$
��Left=�$��44.332,51.073,0,0q�$	��Top=�
�������$��1���� -   $ text_excute��$��131.474,0,0,185.063q�$
��Wrap=�$��68.574 s��$��Bottom=�$��1��$
��Left=����	#FF9E76E1�� -   $ text_memory��$��137.473,0,0,154.173q�$
��Wrap=�$��6.23 kb��$��Bottom=�$��1��$
��Left=����	#FF64CEA8