   M S B A M L   `   `   `  ����  GamingOverlay    GamingOverlay.MainWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  GamingOverlay��5   	   $
��1080��6   $
��1920��6-    � WindowStyle$
 None=�5   	    � AllowsTransparency$
 True��6   
������  � Topmost$
 True��5   	    � 
ResizeMode$ NoResize=�6   .��5      � .+�5	   
   �� -   5         ��Name$ PartialScreenOverlay��5	      
���   � J� Opacity$	 0.5Q�5
   !   $y�	Collapsed=�5      $��Stretch=�5      $��Stretch=�5      $��	0,0,0,120q�5      � 5   
   
������ .+�5      �� -   5        $ BackgroundImageRectangle��5      $	��150��6:   $��Bottom=�5      $��0,0,0,44q�5      
���  ��$��0��5   %   
������ 5       � 5      -   5          �Name$ FrameContent��5      $��Center=�5      $��Center=�5      $	��800��5      $	��600��5      $y�Visible=�5        � NavigationUIVisibility$ Hidden=�5       �� 5#      $	��120��6   $��Bottom=�5$      $��0,0,0,44q�5%      
������ ._�5'      �� -   5        	 ��Name$	 NavigationButtonsPanel��5'      
 �� Orientation$
 
Horizontal=�6=   $��Center=�6V   $��Center=�6s   .+�5)      �� $��Images/ctrl_bttn_LB.png��6   $��Center=�5*      $��20��5+      $��0,0,20,0q�5,      �� 5/      $��Game Options��6   $��	20,0,20,0q�64   
������ 
������ 
�������$��16(�51   0   $
��Bold"�6>   �� 52      $��Performance Profile��6   $��	20,0,20,0q�6;   
������ 
������ 
�������$��16(�54   0   $
��Bold"�6>   �� 55      $��Game Recording��6   $��	20,0,20,0q�66   
������ 
������ 
�������$��16(�57   0   $
��Bold"�6>   �� 58      $��Achievements��6   $��	20,0,20,0q�64   
������ 
������ 
�������$��16(�5:   0   $
��Bold"�6>   �� 5;      $��Discord��6   $��	20,0,20,0q�6/   
������ 
������ 
�������$��16(�5=   0   $
��Bold"�6>   �� 5@      $��Images/ctrl_bttn_RB.png��6   $��Center=�5A      $��20��5B      $��20,0,0,0q�5C      5D      5E      �� 5G      $��50��6   $��Bottom=�5H      $��Right=�5I      $	��300��5J      ���#1C1C1C._�5L      �� $
 
Horizontal=�6   $��Right=�66   $��Center=�6R   $��0,0,10,0q�6m   .+�5N      �� $��Images/ctrl_bttn_B.png��6   $��Center=�5O      $��20��5P      $��10,0,5,0q�5Q      �� 5R      $
��Back��6    
�������$��14(�6?   $��Center=�6M   $��5,0,10,0q�6h   �� 5U      $��Images/ctrl_bttn_A.png��6   $��Center=�5V      $��20��5W      $��10,0,5,0q�5X      �� 5Y      $��Select��6    
�������$��14(�6A   $��Center=�6O   $��5,0,10,0q�6j   5Z      5[      �� 5^      $��50��6   $��Bottom=�5_      $
��Left=�5`      $	��150��5a      
������ ._�5c      �� $
 
Horizontal=�6   $
��Left=�66   $��Center=�6Q   $��10,0,0,0q�6l   .+�5e      �� $ ��Images/ctrl_bttn_guide.png��6   $��Center=�5f      $��20��5g      $��10,0,5,0q�5h      �� 5i      $��Close��6   
�������$��14(�6,   $��Center=�6:   $��5,0,0,0q�6U   �� 5j      -   5         ��Name$ GuideButton��5j   	   $��Guide��5k   	   $��0��5l   	   $��0��6   $y�	Collapsed=�6   5m   	   5n      5o      �� 5r      $��50��6   $��Bottom=�5s      
������  J� IsHitTestVisible$ False��5u      5v      5w      5x      