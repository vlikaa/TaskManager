   M S B A M L   `   `   `  ����F  BTaskManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TaskManager.ViewsTaskManager.Views  5   	   ?$clr-namespace:TaskManager.ViewModelsTaskManager.ViewModels  5   	   G(clr-namespace:TaskManager.CustomControlsTaskManager.CustomControls  5   	        TaskManager.Views.MainView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   -vclr-namespace:TaskManager.Views     5   	   3vm$clr-namespace:TaskManager.ViewModels     5   	   7cc(clr-namespace:TaskManager.CustomControls     5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3b+http://schemas.microsoft.com/xaml/behaviors  5
   	     � Title$  MainView��5   	   $	��650��6   $	��900��6'   $	��650��5   	   $	��900��5   	    � WindowStyle$
 None=�5   	    � DataContext 5   	   ��  �� RelativeSource �� *Self+'  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      CaptionHeight$ 0Q�6      ResizeBorderThickness$ 5q�5         CornerRadius$ 10��5       � 	Resources 5      	 �� DataType-   'TaskManager.ViewModels.DetailsViewModel#   TaskManager.Views.DetailsView.   (TaskManager.ViewModels.SettingsViewModel$   TaskManager.Views.SettingsView   BoolToVisConverter  CustomTextBox
 �� 
TargetType �� CornerRadius  NavigationColor �� 	Converter � RowDefinitions � ColumnDefinitions  PressedFontColor0  *MaterialDesignThemes.Wpf.PackIconExtension   Kind  HeaderTextBox �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value-   'TaskManager.CustomControls.CustomButton  CustomButtonTemplate   Icon  ActiveCustomButtonTemplate  NavigationActiveBorderColor  NavigationButton 	 Primary 
 PrimaryFont  PressedNavigationColor �� Padding �� Triggers��%�  (��       5      *, +)(�� 2     5      *, +)&	  d     &	 w     7   &	 :    7  &	     &	 �    &	 &    7  7  '�� "
    �� 5   
   "	  6   .R�5        5      �� 5   
   "	  6   .R�5        5       �� 5"   
   6'   �� 5$   
   "
 ��60   .R�5%      �� $ 5��6   $��147 8 155 8q�5&      #���  5(      y�5'      �� *IsDetailsActive+8   ._�5)      �  5*      �� 5+      �� 5,      $
��Auto �6,   .+�5/      � $��0��6    50      �� 51   "   $
��Auto �63   �� 52   "   .+�55      �� $��0��6$   $	��8 0q�56   $   $��Center=�57   $   #���  58   $   ��59   $     $ Magnify=��� 5;      $��1��6&   $��0q�5<   &   $��15(�5=   &   $	��450"�5>   &   #���  5?   &   #��z��5@   &   $��0 0 0 3q�5A   &   $��Center=�5B   &   5C      �� 5E      $��1��6!   $	��2.5��5F   !   $ 0 0 5 5��5G   !   ���#3DECFF5H   !   5I      5J      5K      �� 5M   
   " ��6&   �5N      �� 5O       � ��8   6-   �� 5P       � ��# �  6/    5R      P� 5S       �@J�	IsFocused$
 True��6/   . �5T      ��  � ��
 �  ��63   5U      5W      �� 5Y   
   "
  6   .R�5Z      �� $ 5��6   $��5q�5[      #��z��5\      ._�5]      � $��Center=�6    5^      �� 5_      $
��Auto �6+   �� 5`      $
��Auto �6+   .+�5c      �� $��0��6   $��12(�5d      $��	6 1.3 0 0q�5e      #��z��5f      #��z 5g      �� 5i      $��1��6   $��
2 -0.5 0 0q�5j      $��15(�5k      #��z��5l      #��z��5m      5n      5o      5p      �� 5r   
   "
  6   .R�5s      �� $ 5��6   $��5q�5t      #��z��5u      ._�5v      � $��Center=�6    5w      �� 5x      $
��Auto �6+   �� 5y      $
��Auto �6+   �� 5z      $
��Auto �6+   .+�5}      �� $��0��6   $	��3.7��5~      $��	0 2.3 0 0q�5      $��18��5�      $ 3��5�      #���  5�      �� 5�      $��1��6   $��12(�5�      $��	5 6.2 0 0q�5�      $��	2.3 0 6 0q�5�      #��z��5�      #��z 5�      �� 5�      $��2��6   $��
1 -0.5 0 0q�5�      $��15(�5�      #��z��5�      #��z��5�      5�      5�      5�      �� 5�   
   "  6)   �5�      �� 5�       � ��8   6-   �� 5�       � ��# � 	 6/   �� 5�       � ��# � 
 6/    5�      P� 5�       �@J�IsMouseOver$
 True��61   . �5�      ��  � ��# �  63   5�      P� 5�       �@ 	IsPressed$
 True��6/   . �5�      ��  � ��# �  63   �� 5�       � ��# �  63   5�      P� 5�       �@ IsActive$
 True��6.   . �5�      ��  � ��8  61   �� 5�       � ��# �  63   5�      5�      �� 5�   
   " ��6   .�5�      ��  � �� 5�      �� 5�      "
 ��6&   .R�5�      �� #��z��6!   $��30��6K   $	��Top=�6W   $ 16.5 0q�6o   ._�5�      �� $��Center=�6/   $��Center=�6L   5�       5�      P� 5�       �@J�IsMouseOver$
 True��6=   . �5�   "   �� # �  6?    � ��5�      P� 5�       � ��$
 True��6;   . �5�   "   �� # �  6?    � ��5�      5�      5�      �� 5�       � ��# � 	 6+   �� 5�       � ��# � 
 6+   5�      5�      .��5�      �  5�   
   �� 5�      $
��Auto �6   �� 5�      .+�5�   
   �� $��0��6   #��� 	 6   $��48��6E   $	��Top=�6Q   $��Stretch=�6i   ._�5�      �  5�      �� 5�      $
��Auto �6'   �� 5�      $
��Auto �6'   �� 5�      �� 5�      $
��Auto �6'   �� 5�      $
��Auto �6'   �� 5�      $
��Auto �6'   .+�5�      �� $��0��6   $
��18 5q�5�      $��15��5�      $��/Resources/icon.ico��5�      �� 5�      $��1��6   $	��Top=�5�      $��0 10 0 0q�5�      $
��13.5(�5�      #��� 
 5�      $��Task manager��5�      �� 5     $��3��6   ��5	     �� *MinimizeCommand+��5
       $ HorizontalLine=��� 5     $��4��6   ��5     �� *ChangeStateCommand+��5       $ 
CropSquare=��� 5     $��5��6   ��5     �� *CloseCommand+��5       $ WindowClose=���5     �� 5     " ��6    .�5     ��  � �� 5  "   �� 5  &   "
 ��66   .R�5  *   �� #��z��61   $��30��6[   $	��Top=�6g   $ 16.5 0q�6   ._�5  .   �� $��Center=�6?   $��Center=�6\   5  +    5  *   P� 5  .    �@J�IsMouseOver$
 True��6M   . �5  2   ��  � �� �#C42B1C6O   5  /   P� 5  .    � ��$
 True��6K   . �5   2   ��  � �� �#B22A1B6O   5!  /   5#  '   5%     �� 5&      � ��# � 	 6;   �� 5'      � ��# � 
 6;   5(     5*     5+     *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5-     +	  %Microsoft.Xaml.Behaviors.EventTrigger	  5.      	  	EventName$ MouseLeftButtonDown��6!   *
  $Microsoft.Xaml.Behaviors.TriggerBase 
  Actions. 5/     2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6,   �� *MoveWindowCommand+50     52     � 54  
   $��1��6   #��� 	 6    55     �� 56     $
��Auto �6#   �� 57     .+�5:     � $��0��6   $
��Auto��5;      5<     �� 5=     $
��Auto �6$   �� 5>     $
��Auto �6$   �� 5?     �� 5@     $
��Auto �6$   .+�5C       $��0��6"   #��[ 5D  "   $��50��5E  "   $
��Left=�5F  "   $��50��5G  "   $�� ��5H  "      Command 5I  "   �� *MenuButtonCommand+ 5J     '  !MaterialDesignThemes.Wpf.PackIcon  5K        Kind$
 Menu=�6&   $
��18.5��62   $
��18.5��6?   5M       5Q     $��1��6"   #��[ 5S  "   $��50��5U  "   $��Details��5V  "      IsActive 5R  "   �� *IsDetailsActive+��5T  "   �� *ButtonWidth+ 5W  "   �� *DetailsButtonCommand+ 5X       5Y     $ FormatListBulleted=�6&   $
��18.5��6@   $
��18.5��6M   5[       5]     $��3��6"   #��[ 5_  "   $��50��5a  "   $��Settings��5b  "    5^  "   �� *IsSettingsActive+��5`  "   �� *ButtonWidth+ 5c  "   �� *SettingsButtonCommand+ 5d       5e     $ SettingsOutline=�6&   $
��18.5��6=   $
��18.5��6J   5g     5h     �� 5j     $��1��6   ��6/   �� *	ViewModel+5l     5m     5o     