   M S B A M L   `   `   `  ����B  >Bolnica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:BolnicaBolnica  5   	       Bolnica.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Bolnica     5   	     � Title$  Medicinska Klinika��5   	   $	��730��6$   $	��950��61    � 
ResizeMode$ NoResize=�6=    J� CommandBindings 5	      )  #System.Windows.Input.CommandBinding  5
   
   -   5           Command$% local:MainWindow.ChangePassword��5
      6C     5   
   -   5        $" local:MainWindow.ViewProfile��5      6@     5   
   -   5        $" local:MainWindow.EditProfile��5      6@     5   
   -   5        $ local:MainWindow.Home��5      69     5   
   -   5        $' !local:MainWindow.UpcomingServices��5      6E     5   
   -   5        $% local:MainWindow.PassedServices��5      6C     5   
   -   5        $$ local:MainWindow.MedicalRecord��5      6B     5   
   -   5        $* $local:MainWindow.ScheduleAppointment��5      6H     5   
   -	   5        $ local:MainWindow.Blog��5      69     5   
   -
   5        $ local:MainWindow.Help��5      69    J� InputBindings 5      �� 5   
    �� Command$% local:MainWindow.ChangePassword��6   
 �� Key$ L��6?    �� 	Modifiers$ Ctrl+Altf�6G   �� 5   
   $" local:MainWindow.ViewProfile��6   $ P��6<   $ Ctrl+Altf�6D   �� 5   
   $" local:MainWindow.EditProfile��6   $ I��6<   $ Ctrl+Altf�6D   �� 5   
   $ local:MainWindow.Home��6   $ P��65   $	 Altf�6=   �� 5   
   $' !local:MainWindow.UpcomingServices��6   $ U��6A   $
 Ctrlf�6I   �� 5   
   $% local:MainWindow.PassedServices��6   $ P��6?   $
 Ctrlf�6G   �� 5   
   $$ local:MainWindow.MedicalRecord��6   $ M��6>   $
 Ctrlf�6F   �� 5   
   $* $local:MainWindow.ScheduleAppointment��6   $ S��6D   $
 Ctrlf�6L   �� 5   
   $ local:MainWindow.Blog��6   $ B��65   $	 Altf�6=   �� 5    
   $ local:MainWindow.Help��6   $ M��65   $	 Altf�6=   .��5#      ]� ���#CAF4F4.+�5$   
   o� $	��Top=�6   $��5q�6$   .@�5%      m� $��	_Stranice��6   .@�5&      m� $��_Korisnicki profil��6   .@�5'      m� $��Pogledaj profil��6    m� Command$" local:MainWindow.ViewProfile��68   	 m� InputGestureText$	 
Ctrl+ALT+P��6_   m� 5(      $��Izmeni profil��6   $" local:MainWindow.EditProfile��66   $	 
Ctrl+ALT+I��6]   m� 5)      $��Promeni lozinku��6   $% local:MainWindow.ChangePassword��68   $	 
Ctrl+ALT+L��6b   5*      m� 5+      $��Pregledi i _operacije��6   .@�5,      m� $��Predstojeće usluge��6   $' !local:MainWindow.UpcomingServices��6;   $	 Ctrl+U��6g   m� 5-      $��Prethodne usluge��6   $% local:MainWindow.PassedServices��69   $	 Ctrl+P��6c   5.      �� 5/      m� 50      $��Zakazi pregled��6   $* $local:MainWindow.ScheduleAppointment��63   $	 Ctrl+S��6b   m� 51      $��Zdravstveni karton��6   $$ local:MainWindow.MedicalRecord��67   $	 Ctrl+M��6`   �� 52      m� 53      $��	Odjavi se��6   $	 
Ctrl+ALT+Q��6.   55      m� 56      $��	_Početna��6   $ local:MainWindow.Home��6)   
 � ToolTip$
 Idi na početnu stranicu��6I   m� 57      $��_Blog��6   $ local:MainWindow.Blog��6&   $
 Idi na blog stranicu��6F   m� 58      $��Po_moć��6   $ local:MainWindow.Help��6'   $+
 %Klikni za pomoc u rukovanju softverom��6G   59       � 5;   
   -   5          �Name$ Frame��5;      $��Bottom=�6     � NavigationUIVisibility$ Hidden=�67     � Source$( "./Pages/RegistrateOrLoginPage.xaml?�6X   $��Stretch=�6�   5<      5=      