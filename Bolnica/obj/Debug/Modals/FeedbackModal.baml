   M S B A M L   `   `   `  ����B  >Bolnica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Bolnica.ModalsBolnica.Modals  5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466J6clr-namespace:FontAwesome.WPF;assembly=FontAwesome.WPFFontAwesome.WPF 5   	   "    Bolnica.Modals.FeedbackModal   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Bolnica.Modals     5   	   Efa6clr-namespace:FontAwesome.WPF;assembly=FontAwesome.WPF     5   	     � 
ResizeMode$  NoResize=�5	   	    � Title$ FeedbackModal��5
   	   $	��300��6   $	��450��6,    � WindowStartupLocation$ CenterOwner=�68   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��0.3* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��2* �6   �� 5      $��1* �6   .+�5   
   "  FontAwesome.WPF.ImageAwesome  -   5          Name$ infoIcon��5         Icon$ 
InfoCircle=�6,   $��Center=�6>   $��Center=�6Y   $��60��6v   $��0��6�   $��0��6�   $��2��6�      
Foreground �#CAF4F4$y�Hidden=�6�     5   
   -   5        $ 
dangerIcon��5      $ ExclamationTriangle=�6.   $��Center=�6I   $��Center=�6d   $��60��6�   $��0��6�   $��0��6�   $��2��6�    �#CAF4F4$y�Hidden=�6�   �� 5   
   -   5         ��Name$ 
textTittle��5      $��1��6(   $��0��68   $
��Wrap=�6E   $��Bottom=�6Y   	 �� Padding$	 10q�6t   $��25(�6�   $
��Bold"�6�   6�   �� 5   
   -   5        $
 text��5      $��1��6"   $��1��62   $
��Wrap=�6?   $	 10q�6S   6b   �� 5   
   -   5        $��1��5      $��2��6!   $��45��6.   $	��120��6:   $��18(�6F   $��Right=�6T   $��0,0,14,0q�6p   
 � ToolTip$
 Zatvori obavestenje��6�    � 	Resources 5       �� 
TargetType �� Property �� Value��%^   '��       �� 5      " ��6   .�5      ��  �@��CornerRadius$ 6��65   5      5      .��6    	Zatvori5       5!      5"      