   M S B A M L   `   `   `  ����B  >Bolnica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Bolnica.ModalsBolnica.Modals  5   	   (    "Bolnica.Modals.ChangePasswordModal   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Bolnica.Modals     5   	     � Title$  Promeni Lozinku��5   	   $	��300��6!   $	��430��6.    � 
ResizeMode$ NoResize=�5
   	    +� FocusedElement 5	   	   %  System.Windows.Markup.Reference  *	oldPass+.��5      � $��30q�6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��0.35* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   �� $��0��6   $��0��6$   $��18(�61   $��Center=�6@   Stara lozinka:6k   G� 5   
   -   5         G�Name$ oldPass��5      $��0��5      $��1��6   $��25��5      �� 5   
   $��0��6   $��1��6   $��2��6,   $��Stretch=�6@   $��Center=�6^   
���   � �� StrokeDashArray$	 2 2R�5       $��1��6%   	 �� X2 5      �� *ActualWidth+ �� RelativeSource �� *Self+5    %   �� 5"   
   $��0��6   $��2��6$   $��18(�61   $��Center=�6@   Nova lozinka:6j   G� 5#   
   -   5        $ PasswordBox1��5#      $��2��5$      $��1��6   $��25��5%      �� 5'   
   $��0��6   $��3��6$   $��18(�61   $��Center=�6@   Ponovi lozinku:6l   G� 5(   
   -   5        $ PasswordBox2��5(      $��3��5)      $��1��6   $��25��5*      �� 5,   
   -   5        $��0��5,      $��4��6!   $��0, 10, 20, 3q�6.   $��20(�6D   	 � ToolTip$ 	 Nazad na korisnicki profil��6R   
 �� IsCancel
 .  � 	Resources 5-       �� 
TargetType �� Property �� Value��%^   '��       �� 5.      " ��6   .�5/      ��  �@��CornerRadius$ 6��65   50      51      .��6    Nazad6(   �� 52   
   -   5        $��1��52      $��4��6!   $��20, 10, 0, 3q�6.   $��20(�6D   $	 Potvrdi izmenu lozinke��6R    53      ��%^   '��       �� 54      " ��6   .�55      ��  �@��CornerRadius$ 6��65   56      57      .��6    	Potvrdi6*   58      59      