   M S B A M L   `   `   `  ����O  KParkingCourseProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:ParkingCourseProject.ViewsParkingCourseProject.Views  5      ,    &ParkingCourseProject.Views.BuyPassPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:ParkingCourseProject.Views     5        N� 
Background  �#808080 N� Title$ BuyPassPage��5	      .��5      � .+�5   
   �� $)��#Покупка абонемента��6   
�������$��Center=�6@   $��0,71,0,0q�6]   $	��Top=�6o   $��56(�6�   � 5   
   $��Center=�6   $	��Top=�6,   $��0,10,0,0q�6D   .+�5      (  "System.Windows.Controls.DatePicker  -   5          Name$ TextBoxBeginDate��5      $
��Left=�63   $��40��6N   $	��Top=�6[   $	��380��6s   $��	0,255,0,0q�6   $��20(�6�   {�.  5        5      -   5        $ TextBoxEndDate��5      $
��Left=�61   $��40��6L   $	��Top=�6Y   $	��380��6q   $��	0,326,0,0q�6}   $��20(�6�   5      �� 5      -   5        $��Приобрести��5      $��Center=�6+   $	��Top=�6I   $	��380��6b   $��46��6n   $��28(�6z   $��0q�6�   $��	0,515,0,0q�6�    � 	Resources 5       �� 
TargetType �� Property �� Value��%_   '��       �� 5      " ��6   .�5      ��  �@��CornerRadius$ 10��69   5      5      ��5      �� 5       �� ResourceKey$ 
MainButton��6%   5      �� 5      -   5         ��Name$ ErrorMessage��5      $�� ��6   $��Center=�65   
���  ��$��	0,468,0,0q�6c   $	��Top=�6v   $	��380��6�   $��47��6�   �� 5      -   5        	 ��Name$	 TextBoxPrice��5      $��Center=�6,   $��40��6I   
 �� TextWrapping$

 Wrap=�6U   $	��Top=�6j   $	��380��6�   $��	0,428,0,0q�6�   $��20(�6�    �� 
IsReadOnly . .��6�   ��5      �� 5       .R�5!      ��  �� CornerRadius$ 12��6!    �� Padding$ 2q�63   $��3q�6?   
�������._�5"      ��  ��Name$ PART_ContentHost��66   $��0q�6+   ���#c6c6c66P   5#      5$      .��5%   $   5&      �� 5'      
�������$#��Начало действия��6'   $
��Left=�6A   $��	0,221,0,0q�6\   $	��Top=�6o   $��16(�6�   �� 5(      
�������$!��Конец действия��6'   $
��Left=�6@   $��	0,294,0,0q�6[   $	��Top=�6n   $��16(�6�   �� 5)      -   5        $��CheckBoxIsSpecial��5)   ,    J� 
RenderSize$ 100,100��6   
�������$2��,Специальный автомобиль?��6Y   $
��Left=�6{   $��
10,372,0,0q�6�   $	��Top=�6�   $��16(�6�   6�   �� 5*      
�������$��Цена(руб.)��6'   $
��Left=�6<   $��	0,397,0,0q�6W   $	��Top=�6j   $��16(�6�   5+      5,      5-      