   M S B A M L   `   `   `  ����K  GTreeViewTransfer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:TreeViewTransferTreeViewTransfer  5   	   !    TreeViewTransfer.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:TreeViewTransfer     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $	��100 �6   �� 5      $��* �6   .+�5   
   R� -   5        $��sourceTreeView��5      $��0��6)   $��
43,15,41,5q�69    J� 	AllowDrop$
 True��6M   5   .   �� 5   
   -   5        $��>��5      $��1��6    $��27,195,10,205q�60   6G   �� 5   
   -   5        $��<��5      $��37,259,20,140q�6     J� RenderTransformOrigin$ 2.198,1.919&�6V   $��1��6z   R� 5   
   -   5        $��destinationTreeView��5      $��2��6.   $��64,10,10,10q�6>   $
 True��6S   5   3   �� 5   
   -   5        $
��Save��5      $��10,349,0,40q�6    $��1��6H   5       5!      