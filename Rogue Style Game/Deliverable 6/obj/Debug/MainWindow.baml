   M S B A M L   `   `   `  ����H  DDeliverable 6, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Deliverable_6Deliverable_6  5   	       Deliverable_6.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Deliverable_6     5   	   -   5          � Title$(  "Firefly on (even more of) a Budget��5   	   $��738.198��64   $��1463.267��6E   ��. .��5	      � -   5         �Name$ grdMain��5	       � RowDefinitions 5
   
   �� 5      $
��0.5* �6   �� 5      $��3* �6   �� 5      $��3* �6   �� 5      $��3* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��2* �6   �� 5      $��* �6   .+�5   
   � -   5        $ grdMap��5      $��1��6   $��8��6-   $��3��6A    � UseLayoutRounding .   5      �� 5      $��* �6    �� 5       $��* �6    �� 5!      $��* �6    �� 5"      $��* �6    �� 5#      $��* �6    �� 5$      $��* �6    �� 5%      $��* �6    �� 5&      $��* �6    �� 5'      $��* �6    �� 5(      $��* �6     5*      �� 5+      $��* �6#   �� 5,      $��* �6#   �� 5-      $��* �6#   �� 5.      $��* �6#   �� 5/      $��* �6#   �� 50      $��* �6#   �� 51      $��* �6#   �� 52      $��* �6#   �� 53      $��* �6#   �� 54      $��* �6#   56      �� 57   
   -   5         ��Name$ btnStart��57      $��Start/Reset Map��6#   $��4��6=   $��3��6J   6[   �� 58   
   -   5        $ btnUp��58      $��Up��6    $��4��6-   $��2��6:   $��1��6N   6^   �� 59   
   -   5        $ btnLeft��59      $
��Left��6"   $��5��61   $��1��6>   6N   �� 5:   
   -   5        $ btnRight��5:      $��Right��6#   $��5��63   $��2��6@   6P   �� 5;   
   -   5        $ btnDown��5;      $
��Down��6"   $��6��61   $��2��6>   $��1��6R   6b   �� 5<   
   -	   5         ��Name$ lblName��5<      $��Name:��6!   $��3��61   $��4��6A   $��2��6N   �� 5=   
   -
   5        $ lblHP��5=      $	��HP:��6   $��3��6-   $��5��6=   $��2��6J   �� 5>   
   -   5        $ 	lblWeapon��5>      $��Weapon:��6#   $��6��65   $��3��6B   $��2��6R   �� 5?   
   -   5        $ lblKey��5?      $
��Key:��6    $��4��6/   $��6��6<   �� 5@   
   -   5        $ 	lblDamage��5@      $��Damage:��6#   $��6��65   $��6��6B   �� 5A   
   -   5        $ tbDamage��5A      $�� ��6"   $��6��6-   $��7��6:   �� 5B   
   -   5        $ tbName��5B      $��5��6    $��4��60   �� 5C   
   -   5        $
 tbHP��5C      $��5��6   $��5��6.   �� 5D   
   -   5        $ tbWeapon��5D      $��5��6"   $��6��62   �� 5E   
   -   5        $ tbKey��5E      $��8��6   $��4��6/   o� 5F   
   -   5         o�Name$
 menu��5F      $��8��6   .@�5G      m� -   5         m�Name$ miFile��5G      $
��File��6'   .@�5H      m� -   5        $ 
miLoadGame��5H      $��	Load Game��6/   6B   m� 5I      -   5        $ 
miSaveGame��5I      $��	Save Game��6/   6B   5J      5K      5L      5M      