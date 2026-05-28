````md
# Escape of Your Mind

Escape of Your Mind là một game 2D Roguelike Platformer được phát triển bằng Unity 6 trong khuôn khổ môn học Phát triển Ứng dụng Game. Người chơi bước vào thế giới bên trong tâm trí của một nhân vật đang trải qua cuộc chiến giữa hai nhân cách đối lập: Ego (ánh sáng - lý trí) và Alter (bóng tối - bản năng).

Trò chơi tập trung vào trải nghiệm vượt chướng ngại vật, thu thập kỹ năng đặc biệt và đưa ra lựa chọn ảnh hưởng đến lối chơi. Mỗi kỹ năng mang đặc điểm riêng và mở ra nhiều cách tiếp cận màn chơi khác nhau.

---

## Gameplay

### Tính năng chính

- Di chuyển trái/phải và nhảy
- Hệ thống Coin + Score
- Hệ thống đếm ngược thời gian
- Hệ thống thắng/thua
- Hệ thống âm thanh (BGM + SFX)
- 4 kỹ năng đặc biệt:
  - JumpBoost
  - Flow (Dash)
  - PhaseThrough
  - Grapple
- Enemy AI
- DeathZone
- Cooldown UI trực quan
- 3 stage với độ khó tăng dần

---

## Kỹ năng

| Skill        | Nhân cách  | Mô tả                              | Cooldown |
|--------------|------------|------------------------------------|----------|
| JumpBoost    | Ego        | Nhảy cao gấp đôi                   | 1s       |
| Flow         | Ego        | Lướt nhanh theo hướng di chuyển    | 1.5s     |
| PhaseThrough | Alter      | Xuyên qua nền tảng                 | 5s       |
| Grapple      | Alter      | Kéo nhân vật đến điểm móc gần nhất | 2s       |

---

## Screenshot / Gameplay

### Menu Game

<img width="1440" height="900" alt="Ảnh màn hình 2026-05-27 lúc 13 09 42" src="https://github.com/user-attachments/assets/e72dc588-37a0-44a7-9f7a-d3643ec4932b" />

### Gameplay

<img width="1440" height="899" alt="Ảnh màn hình 2026-05-27 lúc 13 09 57" src="https://github.com/user-attachments/assets/fe6b91fe-9ee5-4bf4-8346-78b0f80defe6" />

### GIF Demo

![Gameplay GIF](images/gameplay.gif)

> Đặt các ảnh/GIF vào thư mục `/images`

Cấu trúc đề xuất:

```

Project
│
├── images
│ ├── menu.png
│ ├── gameplay.png
│ └── gameplay.gif

```

---

## Hướng dẫn cài đặt và chạy

### Clone project

```bash
git clone https://github.com/your-username/your-repo-link.git
````

### Mở project bằng Unity

Yêu cầu:

* Unity 6 (6000.0.x)

Mở:

```bash
Unity Hub
→ Add Project
→ Chọn thư mục project
```

### Chạy game

Trong Unity:

```bash
Assets
→ Scenes
→ MainMenu
→ Play
```

Hoặc build:

```bash
File
→ Build Profiles
→ PC hoặc WebGL
→ Build and Run
```

---

## Điều khiển

| Phím      | Chức năng         |
| --------- | ----------------- |
| A / ←     | Di chuyển trái    |
| D / →     | Di chuyển phải    |
| Space / W | Nhảy              |
| E         | Kích hoạt kỹ năng |

---

## Công nghệ sử dụng

| Công nghệ                 | Phiên bản          |
| ------------------------- | ------------------ |
| Unity                     | Unity 6 (6000.0.x) |
| C#                        | .NET 9             |
| Visual Studio Code        | Latest             |
| Git/GitHub                | 2.x                |
| TextMeshPro               | Built-in           |
| Cinemachine               | Built-in           |
| Universal Render Pipeline | Built-in           |

---

## Yêu cầu hệ thống

### Tối thiểu

**Hệ điều hành**

* Windows 10/11
* macOS

**CPU**

* Intel Core i3 hoặc tương đương

**RAM**

* 4GB

**GPU**

* Hỗ trợ DirectX 10+

**Dung lượng trống**

* 1GB+

---

### Khuyến nghị

**CPU**

* Intel Core i5 trở lên

**RAM**

* 8GB+

**GPU**

* GPU hỗ trợ DirectX 11+

---

## Thành viên và phân công

| Thành viên              | Vai trò                   | Công việc                                                                 | Đóng góp |
| ----------------------- | ------------------------- | ------------------------------------------------------------------------- | -------- |
| Trần Đình Việt Huy      | Core Gameplay & Mechanics | Xây dựng kiến trúc hệ thống, điều khiển nhân vật, Skill System, Singleton | 44%      |
| Nguyễn Trần Quỳnh Hương | Level Design & Art        | Thiết kế màn chơi, Tilemap, Camera, Enemy, môi trường                     | 28%      |
| Nguyễn Bích Trân        | UI, Audio & Management    | UI, AudioManager, Screen Flow, kiểm thử và báo cáo                        | 28%      |

---

## Cấu trúc dự án

```
Assets
│
├── Scripts
│ ├── Player
│ ├── Managers
│ ├── Skills
│ ├── UI
│ └── Audio
│
├── Scenes
│
├── Sprites
│
├── Prefabs
│
├── Audio
│
└── Animations
```

---

## Các Design Pattern sử dụng

### Singleton Pattern

Dùng trong:

* GameManager
* AudioManager

### ScriptableObject

Dùng cho:

* SkillData

### Coroutine

Dùng cho:

* Dash
* PhaseThrough
* Grapple

---

## Hướng phát triển

* Thêm HP System
* Checkpoint System
* Dialogue System
* Ending System
* Shop + Upgrade
* Random Map Generation
* Thêm stage mới
* Xuất bản WebGL/PC

---

## Tài liệu tham khảo

* Unity Documentation
* TextMeshPro Documentation
* Cinemachine Documentation
* Game Programming Patterns
* Unity Learn

---

## Demo Video



---

## License

Dự án được phát triển phục vụ mục đích học tập và nghiên cứu.

```

README này phù hợp kiểu repo đồ án sinh viên trên GitHub: có mô tả, gameplay, ảnh, setup, phân công nhóm, tech stack và yêu cầu hệ thống.
```
