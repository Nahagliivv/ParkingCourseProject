   M S B A M L   `   `   `  ����O  KParkingCourseProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:ParkingCourseProject.ViewsParkingCourseProject.Views  5      &     ParkingCourseProject.Views.Place   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:ParkingCourseProject.Views     5        N� 
Background  �#808080 N� Title$ Place��5	      .��5      � .+�5   
   �� ���#c6c6c6$8��2Выберите парковочное место��6%   $��Right=�6J   $��
0,10,336,0q�6f   $	��Top=�6z   $��56(�6�   $	��865��6�   �� 5   
   -   5         ��Name$ TextBoxTransportNumber��5      $
��Left=�62   $��40��6M    �� TextWrapping$
 Wrap=�6Y   $	��Top=�6n   $	��169��6�   $��
79,135,0,0q�6�   $��20(�6�   .��6�   ��5      �� 5      .R�5      ��  �� CornerRadius$ 12��6    �� Padding$ 2q�6/   $��3q�6;   
�������._�5      ��  ��Name$ PART_ContentHost��62   $��0q�6'   ���#c6c6c66L   5      5      .��5       5      �� 5   
   
�������$&�� Номер транспорта:��6#   $
��Left=�6?   $��	79,94,0,0q�6Z   $	��Top=�6m   $��18(�6�   �� 5   
   -   5        $ ��Забронировать��5      $
��Left=�6*   $	��Top=�6F   $	��270��6_   $��38��6k   $��28(�6w   $��0q�6�   $��368,135,0,0q�6�    � 	Resources 5       �� 
TargetType	 �� Property
 �� Value��%_   '��       �� 5      " ��6   .�5      �� 	 �@��CornerRadius$
 10��65   5      5      ��5      �� 5       �� ResourceKey$ 
MainButton��6!   5       �� 5!   
   $��71,178,76,0q�65   $
��auto��6J   ���#808080��.  $��Disabled=�6�   $��0q�6�   ��6   �� *
PlaceViews+ �� SelectedItem 6�   �� *selectedPlace+��5"      �� 5#      .R�5$      1   +ParkingCourseProject.Views.ParkingPlaceView  6/   5%      ��5'      �� 5(      .R�5)      � 5*      5,      �� 5-   
   -   5         ��Name$ ErrorMessage��5-      
���  ��$
��Left=�67   $��643,141,0,0q�6R   $	��Top=�6g   $	��390��6   $��26��6�   5.      5/      