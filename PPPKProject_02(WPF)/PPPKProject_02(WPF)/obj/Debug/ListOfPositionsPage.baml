   M S B A M L   `   `   `  ����N  JPPPKProject_02(WPF), Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PPPKProject_02_WPF_PPPKProject_02_WPF_  5      -    'PPPKProject_02_WPF_.ListOfPositionsPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:PPPKProject_02_WPF_     5        N� Title$  ListOfPositionsPage��5	      .��5      �    BrownBackground#��[  6   .+�5   
   �� -   5         ��Name$ 	BtnPeople��5       � ToolTip$ Go to list of people.��5      
������ 
������ $
��Left=�5      $	��Top=�5      $��30��5      $��30��5      $��20q�5      .��5      ��   imagePeople#��[ 6   5      �� 5   
   -   5        $ 
BtnCourses��5      $ Go to list of courses.��5      
������ 
������ $
��Left=�5       $	��Top=�5!      $��30��5"      $��30��5#      $��	55,20,0,0q�5$      .��5&      ��   imageCourses#��[ 6   5'      �� 5)   
   -   5        $��LvPositions��5)   )   $��28,54,26,107q�6    �� AlternationCount$ 2��6<   ��5*      �� 5+       �� 
TargetType" ��6   .�5,      -   5        �� 5-       �� Property � �� �� Value
 ��ح�63    �� Triggers 5.      P� 5/       P� Property �@��AlternationIndex	 P� Value$	 1��6G   . �50      ��  � ��
 �����6;   51      ]� 52      
 ]� 
Conditions
 53      �� 54   "    �� Property �@��
IsSelected �� Value . 6B   ./�56      ��  � ��
 ���_�6;   57      59       �� View 5;      �� 5<      .P�5=      ��  �� Width$	 126��6%   $��Title��61    �� DisplayMemberBinding 6@   �� *Title+5>      5@      �� 5B   
   -   5        $ BtnEdit��5C      $
��Edit��5D      $
��Left=�5E      $	��Top=�5F      $��75��5G      
����������#B5F3FF J� RenderTransformOrigin$ 1.101,3.807&�5J   $   $��574,520,0,0q�6H   �� 5K   
   -   5        $ 	BtnDelete��5L      $��Delete��5M      $
��Left=�5N      $	��Top=�5O      $��75��5P      
����������#FEBEF6$ 1.101,3.807&�5S   %   $��670,520,0,0q�6I   �� 5T   
   -   5        $ BtnAdd��5U      $	��Add��5V      $
��Left=�5W      $	��Top=�5X      $��75��5Y      
����������#A8BAFF$ 1.101,3.807&�5]      $��475,520,0,0q�5^      5_      5`      