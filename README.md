# Simple 3D Bézier Surface Engine (WinForms / C#)

This project implements an engine for generating, animating, and rendering **3D Bézier surfaces** using a set of **16 control points** arranged in a 4×4 grid.  
The engine supports loading control points from a text file, loading a PNG texture, loading a PNG normal map, and rendering the surface with **Lambert lighting**.  
It also includes animation of a moving light source and interactive controls for rotating the surface, playing with light parameters, and adjusting triangle density.

---

## Features

- **3D bicubic Bézier surface generation** (4×4 control point patch)
- **Load control points** from a `.txt` file
- **PNG texture support**
- **PNG normal map support**
- **Lambert lighting model** for simple diffuse shading
- **Animated moving light source**
- **Surface rotation**
- **Adjustable tessellation level** (increase/decrease number of triangles)
- **Interactive light manipulation** (color, intensity, position)
- **Real-time rendering**

---

## Control Point File Format

The engine loads a plain text file with **exactly 16 lines**, each containing 3 floating-point numbers:

---

## Example Control Point File

```txt
0.0 0.0 0.0
1.0 0.5 0.0
2.0 0.3 0.0
3.0 0.0 0.0
0.0 0.0 1.0
1.0 0.5 1.0
2.0 0.3 1.0
3.0 0.0 1.0
0.0 0.0 2.0
1.0 0.5 2.0
2.0 0.3 2.0
3.0 0.0 2.0
0.0 0.0 3.0
1.0 0.5 3.0
2.0 0.3 3.0
3.0 0.0 3.0

