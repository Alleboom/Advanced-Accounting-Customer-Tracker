   M S B A M L   `   `   `  ����_  [Advanced Accounting Customer Tracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullo<clr-namespace:Advanced_Accounting_Customer_Tracker.ViewModel.Advanced_Accounting_Customer_Tracker.ViewModel  5   	   :    4Advanced_Accounting_Customer_Tracker.View.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   R	ViewModel<clr-namespace:Advanced_Accounting_Customer_Tracker.ViewModel     5   	     � Title$)  #Advance Accounting Customer Tracker��5   	   $	��400��65   $	��600��6B    � DataContext 5      A   ;Advanced_Accounting_Customer_Tracker.ViewModel.VMMainWindow  5   
    � 	Resources 5	         BoolToVisibility��%   &	        �� 5
   
   6'   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $��22 �6   �� 5      $��1* �6   .+�5   
   �� $��0��6   $��1��6%   $��5q�62   .+�5      �� $��Filter: ��6   �� 5      ��6   �� *	Filters+ �� SelectedItem 67   �� *SelectedFilter+ �� Mode$ TwoWay=��� 5       �� DisplayMemberPath$
 Name��6j   ��6   �� *
LeftList+ 69   �� *
SelectLeft+$ TwoWay=�6j   5      �� 5   
   $��1��6   $��1��6%   $��5q�62   .+�5      �� $��Accounting Method :��6   y�62   �� *FilterIsCustomer+ �� 	Converter# [  �� 5      ��6   �� *AccountingMethod+y�6:   �� *FilterIsCustomer+# [  �� 5      $��
Services :��6   y�6)   �� *FilterIsCustomer+# [  �� 5      $��Customers :��6   y�6*   �� *FilterIsService+# [  �� 5       $
 Name��69   ��6   �� *	RightList+69   5!      o� 5"   
   $��0��6   $��2��6   .@�5#      m� $��	Customers��6   .@�5$      m� $
��_Add��6   	 m� CommandParameter$	 AddCustomer��6H   
 m� Command
 6)   �� *
OpenWindow+6H   m� 5%      $��_Edit��6   $	 EditCustomer��6I   
 6*   �� *
OpenWindow+6I   m� 5&      $��_Remove��6   $	 RemoveCustomer��6K   
 6,   �� *
OpenWindow+6K   m� 5'      $��	_Services��6   $	 CustomerService��6M   
 6.   �� *
OpenWindow+6M   5(      m� 5)      $��Services��6   .@�5*      m� $
��_Add��6   $	 
AddService��6H   
 6)   �� *
OpenWindow+6H   m� 5+      $��_Edit��6   $	 EditService��6I   
 6*   �� *
OpenWindow+6I   m� 5,      $��_Remove��6   $	 RemoveService��6K   
 6,   �� *
OpenWindow+6K   5-      5.      5/      50      