   M S B A M L   `   `   `  ����D  @BoyeoZoom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:BoyeoZoom	BoyeoZoom  5      &     BoyeoZoom.UserControl_efficiency   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:BoyeoZoom     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $��22 �6   �� 5      .+�5   
   �� -   5         ��Name$ 	textBlock��5      $��0��6'   $
��Left=�64   $
��Wrap=�6O   $��Status��6c   $	��100��6q   ���	#FFFF6A00
������� �� Padding$ 10,5,0,0q�6�   $��Consolas)�6�   $��14(�6�   �� 5   
   ���	#FF848484$��1,0,1,1q�6)   $��1��6C   ���	#FF2728225      �� 5   
   ���	#FFFF6A00$��4��6&   $	��Top=�61   ���	#FFFF6A00$��
0,-1.5,0,0q�6]   $��1��6q   $��1��6�   �� 5   
   $
��Left=�6   $��	16,23,0,0q�6/   $��1��6B   $��24��6V   $��20��6a   $��1��6m   $	��Top=�6z    J� RenderTransformOrigin$ -0.083,0.119&�6�   ��5      �� 5       �� ImageSource$ image/img_runtime.png��6    j� Stretch$ Uniform=�6A   5      �� 5   
   $
��Left=�6   $��20��6/   $��	16,54,0,0q�6;   $��1��6N   $��1��6[   $	��Top=�6o   $��24��6�   ��5      �� 5      $ image/img_memory.png��6   $ Uniform=�6@   5      �� 5   
   -   5         ��Name$ label_execute��5      $��Execute Time : ��6'   $
��Left=�6A   $��	44,20,0,0q�6\   $	��Top=�6o   
�������$��1��6�   $��26��6�   $��93��6�   �� 5   
   -   5        $ label_memory��5      $��Used Memory : ��6&   $
��Left=�6?   $��	44,51,0,0q�6Z   $	��Top=�6m   
�������$��1��6�   $��26��6�   $��98��6�   �� 5   
   -   5        $ text_excute��5      $��
138,0,0,67q�6)   $
��Wrap=�6=   $��68.574 s��6Q   $��Bottom=�6a   $
��Left=�6|   ���	#FF9E76E1$��16��6�   $	��102��6�   $��1��6�   �� 5   
   -   5        $ text_memory��5      $��
142,0,0,36q�6)   $
��Wrap=�6=   $��6.23 kb��6Q   $��Bottom=�6`   $
��Left=�6{   ���	#FF64CEA8$��16��6�   $	��102��6�   $��1��6�   5       5!      