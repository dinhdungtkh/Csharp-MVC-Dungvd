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
   
   