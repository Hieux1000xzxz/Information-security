   M S B A M L   `   `   `  ���� F  BTraoDoiKhoa, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TraoDoiKhoaTraoDoiKhoa      TraoDoiKhoa.TrungTamKhoa   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:TraoDoiKhoa       � Icon$  \Images\security.ico�� � Title$ TrungTamKhoa��$	��570��$	��820��.��� $��10q� � ColumnDefinitions �� $
��auto ��� $
��auto ��� $
��auto �.+��� $��Nhận khóa��$
��Bold"�$��14(�$��5q�$��0��.���� $��10q�.+���  �� Orientation$ 
Horizontal=�$	��0 5q�.+��� $��ID gửi = ��$��60��$��Center=�$
��15 0q��� -   $��txtIDGuiKhoa��$	��150�� �� 
IsReadOnly$
 True���� $��Khóa được mã hóa��$
��Bold"�$��14(�$��5q�$��0��.���� $��10q�.+��� -    ��Name$ khoaNhan��$	��150��$	��200�� �� TextWrapping$
 Wrap=�$
 True���� $ 
Horizontal=�$
��0 10q�$��Center=�.+��� -   $��
Giải mã��$	��100��$��5q��� $,��&Giải mã khóa được gửi đến��.���� .+��� $ 
Horizontal=�$	��0 5q�.+��� $
��p = ��$��50��$��Center=��� -   $
��txtP��$	��150��$
 True���� $ 
Horizontal=�$	��0 5q�.+��� $
��a = ��$��50��$��Center=��� -   $
��txtA��$	��150��$
 True���� $ 
Horizontal=�$	��0 5q�.+��� $
��y = ��$��50��$��Center=��� -   $
��txtY��$	��150��$
 True���� $ 
Horizontal=�$
��0 10q�$��Center=�.+��� -   $��
Lưu khóa��$	��100��$��5q��� $ 
Horizontal=�$��Center=�.+��� -   $��Xem file khóa��$	��100��$��5q��� $��Yêu cầu lấy khóa:��$
��Bold"�$��14(�$��5q�$��1��.���� .+��� $��10q�.+��� -	   $ yeuCau��$	��150��$	��210��$
 True���� $ 
Horizontal=�$��Center=�.+��� -
   $��Giải mã yêu cầu��$	��120��$��5q��� $��Lấy khóa��$
��Bold"�$��14(�$��5q�$��1��.���� $��10q�.+��� $ 
Horizontal=�$	��0 5q�.+��� $��ID = ��$��50��$��Center=��� -   $��txtIDLay��$	��150���� $ 
Horizontal=�$	��0 5q�.+��� $
��p = ��$��50��$��Center=��� -   $��txtPLay��$	��150��$
 True���� $ 
Horizontal=�$	��0 5q�.+��� $
��a = ��$��50��$��Center=��� -   $��txtALay��$	��150��$
 True���� $ 
Horizontal=�$	��0 5q�.+��� $
��y = ��$��50��$��Center=��� -   $��txtYLay��$	��150��$
 True���� $ 
Horizontal=�$
��0 10q�$��Center=�.+��� -   $��Lấy khóa��$	��100��$��5q��� -   $��Mã hóa��$	��100��$��5q��� $��Gửi khóa��$
��Bold"�$��14(�$��5q�$��2��.���� $��10q�.+��� $ 
Horizontal=�$	��0 5q�.+��� $��ID nhận = ��$��70��$��Center=�$
��15 0q��� -   $��txtIDGui��$	��150���� $,��&Yêu cầu và khóa được mã hóa��$
��Bold"�$��14(�$��5q�$��0��.���� $��10q�.+��� -   $ khoaGui��$	��150��$	��200��$
 Wrap=�$
 True���� $ 
Horizontal=�$
��0 10q�$��Center=�.+��� -   $��Gửi khóa��$	��100��$��5q�