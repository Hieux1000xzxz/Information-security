   M S B A M L   `   `   `  ���� F  BTraoDoiKhoa, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TraoDoiKhoaTraoDoiKhoa  !    TraoDoiKhoa.KenhTraoDoiKhoa   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:TraoDoiKhoa     -     � Icon$  \Images\ms.ico�� � Title$ KenhTraoDoiKhoa��$	��810��$
��1320��.���  � ColumnDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto � � RowDefinitions �� $
��auto �$	��589���� $
��auto �$	��200��.+��� $��2��
���   �$��2q�$��2��$��0��$��A-ID1��$��2,2,2,2q��� $��2��
���   �$��2q�$��2��$��2��$��B-ID2��$��2,2,2,2q��� $��0��$��
20,20,20,0q�.+��� $��Khóa công khai của B��$
��Bold"�$��14(�$��5,5,5,5q�$	��290��$	��150��.���� $��10q�.+���  �� Orientation$ 
Horizontal=�$	��0 5q�.+��� $��p_B = ��$��50��$��Center=��� -   $��txtPB��$	��150�� �� 
IsReadOnly$
 True���� $ 
Horizontal=�$	��0 5q�.+��� $��a_B = ��$��50��$��Center=��� -   $��txtAB��$	��150��$
 True���� $ 
Horizontal=�$	��0 5q�.+��� $��y_B = ��$��50��$��Center=��� -   $��txtYB��$	��150��$
 True���� $��0��$��20,170,20,0q�.+��� $&�� Xác nhận qua khóa công khai��$
��Bold"�$��14(�$��5,5,5,5q�$��1��$	��290��$	��390��$	��Top=�$
��Left=�.���� $��10q�.+��� $ 
Horizontal=�$
��0 15q�.+��� $��Thông điệp gửi��$
��Wrap=�$��50��$��Center=��� -    ��Name$
 tdg1��$	��100��$	��200��$ ��Nhập nội dung gửi...��
�������$��16(�$��Center=�$��Center=��� -   $��Mã hóa và gửi đi��$	��140���� $ 
Horizontal=�$
��0 15q�.+��� $��Thông điệp nhận��$
��Wrap=�$��50��$��Center=��� -   $
��tdn1��$	��200��$	��100��$
 True���� -   $��Giải mã thông điệp��$	��140���� $��1��$��
20,20,20,0q�.+��� $&�� Trao đổi khóa Diffie-Hellman��$
��Bold"�$��14(�$��5,5,5,5q�$��1��$	��260��$	��539��$	��Top=�$
��Left=�.���� $��10q�.+��� $��Chọn tham số chung��$��Center=��� $ 
Horizontal=�$	��0 5q�.+��� $
��p = ��$��50��$��Center=��� -	   $��txtp1��$	��150���� $ 
Horizontal=�$	��0 5q�.+��� $
��g = ��$��50��$��Center=��� -
   $��txta1��$	��150���� $ 
Horizontal=�$��Center=�.+�	� -   $��rada1��$��5q� d� 	IsChecked$
 TrueY�.��Nhập	� -   $��rada2��$��5q�.��Tự động nhập�� -   $��btngui��$��25��$��60��.��	Gửi đi�� $��Chọn khóa bí mật��$��Center=�$��0 10 0 0q��� $ 
Horizontal=�$	��0 5q�.+��� $
��k = ��$��50��$��Center=��� -   $��txtKhoa1��$	��150���� $ 
Horizontal=�$��Center=�.+�	� -   $��rada3��$��5q�$
 TrueY�.��Nhập	� -   $��rada4��$��5q�.��Tự động nhập�� -   $��Tính A��$��Center=�$��60���� $"��Tính phần tử công khai��$��Center=��� $ 
Horizontal=�$	��0 5q�.+��� $
��A = ��$��50��$��Center=��� -   $
��txtA��$	��150���� $*��$Phần tử công khai nhận từ B��$��Center=��� $ 
Horizontal=�$	��0 5q�.+��� $
��B = ��$��50��$��Center=��� -   $��txtBA��$	��150���� $��Tính khóa chung K��$��Center=��� $ 
Horizontal=�$	��0 5q�.+��� $
��K = ��$��50��$��Center=��� -   $��txtK1��$	��150���� $ 
Horizontal=�$��Center=�.+��� -   $��Tính K��$��Center=�$��60��$��5q��� -   $��Sử dụng K��$��Center=�$��80��$��5q��� $(��"Trao đổi thông tin qua khóa K��$
��Bold"�$��14(�$��2��$��1��$	��620��$	��170��$	��Top=�$��Center=�$��0,5,0,0q�.���� $��10q�$ 
Horizontal=�.+��� $	��300��.+��� $ 
Horizontal=�$
��0 15q�.+��� $��	Bản rõ��$
��Wrap=�$��55��$��Center=��� -   $��tdgk1��$	��200��$��70�� �� TextWrapping$
 Wrap=��� -   $��Mã hóa và gửi đi��$	��140���� $
��30 0q�$��Center=�$	��300��.+��� $ 
Horizontal=�$
��0 15q�.+��� $��Bản mã nhận��$
��Wrap=�$��55��$��Center=��� -   $��tdnk1��$	��200��$��70��$
 True��$
 Wrap=��� -   $��Giải mã thông điệp��$	��140���� $��2��$��20,20,20,20q�.+��� $��Khóa công khai của A��$
��Bold"�$��14(�$��5,5,5,5q�$	��290��$	��150��.���� $��10q�.+��� $ 
Horizontal=�$	��0 5q�.+��� $��p_A = ��$��50��$��Center=��� -   $��txtPA��$	��150��$
 True���� $ 
Horizontal=�$	��0 5q�.+��� $��a_A = ��$��50��$��Center=��� -   $��txtAA��$	��150��$
 True���� $ 
Horizontal=�$	��0 5q�.+��� $��y_A = ��$��50��$��Center=��� -   $��txtYA��$	��150��$
 True���� $��2��$��20,170,20,0q�.+��� $&�� Xác nhận qua khóa công khai��$
��Bold"�$��14(�$��5,5,5,5q�$��1��$	��290��$	��390��$	��Top=�$
��Left=�.���� $��10q�.+��� $ 
Horizontal=�$
��0 15q�.+��� $��Thông điệp gửi��$
��Wrap=�$��50��$��Center=��� -   $
 tdg2��$	��100��$	��200��$ ��Nhập nội dung gửi...��
�������$��16(�$��Center=�$��Center=��� -   $��Mã hóa và gửi đi��$	��140���� $ 
Horizontal=�$
��0 15q�.+��� $��Thông điệp nhận��$
��Wrap=�$��50��$��Center=��� -    $
��tdn2��$	��200��$	��100��$
 True���� -!   $��Giải mã thông điệp��$	��140���� $��3��$��20,20,20,20q�.+��� $&�� Trao đổi khóa Diffie-Hellman��$
��Bold"�$��14(�$��5,5,5,5q�$��1��$	��260��$	��539��$	��Top=�$
��Left=�.���� $��10q�.+��� $��Chọn tham số chung��$��Center=��� $ 
Horizontal=�$	��0 5q�.+��� $
��p = ��$��50��$��Center=��� -"   $��txtp2��$	��150���� $ 
Horizontal=�$	��0 5q�.+��� $
��g = ��$��50��$��Center=��� -#   $��txta2��$	��150���� $ 
Horizontal=�$��Center=�.+�	� -$   $��rada1b��$��5q�$
 TrueY�.��Nhập	� -%   $��rada2b��$��5q�.��Tự động nhập�� -&   $��btnguib��$��25��$��60��.��	Gửi đi�� $��Chọn khóa bí mật��$��Center=�$��0 10 0 0q��� $ 
Horizontal=�$	��0 5q�.+��� $
��k = ��$��50��$��Center=��� -'   $��txtKhoa2��$	��150���� $ 
Horizontal=�$��Center=�.+�	� -(   $��rada3b��$��5q�$
 TrueY�.��Nhập	� -)   $��rada4b��$��5q�.��Tự động nhập�� -*   $��Tính B��$��Center=�$��60���� $"��Tính phần tử công khai��$��Center=��� $ 
Horizontal=�$	��0 5q�.+��� $
��B = ��$��50��$��Center=��� -+   $
��txtB��$	��150���� $*��$Phần tử công khai nhận từ A��$��Center=��� $ 
Horizontal=�$	��0 5q�.+��� $
��A = ��$��50��$��Center=��� -,   $��txtAk��$	��150���� $��Tính khóa chung K��$��Center=��� $ 
Horizontal=�$	��0 5q�.+��� $
��K = ��$��50��$��Center=��� --   $��txtK2��$	��150���� $ 
Horizontal=�$��Center=�.+��� -.   $��Tính K��$��Center=�$��60��$��5q��� -/   $��Sử dụng K��$��Center=�$��80��$��5q��� $(��"Trao đổi thông tin qua khóa K��$
��Bold"�$��14(�$��2��$��1��$��2��$	��620��$	��170��$	��Top=�$��Center=�$��0,5,0,0q�.���� $��10q�$ 
Horizontal=�.+��� $	��300��.+��� $ 
Horizontal=�$
��0 15q�.+��� $��	Bản rõ��$
��Wrap=�$��55��$��Center=��� -0   $��tdgk2��$	��200��$��70��$
 Wrap=��� -1   $��Mã hóa và gửi đi��$	��140���� $
��30 0q�$��Center=�$	��300��.+��� $ 
Horizontal=�$
��0 15q�.+��� $��Bản mã nhận��$
��Wrap=�$��55��$��Center=��� -2   $��tdnk2��$	��200��$��70��$
 True��$
 Wrap=��� -3   $��Giải mã thông điệp��$	��140��