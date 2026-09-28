# Bowie The Frog

**A released Unity/C# game by Dallen Larson.**

Bowie The Frog was released on Xbox, Google Play, itch.io, Newgrounds, and Game Jolt. This repository shares game scripts and assets for exploring how the game works.

## Engineering highlights

- Player movement connected to a 2D character controller and animation state.
- Randomized room-prefab spawning.
- Separate scripts for scoring, collectibles, hazards, boundaries, and menus.
- Prefabs, animation, sprites, and sound organized alongside the gameplay source.

## Source tour

| Source | Responsibility |
| --- | --- |
| [PlayerMovement.cs](Scripts/PlayerMovement.cs) | Movement updates and animation parameters |
| [RoomSpawner.cs](Scripts/RoomSpawner.cs) | Random room selection and prefab instantiation |
| [RoomTemplates.cs](Scripts/RoomTemplates.cs) | Room template collection |
| [ScoreSystem.cs](Scripts/ScoreSystem.cs) | Scoring logic |
| [Collectable.cs](Scripts/Collectable.cs) | Collectible behavior |
| [Lava.cs](Scripts/Lava.cs) | Hazard behavior |

## Exploring the project

Start with the scripts above, then inspect [Prefabs](Prefabs) and [Animation](Animation). This repository is a source-and-assets snapshot: its root does not include the Unity ProjectSettings and Packages directories needed to establish a reproducible editor setup.

## Credit

Please credit Dallen Larson in any project using this source. I'd also love to hear if you build something with it.

[Portfolio](https://www.dallenlarson.com/) · [Contact](mailto:dallen@dallenlarson.com)
