   M S B A M L   `   `   `  ����D  @dentistry, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:dentistry	dentistry  5   	       dentistry.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:dentistry     5   	     � Title$  
MainWindow��5   	   $	��480��6   $	��750��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��91* �6   �� 5      $
��159* �6    � RowDefinitions 5   
   �� 5      $	��377 �6   �� 5      $��50 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dentalService��5         AutoGenerateColumns .     
IsReadOnly .    CanUserResizeColumns .  $��	0,44,0,28q�5      $��2��6"      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Сотрудник��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$
	 Auto 6`   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 68   �� *Workers.name_worker+6`     5      $ Клиент��6%   $
	 Auto 6]   
 65   �� *Clients.name_client+6]     5      $ Статус заявки��6%   $
	 Auto 6e   
 6<   �� *Statuses.name_status+6e     5      $ Услуга��6%   $
	 Auto 6_   
 65   �� *Service_.name_service+6_     5      $ Цена��6%   $
	 Auto 6X   
 63   �� *Price.name_price+6X     5      $ Дата и время��6%   $
	 Auto 6_   
 6;   �� *Times.name_time+6_     5      $ Комментарий��6%   $
	 Auto 6W   
 6:   �� *
comments+6W   4  .System.Windows.Controls.DataGridTemplateColumn  5      $
	 Auto 6)   -   5        Red��   CellTemplate 5      �� 5       .R�5!      ��  ��Name$ BtnEdit��6=   -   5        $ ��Редактировать��5!   %   6N   5"      5$      5'      �� 5*   
   -   5        $��BtnAdd��5*   L   $��Добавить��6   $��1��6$   $
��Left=�61    J� RenderTransformOrigin$ 1.178,0.536&�6o   $	��105��6�   $��29,0,0,0q�6�   �� 5+   
   -   5        $��BtnAuthorization��5+   M   $��Вернуться��6   $��1��6%   $
��Left=�62   $��	144,0,0,0q�6�   $	��105��6�   $��1��6�   �� 5,   
   -   5        $��BtnUp��5,   L   $��Обновить��6   $��1��6$   $
��Left=�61   $��	217,0,0,0q�6m   $	��105��6�   $��2��6�   �� 5-   
   -   5        $��BtnOut��5-   @   $��Применить��6   $
��Left=�6%   $��
228,10,0,0q�6c   $	��Top=�6w   $��24��6�   $	��109��6�   $��1��6�   �� 5.   
   -   5        $��BtnDelet��5.   K   $��Удалить��6   $��1��6#   $
��Left=�60   $	��105��6r   $��	335,0,0,0q�6~   $��1��6�   �� 5/   
   -	   5         ��Name$ ComboStatus��5/   A    �� DisplayMemberPath$ name_status��6V   $��
105,12,0,0q�6v   $	��Top=�6�   $��20��6�   $
��Left=�50      $	��118��6*   $��1��66    �� SelectedItem 5/      �� *Statuses.name_status+50   6   �� 51   
   $��Фильтр��6   $
��Left=�6"   $��	55,12,0,0q�6=   $	��Top=�6P   $��50��6h   $��1��6s   �� 52   
   $��
Поиск��6   $
��Left=�6!   $��	29,10,0,0q�6<   $	��Top=�6O   $��50��6g   �� 53   
   -
   5         ��Name$ 	SearchBox��53      $	��200��6%   $��22��61   $��79,8,0,0q�6a   $	��Top=�6s   $
��Left=�6�   $��2��6�   54      56      