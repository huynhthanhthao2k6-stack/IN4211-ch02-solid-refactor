# SOLID Analysis - ClubManager

## 1. Single Responsibility Principle (SRP)

- **Vị trí:** `ClubManager.cs`, phương thức `CreateClub()`.
- **Vi phạm:** Phương thức vừa kiểm tra dữ liệu, tạo câu lạc bộ, lưu dữ liệu, ghi log và gửi thông báo.
- **Hậu quả:** Khi thay đổi quy tắc kiểm tra, cơ chế lưu trữ hoặc cách gửi thông báo, phải sửa cùng một phương thức. Điều này làm tăng độ phức tạp và nguy cơ phát sinh lỗi.

## 2. Open/Closed Principle (OCP)

- **Vị trí:** `ClubManager.cs`, phương thức `CreateClub()`, đoạn `if/else` lựa chọn cách gửi thông báo.
- **Vi phạm:** Việc lựa chọn cách gửi thông báo được viết trực tiếp bằng điều kiện kiểm tra địa chỉ email.
- **Hậu quả:** Khi bổ sung hoặc thay đổi kênh thông báo, phải sửa code hiện tại thay vì mở rộng thông qua abstraction và implementation mới.

## 3. Dependency Inversion Principle (DIP)

- **Vị trí:** `ClubManager.cs`, các phương thức gọi `File.AppendAllText()` và `Console.WriteLine()`.
- **Vi phạm:** Logic nghiệp vụ phụ thuộc trực tiếp vào API ghi file và xuất console, thay vì phụ thuộc vào các abstraction như `IAppLogger` và `INotificationService`.
- **Hậu quả:** Khó thay thế cơ chế ghi log, khó kiểm thử bằng mock hoặc fake và khó thay đổi hạ tầng mà không ảnh hưởng nghiệp vụ.

## 4. Single Responsibility Principle (SRP)

- **Vị trí:** `ClubManager.cs`, phương thức `CreateEvent()`.
- **Vi phạm:** Phương thức vừa tạo sự kiện, ghi log và gửi thông báo cho từng thành viên.
- **Hậu quả:** Thay đổi quy trình thông báo có thể buộc phải sửa logic tạo sự kiện. Nên tách việc tạo sự kiện sang `EventService` và xử lý thông báo qua Observer.

## 5. Open/Closed Principle (OCP)

- **Vị trí:** `ClubManager.cs`, phương thức `PrintClubReport()`.
- **Vi phạm:** Cách tạo báo cáo gắn trực tiếp với `Console.WriteLine()`, không có abstraction cho các định dạng báo cáo.
- **Hậu quả:** Muốn bổ sung CSV hoặc định dạng khác phải sửa phương thức hiện tại. Có thể áp dụng Strategy thông qua `IReportStrategy`.

## 6. Single Responsibility Principle (SRP)

- **Vị trí:** `ClubManager.cs`, phương thức `AddMemberToClub()`.
- **Vi phạm:** Phương thức vừa kiểm tra CLB và giới hạn thành viên, thêm thành viên, ghi log, gửi email và thông báo Slack.
- **Hậu quả:** Nghiệp vụ quản lý thành viên bị trộn với các trách nhiệm hạ tầng và thông báo, khiến việc bảo trì và kiểm thử khó khăn hơn.

## 7. Dependency Inversion Principle (DIP)

- **Vị trí:** `ClubManager.cs`, các phương thức sử dụng trực tiếp danh sách `_clubs`, `_members` và tự thực hiện việc lưu dữ liệu.
- **Vi phạm:** Lớp quản lý nghiệp vụ tự sở hữu và thao tác trực tiếp với dữ liệu thay vì làm việc thông qua abstraction repository.
- **Hậu quả:** Khó thay thế bộ nhớ bằng cơ sở dữ liệu hoặc nguồn lưu trữ khác. Việc tách `IClubRepository` giúp giảm sự phụ thuộc giữa nghiệp vụ và lưu trữ.

## Kết luận

`ClubManager` vi phạm chủ yếu SRP, OCP và DIP do tập trung quá nhiều trách nhiệm, sử dụng các nhánh điều kiện cố định và phụ thuộc trực tiếp vào các API hạ tầng.

Giải pháp refactor là tách các trách nhiệm sang `ClubService`, `EventService`, `ReportService`; sử dụng `IClubRepository`, `IAppLogger`, `INotificationService` để đảo ngược phụ thuộc; đồng thời áp dụng Factory, Decorator, Strategy và Observer để tăng khả năng mở rộng và kiểm thử.