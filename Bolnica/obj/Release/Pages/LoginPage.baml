   M S B A M L   `   `   `  ���� B  >Bolnica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Bolnica.PagesBolnica.Pages      Bolnica.Pages.LoginPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -localclr-namespace:Bolnica.Pages       N� Title$  	LoginPage��.���� $��220,100q�
���   �$��1q� �� CornerRadius$ 18�� �� Padding$ 75, 10q�
�������._��  � ColumnDefinitions �� $��1* � � RowDefinitions �� $
��3.0* ��� $��1* ��� $��1* ��� $��1* �.+�� -    �Name$ 	firstStep��$��0��$��0�� �� $
��0.3* ��� $��1* � �� $
��1.0* ��� $
��2.0* �.+��� $��30(�$��Center=�$��Center=�$��0��$��0��$��2��
Prijavi se�� $��0��$��1��$��22(�$��Center=�Email:�� $��1��$��1��$��22(�$��10,0,0,0q�$��Center=�����  �� Path$ Email� �� Mode$ OneWayToSource=� �� UpdateSourceTrigger$ PropertyChanged=�� -   $ 
secondStep��$y�Hidden=�$��0��$��0�� �� $
��0.3* ��� $��1* � �� $
��1.2* ��� $
��1.0* ��� $
��2.0* �.+��� $��30(�$��Center=�$��Center=�$��0��$��0��$��2��Petar Petrovic�� $��1q�
���   �$��0��$��1��$��2��$��25��$	��320��$ 8��._��� -   	 ��Name$	 	useremail��$��18(�$��Center=�$��Center=����� $ 
FoundEmail�$ OneWay=�$ PropertyChanged=��� $��0��$��2��$��22(�$��Center=�
Lozinka:G� $��1��$��2��$��22(�$��10,0,0,0q�$��Center=��� -   
 ��Name$
 ContinueButton��$��1��$��45��$��20(� � 	Resources  �� 
TargetType �� Property �� Value��%9   '��       �� " ��.���  �@��CornerRadius$ 6��.��	Nastavi�� -   $
 
BackButton��$��2��$��45��$��20(� � ToolTip$ Vrati se nazad�� ��%9   '��       �� " ��.���  �@��CornerRadius$ 6��.��Nazad�� -   $	 forgotenButton�� � Cursor$
 Hand��$��22(�$
��Left=�$	��Top=�$��0��$��3��$��	UnderLine{����� " ��.���  � �� �#466DB2 �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  � �� �#264D92Zaboravljen mail?