   M S B A M L   `   `   `  ���� F  BTraoDoiKhoa, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TraoDoiKhoaTraoDoiKhoa      TraoDoiKhoa.WindowA   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:TraoDoiKhoa       � Icon$  /Images/us.ico�� � Title$ 
A - ID = 1��$	��450��$	��890��.���  � ColumnDefinitions �� $
��auto ��� $
��auto ��� $
��auto �.+��� $��Tạo khóa��$
��Bold"�$��14(�$��5,5,5,5q�$��0��.���� $��10q�.+���  �� Orientation$ 
Horizontal=�$	��0 5q�.+��� $
��p = ��$��50��$��Center=��� -   $
��txtP��$	��150���� $ 
Horizontal=�$	��0 5q�.+��� $
��a = ��$��50��$��Center=��� -   $
��txtA��$	��150���� $ 
Horizontal=�$	��0 5q�.+��� $
��x = ��$��50��$��Center=��� -   $
��txtX��$	��150���� $ 
Horizontal=�$
��0 10q�$��Center=�.+��� -   $��Tự động��$	��100��$��5q��� -   $��Tạo khóa��$	��100��$��5q��� $ 
Horizontal=�$	��0 5q�.+��� $
��y = ��$��50��$��Center=��� -   $
��txtY��$	��150���� $ 
Horizontal=�$��Center=�$��10q�.+��� -   $"��Gửi tới trung tâm khóa��$��5q�$	��170���� -   $��Tạo lại��$	��100��$��5q��� $$��Lấy khóa công khai của B��$
��Bold"�$��14(�$��5,5,5,5q�$��1��.���� $��10q�.+��� $ 
Horizontal=�$	��0 5q�.+��� $��Yêu cầu: ��$��60��$��Center=��� -	   $��txtID��$	��180���� $ 
Horizontal=�$
��0 10q�$��Center=�.+��� -
   $��Gửi yêu cầu��$	��100��$��5q��� $!��Khóa được gửi đến��$
��Bold"�$��14(�$��5q�$��0��.���� $��10q�.+��� -    ��Name$ 	khoaMaHoa��$	��150��$	��200�� �� TextWrapping$
 Wrap=� �� 
IsReadOnly$
 True���� $ 
Horizontal=�$
��0 10q�$��Center=�.+��� -   $��Nhận khóa��$	��100��$��5q��� -   $��
Giải mã��$	��100��$��5q��� $��Khóa công khai của B��$
��Bold"�$��14(�$��5,5,5,5q�$��3��.���� $��10q�.+��� $ 
Horizontal=�$	��0 5q�.+��� $��ID_B = ��$��50��$��Center=��� -   $��txtIDB��$	��100���� $ 
Horizontal=�$	��0 5q�.+��� $��p_B = ��$��50��$��Center=��� -   $��txtPB��$	��150���� $ 
Horizontal=�$	��0 5q�.+��� $��a_B = ��$��50��$��Center=��� -   $��txtAB��$	��150���� $ 
Horizontal=�$	��0 5q�.+��� $��y_B = ��$��50��$��Center=��� -   $��txtYB��$	��150���� $ 
Horizontal=�$
��0 10q�$��Center=�.+��� -   $��Tạo kết nối!��$	��150��$��5q��� $��10q�.+��� -    ��Name$ yeuCau��$	��200��$��80���� $ 
Horizontal=�$
��0 10q�$��Center=�.+��� -   $	��but��$ ��Chấp nhận kết nối!��$	��150��$��5q�