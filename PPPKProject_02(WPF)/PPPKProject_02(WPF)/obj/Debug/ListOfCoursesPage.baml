   M S B A M L   `   `   `  ����N  JPPPKProject_02(WPF), Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PPPKProject_02_WPF_PPPKProject_02_WPF_  5      +    %PPPKProject_02_WPF_.ListOfCoursesPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:PPPKProject_02_WPF_     5        N� Title$  ListOfCoursesPage��5	      .��5      �    BrownBackground#��[  6   .+�5   
   �� -   5         ��Name$ 	BtnPeople��5       � ToolTip$ Go to list of people.��5      
������ 
������ $
��Left=�5      $	��Top=�5      $��30��5      $��30��5      $��20q�5      .��5      ��   imagePeople#��[ 6   5      �� 5   
   -   5        $ BtnPositions��5      $ Go to list of positions.��5      
������ 
������ $
��Left=�5       $	��Top=�5!      $��30��5"      $��30��5#      $��	55,19,0,0q�5$      .��5&      ��   imagePosition#��[ 6   5'      �� 5)   
   -   5        $��	LvCourses��5)   )   $��28,54,26,107q�6    �� AlternationCount$ 2��6:   ��5*      �� 5+       �� 
TargetType" ��6   .�5,      -   5        �� 5-       �� Property � �� �� Value
 ��ح�63    �� Triggers 5.      P� 5/       P� Property �@��AlternationIndex	 P� Value$	 1��6G   . �50      ��  � ��
 �����6;   51      ]� 52      
 ]� 
Conditions
 53      �� 54   "    �� Property �@��
IsSelected �� Value . 6B   ./�56      ��  � ��
 ���_�6;   57      59       �� View 5;      �� 5<      .P�5=      ��  �� Width$	 126��6%   $��Title��61    �� DisplayMemberBinding 6@   �� *Title+�� 5>      $	 126��6%   $
��ECTS��61    6?   �� *ECTS+�� 5?      $	 126��6%   $�� ��61    �� CellTemplate 5@      �� 5A      .R�5B   "   �� $ 
btnDetails��5C   %   -   5        
������ 
������ 
 � Tag 5G   %   �� *
IDCourse+.��5H   &   �� $��Assets/look.png��6,   $��20��6E   $��5q�6P   5I   #   5J      5L      5M      5O      �� 5Q   
   -   5        $ BtnEdit��5R      $
��Edit��5S      $
��Left=�5T      $	��Top=�5U      $��75��5V      
����������#B5F3FF J� RenderTransformOrigin$ 1.101,3.807&�5Y   $   $��574,520,0,0q�6H   �� 5Z   
   -   5        $ 	BtnDelete��5[      $��Delete��5\      $
��Left=�5]      $	��Top=�5^      $��75��5_      
����������#FEBEF6$ 1.101,3.807&�5b   %   $��670,520,0,0q�6I   �� 5c   
   -   5        $ BtnAdd��5d      $	��Add��5e      $
��Left=�5f      $	��Top=�5g      $��75��5h      
����������#A8BAFF$ 1.101,3.807&�5l      $��475,520,0,0q�5m      5n      5o      