# SOLID Analysis - ClubManager

## 1. Single Responsibility Principle (SRP)

- Vị trí: `ClubManager.cs`, phương thức `CreateClub()`.
- Vi phạm: Phương thức vừa kiểm tra dữ liệu, tạo câu lạc bộ, ghi log và gửi thông báo.
- Hậu quả: Khi thay đổi một chức năng, phải sửa phương thức đang đảm nhiệm nhiều trách nhiệm.

## 2. Open/Closed Principle (OCP)

- Vị trí: `ClubManager.cs`, phương thức `CreateClub()`, đoạn `if/else` chọn cách gửi thông báo.
- Vi phạm: Muốn thêm kênh SMS hoặc Slack phải sửa code hiện tại.
- Hậu quả: Khó mở rộng và dễ gây lỗi ở các nhánh xử lý cũ.

## 3. Dependency Inversion Principle (DIP)

- Vị trí: Các phương thức gọi `File.AppendAllText()` và `Console.WriteLine()`.
- Vi phạm: Logic nghiệp vụ phụ thuộc trực tiếp vào cách ghi file và xuất console.
- Hậu quả: Khó thay đổi cơ chế ghi log và khó kiểm thử độc lập.

## 4. Single Responsibility Principle (SRP)

- Vị trí: `ClubManager.cs`, phương thức `CreateEvent()`.
- Vi phạm: Phương thức vừa tạo sự kiện, vừa ghi log và gửi thông báo cho thành viên.
- Hậu quả: Thay đổi quy trình thông báo có thể buộc phải sửa logic tạo sự kiện.

## 5. Open/Closed Principle (OCP)

- Vị trí: `ClubManager.cs`, phương thức `PrintClubReport()`.
- Vi phạm: Cách xuất báo cáo được gắn trực tiếp với `Console.WriteLine()`.
- Hậu quả: Muốn bổ sung xuất CSV phải sửa phương thức hiện tại.
