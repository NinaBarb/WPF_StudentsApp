   M S B A M L   `   `   `  ����N  JPPPKProject_02(WPF), Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PPPKProject_02_WPF_PPPKProject_02_WPF_  5      *    $PPPKProject_02_WPF_.ListOfPeoplePage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:PPPKProject_02_WPF_     5        N� Title$  ListOfPeoplePage��5	      .��5      �    BrownBackground#��[  6   .+�5   
   �� -   5         ��Name$ 
BtnCourses��5       � ToolTip$ Go to list of courses.��5      
������ 
������ $
��Left=�5      $	��Top=�5      $��30��5      $��30��5      $��20q�5      .��5      ��   imageCourses#��[ 6   5      �� 5   
   -   5        $ BtnPosition��5      $ Go to positions.��5      
������ 
������ $
��Left=�5       $	��Top=�5!      $��30��5"      $��30��5#      $��	55,20,0,0q�5$      .��5&      ��   imagePosition#��[ 6   5'      �� 5)   
   -   5        $��LvUsers��5)   )   $��28,54,26,107q�6    �� AlternationCount$ 2��68   ��5*      �� 5+       �� 
TargetType" ��6   .�5,      -   5        �� 5-       �� Property � �� �� Value
 ��ح�63    �� Triggers 5.      P� 5/       P� Property �@��AlternationIndex	 P� Value$	 1��6G   . �50      ��  � ��
 �����6;   51      ]� 52      
 ]� 
Conditions
 53      �� 54   "    �� Property �@��
IsSelected �� Value . 6B   ./�56      ��  � ��
 ���_�6;   57      59       �� View 5;      �� 5<      .P�5=      ��  �� Width$	 126��6%   $��	FirstName��61    �� DisplayMemberBinding 6D   �� *	FirstName+�� 5>      $	 126��6%   $��LastName��61    6C   �� *
LastName+�� 5?      $	 126��6%   $	��Age��61    6>   �� *Age+�� 5@      $	 126��6%   $��Email��61    �� CellTemplate 5A      �� 5B      .R�5C   "   �� $��	Underline{�6C   
���   � � Cursor$
 Hand��6r   ��6,   �� *Email+ 5D   &   �� 5E   *    ��Name$ Picture��60   $��60��6Z   $��60��6e   $��0,0,5,0q�6q   ��6A   �� *Image+6q   5G   #   5H      5J      �� 5K      $	 126��6%   $��JMBAG��61    6@   �� *JMBAG+�� 5L      $	 126��6%   $��Gender��61    6A   �� *Gender+5N      5P      �� 5R   
   -   5        $ BtnEdit��5S      $
��Edit��5T      $
��Left=�5U      $	��Top=�5V      $��75��5W      
����������#B5F3FF$��574,520,0,0q�5Z   #   �� 5[   
   -   5        $ 	BtnDelete��5\      $��Delete��5]      $
��Left=�5^      $	��Top=�5_      $��75��5`      
����������#FEBEF6$��671,520,0,0q�5c   %   �� 5d   
   -   5        $ BtnAdd��5e      $	��Add��5f      $
��Left=�5g      $	��Top=�5h      $��75��5i      
����������#A8BAFF$��474,520,0,0q�5l   "   5n      5o      