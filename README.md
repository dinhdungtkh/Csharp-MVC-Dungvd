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