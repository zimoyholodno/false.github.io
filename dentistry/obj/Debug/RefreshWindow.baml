   M S B A M L   `   `   `  ����D  @dentistry, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:dentistry	dentistry  5   	       dentistry.RefreshWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:dentistry     5   	     � Title$'  !Обновление заявки��5   
   $	��500��6$   $	��350��61   .��5
      �� $��10q�6   .+�5   
   �� $��Клиент:��6   �� 5   
   -   5         ��Name$ ClientTextBox��5      �� 5   
   $��Тип услуги:��6   �� 5   
   -   5         ��Name$ TypeComboBox��5       �� DisplayMemberPath$ name_service��6)   6J   �� 5   
   $��Сотрудник:��6   �� 5   
   -   5        $ WorkerComboBox��5      $ name_worker��6+   {�.  6K   �� 5   
   $��	Цена:��6   �� 5   
   -   5        $ PriceComboBox��5      $ 
name_price��6*   {�.  6I   �� 5   
   $��Статус:��6   �� 5   
   -   5        $ StatusComboBox��5      $ name_status��6+   �� 5   
   $��Комментарий:��6   �� 5   
   -   5        $ DescriptionTextBox��5      �� 5   
   -   5        $��Обновить��5      
�������6?   5      5       