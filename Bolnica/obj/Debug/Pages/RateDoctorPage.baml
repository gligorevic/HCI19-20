   M S B A M L   `   `   `  ����B  >Bolnica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Bolnica.PagesBolnica.Pages  5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466J6clr-namespace:FontAwesome.WPF;assembly=FontAwesome.WPFFontAwesome.WPF 5      "    Bolnica.Pages.RateDoctorPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Bolnica.Pages     5      Efa6clr-namespace:FontAwesome.WPF;assembly=FontAwesome.WPF     5        N� Title$  OceniLekaraPage��5
      .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $��5* �6   �� 5      $��1* �6   .+�5   
   �� $��0��6   $��0��6%   $��2��62   $��Center=�6F   $��60q�6c   .+�5      �� $��Oceni lekara��6   $��25(�6,    �� TextAlignment$ Center=�6:   � 5      $��0, 45q�6   $��Center=�6'   .+�5      "  FontAwesome.WPF.ImageAwesome     Icon$ UserPlus=�6"   $��Center=�62   $��Center=�6M   $��30��6j   �� 5      $��Center=�68   $��13,0,0,0q�6S   $��18(�6f   ��6   �� *
DoctorName+6f   5      � 5      $��0, 60q�6   .+�5      �� $��Unesite ocenu:��6   $��22(�62   �� 5      -   5        
������ $��15, 0, 0, 0q�5   Q   $��0q�6f   .��5        $ MinusCircle=�6&   $��Center=�69   $��Center=�6T   $��30��6q    � Cursor$
 Hand��6}    � ToolTip$ Smanji ocenu��6�   5      �� 5      -   5         ��Name$ patientRateBox��5      $��30��62   $��35��6=   $
��15,0q�6I   $��20(�6t   $��Center=�6�   $��Center=�6�   ��6W   �� *PatientRate+6�   �� 5       -   5        
������ $��0q�5    P   .��5!        $ 
PlusCircle=�6&   $��Center=�68   $��Center=�6S   $��30��6p   $
 Hand��6|   $ Povecaj ocenu��6�   5"      5#      5$      �� 5%   
   -   5        $$ Vrati se na prethodnu stranicu��5%      $��20(�6:   $��0��6H   $��1��6X   $	��200��6e   $��45��6q    � 	Resources 5&      	 �� 
TargetType
 �� Property �� Value��%^   '��       �� 5'      "	 ��6   .�5(      �� 
 �@��CornerRadius$ 6��65   5)      5*      .��6    Nazad6(   �� 5+   
   $��20(�6   $��1��6   $��1��6/   $	��200��6<   $��45��6H   $ Potvrdi unetu ocenu��6T    5,      ��%^   '��       �� 5-      "	 ��6   .�5.      �� 
 �@��CornerRadius$ 6��65   5/      50      .��6    Oceni6(   51      52      