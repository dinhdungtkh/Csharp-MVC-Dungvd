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