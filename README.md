# Texture Sizes in Unity

From the Texture2D Unity documentation:

## Ideal Texture Sizes

The ideal texture size should be a power of two on the edges. These sizes are:

- 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, or 2048 pixels

**Note:** Textures do not have to be square; the width can be different from the height.

## Non-Power-of-Two Textures

It is possible to use other texture sizes (non-powers of two) with Unity:

- Best used for GUI Textures
- If used elsewhere:
  - Converted to uncompressed 32-bit RGBA format
  - Take up more video memory (compared to PVRT(iOS)/DXT(Desktop) compressed textures)
  - Load slower
  - Render slower (especially on iOS)

Generally, non-power-of-two sizes are only used for GUI purposes.

### Scaling Non-Power-of-Two Textures

Non-power-of-two texture assets can be scaled at import time:

1. Use the "Non-power-of-two" option in the advanced texture type in the import settings
2. Unity will scale the texture assets as required
3. In-game, they will behave like any other texture:
   - Can be compressed
<<<<<<< Updated upstream
   - Load very quickly
   
   # Optimizing Unity Audio Import Settings

Incorrect audio import settings can harm game performance, especially on mobile. Key areas to optimize:

- **Load Types**: Choose between `Decompress on Load`, `Compressed in Memory`, and `Streaming` based on memory and CPU impact.
- **Compression Formats**: Use appropriate formats (e.g., Vorbis, MP3) for audio balance.
- **Music vs. SFX**: Stream music, compress or decompress sound effects.
- **Performance Focus**: Optimize for minimal RAM and CPU load.

For a deeper dive, check the full article [here](https://blog.theknightsofunity.com/wrong-import-settings-killing-unity-game-part-2/).


How to Make 3D Text Look Sharp and Smooth in Unity 3D
set size -> 0.1 font size -> 100
   
   
=======
   - Load very quickly 


  # Unity Event Function Execution Order

This document outlines the execution order of various event functions in Unity scripting. Understanding this order is essential for effective game development and behavior management.

## Execution Order

1. **Editor Reset**
   - Initializes script properties when first attached or when reset command is used.

2. **Awake**
   - Called before any `Start` functions; used for initialization.

3. **On Enable**
   - Invoked when the object is enabled (only if active).

4. **On Level Was Loaded**
   - Notifies that a new level has been loaded before the first frame update.

5. **Start**
   - Called before the first frame update if the script instance is enabled.

6. **On Application Pause**
   - Called at the end of the frame when a pause is detected.

7. **Update Order**
   - **Fixed Update**: Called at a fixed interval, often used for physics updates.
   - **Update**: Called once per frame; the main function for frame updates.
   - **Late Update**: Called once per frame after all `Update` functions.

8. **On Pre-Cull**
   - Called before the camera culls the scene.

9. **On Became Visible / Invisible**
   - Called when the object becomes visible/invisible to any camera.

10. **On Pre-Render**
    - Called before the camera starts rendering the scene.

11. **On Render Object**
    - Called after all regular scene rendering is done.

12. **On Post Render**
    - Called after the camera finishes rendering the scene.

13. **On Render Image**
    - Allows post-processing after scene rendering.

14. **OnGUI**
    - Called multiple 
>>>>>>> Stashed changes

# Simple Checklist to Make Your Game Faster

This checklist provides key tips to enhance the performance of your game. Adhering to these guidelines can help ensure smoother gameplay and better resource management.

## Optimization Checklist

1. **Vertex Count**
   - Keep the vertex count below **200K** and **3M per frame** when building for PC (depending on the target GPU).

2. **Shader Selection**
   - Use built-in shaders from the **Mobile** or **Unlit** categories. These are simplified and work well on non-mobile platforms.

3. **Material Management**
   - Limit the number of different materials per scene and share as many materials between objects as possible.

4. **Static Batching**
   - Set the **Static** property on non-moving objects to allow internal optimizations like static batching.

5. **Lighting**
   - Use a single (preferably directional) pixel light affecting your geometry instead of multiple lights.
   - Bake lighting rather than relying on dynamic lighting whenever possible.

6. **Texture Formats**
   - Use compressed texture formats and prefer **16-bit** textures over **32-bit** textures.

7. **Fog Usage**
   - Avoid using fog where possible to reduce rendering complexity.

8. **Occlusion Culling**
   - Implement Occlusion Culling to minimize


   ==============


   # Tối ưu hóa hiệu suất đồ họa trong Unity

Trang này cung cấp hướng dẫn về cách tối ưu hóa hiệu suất đồ họa trong Unity, nhằm cải thiện tốc độ và chất lượng hình ảnh cho trò chơi.

## 1. Định vị vấn đề hiệu suất
- **GPU và CPU**: Xác định vấn đề hiệu suất là rất quan trọng. Thông thường, GPU bị giới hạn bởi độ phân giải và băng thông bộ nhớ, trong khi CPU bị giới hạn bởi số lượng batch cần render.

## 2. Tối ưu hóa CPU
- **Giảm số lượng đối tượng hiển thị**: Kết hợp các đối tượng gần nhau và sử dụng fewer materials.
- **Sử dụng OnDemandRendering**: Giúp điều chỉnh tốc độ render để tiết kiệm năng lượng trong các tình huống như menu hoặc trò chơi theo lượt.

## 3. Tối ưu hóa GPU
- **Giảm số lượng tam giác**: Chỉ sử dụng số lượng tam giác cần thiết và giảm UV seams.
- **Sử dụng Lightmapping**: Bakes ánh sáng tĩnh để giảm tải cho GPU.

## 4. Tối ưu hóa ánh sáng
- **Sử dụng Pixel Lights hợp lý**: Tránh sử dụng nhiều pixel lights cho các đối tượng trên thiết bị yếu.

## 5. Nén và Mipmap Texture
- **Sử dụng texture nén**: Giảm kích thước và tăng hiệu suất render.
- **Bật Generate mipmaps** để tối ưu hóa việc sử dụng texture cho các tam giác nhỏ.

## 6. Culling và LOD
- **Culling**: Làm cho các đối tượng nhỏ vô hình ở khoảng cách xa để giảm tải.
- **Hệ thống Level Of Detail (LOD)**:

https://www.youtube.com/watch?v=6_vBxoNhab4&list=PLsAzinEPgS3QmNnEQ-uzNmQs6W9f14OXJ&index=89
# Tóm tắt: Occlusion Culling trong Unity

Trang này mô tả quá trình occlusion culling trong Unity, giúp cải thiện hiệu suất bằng cách ngăn chặn việc render các GameObjects bị che khuất.

## 1. Khái niệm Occlusion Culling
Occlusion culling là quá trình mà Unity không thực hiện tính toán render cho các GameObjects bị che khuất hoàn toàn bởi các GameObjects khác. Điều này giúp tiết kiệm thời gian CPU và GPU bằng cách loại bỏ các thao tác render không cần thiết.

## 2. Khi nào sử dụng Occlusion Culling
- **Cải thiện hiệu suất**: Occlusion culling có lợi nhất khi dự án bị giới hạn bởi GPU do hiện tượng overdraw.
- **Yêu cầu bộ nhớ**: Đảm bảo có đủ bộ nhớ để tải dữ liệu occlusion culling trong thời gian chạy.
- **Cấu trúc cảnh**: Hoạt động tốt nhất trong các cảnh có khu vực nhỏ, rõ ràng, được phân tách bởi các GameObjects rắn.

## 3. Cách thức hoạt động
- **Baking dữ liệu**: Unity tạo dữ liệu occlusion culling trong trình chỉnh sửa và sử dụng dữ liệu này tại thời gian chạy để xác định những gì camera có thể thấy.
- **Tạo dữ liệu**: Unity chia cảnh thành các ô và sinh dữ liệu mô tả hình học trong các ô, cũng như khả năng nhìn thấy giữa các ô liền kề.

## 4. Tài nguyên bổ sung
Unity sử dụng thư viện Umbra để thực hiện occlusion culling. Có thể tìm thêm thông tin trên trang tài nguyên bổ sung.

Đây là những điểm chính về occlusion culling trong Unity, giúp tối ưu hóa hiệu suất render trong các dự án.

===
# Tạo Đám Mây Động Trong Unity

Video này hướng dẫn cách tạo đám mây động trong Unity. Dưới đây là các bước thực hiện:

## 1. Nhập Hệ Thống Hạt
- Nhấn chuột phải, chọn "Import Package" và nhập "Particle Systems". Nhập tất cả các thành phần.

## 2. Chọn Prefab
- Truy cập vào thư mục `Standard Assets` > `Particle Systems` > `Prefabs` và chọn prefab **Dust Storm** (hoặc **Dust Storm Mobile** cho thiết bị di động). Kéo và thả prefab vào cảnh.

## 3. Điều Chỉnh Vị Trí và Kích Thước
- Đặt kích thước thành **100, 100, 100** và điều chỉnh vị trí Y lên **1000**.

## 4. Cấu Hình Hạt
- Thay đổi **Duration** thành **260** và bật **Pre-warm**.
- Thiết lập **Start Lifetime** thành **5**, **Start Size** thành **-mm**, và **Speed** thành **50**.
- Chuyển **Simulation Space** từ **Local** sang **World**.

## 5. Cài Đặt Hình Dạng và Xoay
- Trong phần **Shape**, đặt **Box Y** thành **10**.
- Trong phần **Rotation Over Lifetime**, đặt từ **-7** đến **7**.

## 6. Chế Độ Hiển Thị
- Đặt **Render Mode** thành **Vertical**.

## 7. Tùy Chỉnh Shader
- Chọn shader **Vertex Lit** trong phần **Particles** và điều chỉnh màu sắc phát sáng cho đám mây.

Cuối cùng, bạn sẽ có được đám mây động trông