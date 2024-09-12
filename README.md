# CatSim: A Small Unity Game Project

## Overview
**CatSim** is a 2D side-view game where the player takes care of a **cat** and is responsible for maintaining its needs by selecting which foods to consume. The gameplay revolves around decision-making, where players must balance between healthy and unhealthy food to keep the cat alive.

## Project Concept
The game focuses on food-based gameplay mechanics, where food is stored in an inventory, and the player feed the cat clicking on the slots. The player’s actions determine the cat’s needs (hunger, sleep, health & fun), and the game ends if the cat's health falls too low.

### Main Player Control
- **Character**: Cat
- **Input**: Point & Click
- **Goal**: Consume food to maintain your cat's health.

## Gameplay
During gameplay, you can find various types of food in your inventory. The player must feed the cat when needed, with a focus on keeping the cat alive by consuming more healthy food than unhealthy food.

### Key Mechanics
- **Game Objective**: The game ends when the cat’s health reaches a critical level.
- **Needs Management**: The cat's needs are directly impacted by the types of food the player chooses to give to it.

## Animation: Implementing the Cat's Movements
For the cat character, I utilized Unity's **Animator** component to create smooth animations. Below are the key steps in the animation process:

1. **Sprite Setup**: I downloaded multiple cat sprites for different states (idle & sleeping). (reference at [the bottom of the doc](#credits))
2. **Animator Controller**: I used Unity's Animator to control these sprites, switching between different states based on player input.
3. **Transitions**: Through state transitions, I created a smooth flow between animations, such as from idle to sleeping when the player puts the cat to sleep.
4. **Parameter Control**: Parameters such as "isSleeping" were defined and linked to the player's input, dynamically switching the animation.

The animation system was highly dependent on the player's actions and reflected the OOP design principles. For instance, the cat had its own **PetManager** script that interfaced with the Animator, enabling separation of concerns and a clean modular design.

## Sound and Effects
- **Sound Effects**:
  - **Clicking Sound**: Triggered when interacting with the UI.
  - **Ambiant Sound**: Triggered when lauching the game, changes when switching from **Title Screen** to **Main Screen**.

### User Interface (UI)
- **Title Screen**: The game begins with a title screen displaying **"CatSim"**, then you can type your cat's name.
  - Typing a new name will create a new save, while typing a name you've already played with will load the existing save file.
- **Main Screen**: The game occurs here, you can put your cat to sleep and/or feed it.
- **Credits Screen**: On the **Title Screen** you can choose to see the credits, where all the assets used are disclosed.

## Object-Oriented Programming (OOP) Implementation
The game was structured following **Object-Oriented Programming (OOP)** principles to ensure a modular, scalable design. Below are the main classes and their interactions:

### 1. **PetManager Class**
This class is responsible for managing the cat's state, including mood, animations, and interaction with the player's inputs.

- **Responsibilities**:
  - Processing mouse input.
  - Interfacing with the Animator to change the cat’s animation states.
  
- **OOP Principles Applied**:
  - **Encapsulation**: The cat’s behavior logic and interaction with food were encapsulated within the `PetManager` class. Other game components could interact with the cat via public methods, but the inner workings of the movement logic were hidden.
  - **Abstraction**: Complex interactions, such as handling input and controlling animation transitions, were abstracted into reusable functions. This made the `PetManager` simple to modify or expand.
  - **Polymorphism**: The **PetManager** employs polymorphism in the `ChangeMood()` method, which adjusts the cat's mood based on its internal needs (e.g., hunger, energy). The function changes the cat’s mood dynamically, reflecting how different situations trigger different emotional states.

### 2. **Food & SpecialFood Classes**
Each food item in the game was represented by a `Food` class that stored properties such as whether the food was healthy or unhealthy.

- **Responsibilities**:
  - Representing different food types (healthy vs unhealthy).
  
- **OOP Principles Applied**:
  - **Inheritance**: Healthy and unhealthy foods were derived from a common `Food` class, reducing duplication in the codebase, into the `SpecialFood` class.
 
#### Note-worthy comments
***The `Food` class (and its children) is derived from the `ScriptableObject` class and used along side the `CreateAssetMenu` attribute, which allowed the process of adding new `Food` items to the project way more simple.***

### 3. **NeedsController Class**
This class is responsible for managing the cat's core needs such as energy, fun, hunger, and health. It interacts with the **PetManager** to reflect changes in the pet's mood and behavior based on its current state.

- **Responsibilities**:
  - Monitoring and updating the pet’s core needs (fun, energy, hunger, health).
  - Adjusting need values based on food effects and time progression.
  - Triggering mood changes in the PetManager based on the current state of the pet's needs.
  
- **OOP Principles Applied**:
  - **Single Responsibility Principle (SRP)**: The `NeedsController` class was solely responsible for tracking and modifying the cat’s needs, making the system more maintainable and easier to debug.
  - **Encapsulation**: Health values were encapsulated, preventing other objects from directly manipulating the cat's needs and enforcing a clear set of rules on how needs could be altered.
  - **Abstraction**: The complex internal logic for updating the pet's needs is hidden from other parts of the system. For instance, when a food item is consumed, the **NeedsController** handles updating multiple needs (energy, fun, health, hunger) through the `GetEffects()` method. This abstracts the details of how each need is updated, providing a simple interface for interacting with the pet's needs. This approach ensures that external systems do not need to worry about how each need is modified, only that the correct method is called.

### 4. **MainManager Class**
This class is responsible for managing the overall game logic, including saving and loading the pet's state. It acts as a persistent singleton object, ensuring that the game data persists across different scenes and game sessions. The class interacts closely with the **NeedsController** to update and track the pet’s current needs (fun, energy, health, hunger) and stores these values in a save file when the game ends or when the player exits the application.

- **Responsibilities**:
  - Handling the saving and loading of the pet's data to and from JSON files.
  - Updating the Pet object’s state based on the current values in the NeedsController.
  - Ensuring the pet’s data persists across scene transitions and is saved upon application exit.
  
- **OOP Principles Applied**:
  - **Singleton Pattern**: Ensures only one instance of the MainManager exists, providing global access to game state and data.
  - **Encapsulation**: The pet’s data (name, energy, fun, health, hunger) is encapsulated in the Pet class, which is managed by the MainManager. The details of how the data is saved or loaded are hidden from other systems.
  - **Abstraction**: The complexity of saving and loading data from JSON files is abstracted behind the SavePet() and LoadPet() methods, providing a simple interface for other game systems to interact with.

## Project Milestones
| Milestone             | Description                             | Due Date |
|-----------------------|-----------------------------------------|----------|
| **#1** - Cat Sprite(s) & Animations | Design and implement character sprites and animations | 02/15     |
| **#2** - Main UIs (Title Screen, Game UI, Credits) | Create and integrate user interfaces | 02/20     |
| **#3** - Inventory & Eating System | Implement system to track and process consumed food | 02/24     |
| **#4** - Saving System | Enable saving and loading of game progress | 02/26     |
| **#5** - UI Sound Effects (SFX) | Add sound effects for UI interactions | 02/28     |

Table taken from the project brief available [here](https://docs.google.com/document/d/1NZ8nLOE3OV0SDNr4QsnFl2QqzeIYlQA9bWOQzhrWrUw/edit?usp=sharing)

## How to Play
1. Use the mouse to interact with the UI.
2. Put you cat to sleep.
3. Choos food from your inventory
4. Maintain the cat’s needs by eating healthy food while avoiding bad food.

## Possible Enhancements (Optional)
- **New Food Types**: Add more food items with unique effects.
- **Additional Sound Effects**: Expand sound design for more immersive feedback.
- **Enhanced Visuals**: Upgrade particle effects for different food interactions & maybe create my own assets.

## Credits
**Developed by**: atinyshrimp\
**Assets**: Listed on [itch.io](https://itch.io/c/3103141/pet-simulator)\
**Project Start Date**: February 10, 2023  \
**Completion**: February 28, 2023

