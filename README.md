# Resque the Princess — 2D Dungeon Action Game

A top-down 2D action dungeon crawler built in **Unity (C#)**. Fight through 10 procedurally generated rooms, collect keys, defeat enemies, and rescue the princess.

---

## Gameplay

- Move with **WASD** or arrow keys
- **Left-click** to attack, **right-click** to block
- Clear every enemy in a room to spawn a **key**
- Use the key to unlock the door to the next room
- Survive all **10 rooms** and reach the final chamber to win
- Pick up **health potions** dropped by enemies to restore HP
- Die and choose to **restart** or return to the **main menu**

---

## Features

| Feature | Details |
|---|---|
| Procedural room generation | 10 rooms spawn sequentially; each room gets random wall/floor colors, random grass decoration, and a random enemy count (2–8 per room) |
| Two enemy types | Basic enemies from room 1; armored enemies start appearing from room 5 onwards |
| Enemy AI | Enemies chase the player within melee range, attack with a cooldown, apply knockback on hit, and display a health bar on damage |
| Health potion drops | Enemies have a 50% chance to drop a health potion on death |
| Combat system | Player attacks via animation-driven hitboxes; blocking negates all incoming damage |
| Animated health bar | Player HUD shows a dual-slider health bar with a trailing damage effect |
| Room unlock system | All enemies in a room must die before the key spawns; key unlocks the door to the next room |
| Intro cutscene | Animated story sequence plays before the game starts |
| Tutorial level | Dedicated tutorial scene explains controls and mechanics |
| Audio | Sound effects for attacks, damage, key pickup, and health potions; separate audio settings screen |
| Pause menu | In-game pause with resume and menu options |
| Smooth camera | Camera follows the player with spherical linear interpolation (Slerp) |
| Room pop-in animation | Each room scales up from zero when it spawns |

---

## Architecture

```
PlayerMovement.cs     — 4-directional movement, sprite flip, key/door trigger detection
PlayerDamage.cs       — Attack input, defense toggle, health tracking, death trigger
Enemy.cs              — Chase/attack AI, knockback, health bar, health potion drop on death
LevelRandomizer.cs    — Per-room setup: colors, grass, enemy spawning, key drop on room clear
MapGenerator.cs       — Coroutine that chains 10 rooms and wires the final door
FinalDoor.cs          — Triggers win sequence when player enters with a key
CameraFollow.cs       — Slerp-based smooth camera follow
PickUpItems.cs        — Health potion pickup and HP restoration
Death.cs              — Restart / main menu scene transitions
EndLevel.cs           — Win animation and return-to-menu flow
IntroScript.cs        — Cutscene audio cues and scene transition
AudioSettings.cs      — Volume control (main menu)
AudioSettingsInGame.cs — Volume control (in-game)
PauseScript.cs        — Pause menu logic
TutoLevel.cs / LeaveTuto.cs / PlatformTuto.cs — Tutorial scene management
RandomColor.cs        — Randomizes decoration sprite colors
```

---

## Tech Stack

- **Engine**: Unity (Universal Render Pipeline)
- **Language**: C#
- **Physics**: Unity 2D Rigidbody + Collider2D
- **UI**: Unity UI (Slider, Canvas, Animator)
- **Audio**: Unity AudioSource / AudioClip
- **Art**: Tasty Characters — Castle Pack (2D sprite assets)
- **Text**: TextMesh Pro

---

## How to Run

> Requires **Unity 2021.3 LTS** or later (URP).

1. Clone the repository.
2. Open the project folder in **Unity Hub**.
3. Open the `Scenes` folder and load the **Main Menu** scene.
4. Press **Play** in the Unity Editor, or build for your target platform via `File → Build Settings`.

---

## Project Structure

```
Assets/
  Scripts/        — All C# gameplay scripts
  Scenes/         — Main Menu, Tutorial, Game, End scenes
  Sprites/        — Castle Pack sprite sheets
  Settings/       — URP render pipeline asset
  TextMesh Pro/   — TMP font assets
```
