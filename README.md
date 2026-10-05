# Robot Planet

## Project purpose

Robot Planet is a humorous WPF application where different robot types live in the same world but behave differently.

The project demonstrates:
- inheritance;
- interfaces;
- polymorphism;
- collections;
- validation;
- WPF user interface.

The solution contains two separate projects:

- `RobotPlanet.Core` — domain classes, interfaces, rules and validation.
- `RobotPlanet.WpfApp` — user interface and interaction with Core.

---

## How to run

1. Clone the repository.
2. Open the solution in Visual Studio.
3. Set `RobotPlanet.WpfApp` as the startup project.
4. Build the solution.
5. Run the application.

---

## Class hierarchy

The abstract base class is:

`Robot`

Current subclasses:

- `CleanerBot`
- `ExplorerBot`
- `RepairBot`

All robot types inherit common properties and behaviour from `Robot`.

Each subclass overrides:

- `Work()`
- `CrazyAction()`

This allows the program to use polymorphism.

---

## Interfaces

The project uses two interfaces:

### IChargeable

Defines:

`Charge(int amount)`

It is implemented by robot types that can be charged.

### IRepair

Defines:

`Repair()`

It is implemented by robots capable of performing repair actions.

`RepairBot` implements both `IChargeable` and `IRepair`.

The WPF project uses the `is` operator to check whether the selected robot supports a specific ability.

---

## Object state and validation

Each robot has:

- `Name` — identity assigned through the constructor.
- `Energy` — mutable state.

Energy must remain between 0 and 100.

Invalid constructor input is rejected.

Actions check the current energy level before changing the state.

Invalid actions do not place the robot into an invalid state.

---

## CrazyAction

Each robot has a different implementation of `CrazyAction()`.

### CleanerBot

Activates turbo cleaning mode and tries to vacuum the entire planet.

The action consumes energy.

### ExplorerBot

Attempts to launch into space.

The result depends on the current energy level.

### RepairBot

Tries to create unusual repairs, such as upgrading a coffee machine into a rocket engine.

The action consumes energy.

---

## Collection

All robots are stored in:

`ObservableCollection<Robot>`

This allows the WPF interface to automatically display added and removed robots.

---

## WPF interface

The user can:

- add robots;
- select robots;
- remove robots;
- perform normal work;
- run `CrazyAction()`;
- charge supported robots;
- use repair actions;
- view application messages in the log.

---

## Independently learned WPF element

The project uses `ProgressBar`.

It displays the current energy level of the selected robot.

I chose `ProgressBar` because energy is a numeric value between 0 and 100, so a visual progress indicator makes the robot state easier to understand.

---

## Tested use cases

1. Add a `CleanerBot` with a valid name.
2. Select the robot and use `Work()` — energy decreases.
3. Use `CrazyAction()` — the robot performs its special action and energy changes.
4. Use `Charge +20` — the robot's energy increases but does not exceed 100.
5. Select a robot without `IRepair` and press Repair — the application shows that this robot cannot repair.
6. Try to add a robot with an empty name — the application shows a validation message and does not crash.

---

## Git collaboration

Issue:

TODO

Classmate:

TODO

Pull Request:

TODO

The collaboration task is completed using a separate branch connected to the GitHub Issue.

---

## AI usage

AI tool used:

ChatGPT

Purpose:

- helped plan the project structure;
- helped create example C# and WPF code;
- helped explain inheritance, interfaces and polymorphism;
- helped prepare README documentation.

My own checks and changes:

- I created the Visual Studio solution and projects.
- I connected the WPF project to the Core project.
- I added and tested the classes and interfaces.
- I built and ran the application.
- I tested adding, selecting and removing robots.
- I tested Work, CrazyAction, Charge and Repair actions.
- I checked validation and application behaviour.
