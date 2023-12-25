# Maze-Escape
You are applying for the position of a Unity Developer at Estoty Game Studio.
As part of the application process, you are required to create a mobile game using Unity.
Game title:
Maze Escape.
Main Task:
The maze should be randomly and procedurally generated, always having a start and a
finish. The maze should always be passable.

![Screenshot 1](https://github.com/AntonioZhezhel/Maze-Escape/assets/42389663/830cfba9-5a0b-45d5-acc4-c57c8fedd858)

The player appears at the start of the maze, and when the player reaches the finish, he
wins.

![Screenshot 2](https://github.com/AntonioZhezhel/Maze-Escape/assets/42389663/ae539c29-4edc-4b07-bfd6-0f3f73ddb86d)

There are enemy seekers in the maze.
Enemies have damage areas. When the player inside the damage area - game over.

![Screenshot 3](https://github.com/AntonioZhezhel/Maze-Escape/assets/42389663/0bc6b402-3f88-42f4-87a7-c8e6056981d0)

Enemies have patrol paths.
Until the enemy sees the player, he must follow his patrol path.

![Screenshot 4](https://github.com/AntonioZhezhel/Maze-Escape/assets/42389663/0644d70a-0980-42fb-85c8-93d1a695da24)

Develop a flexible UI system and add Victory and Defeat screens in the game.
Extra task (Optional):
Enemies have damage areas.
Player has Health Points.
While a player is inside a damage area he gets damage.
Instead of instantly losing the game on damage area enter, the player will loose the
game when his HP is below zero.
Please add a Health bar in the game UI.
When the player is inside of the damage area the enemy starts to follow the player.
If the enemy is following the player and looses sight of the player, the enemy will travel
to the last seen location of the player, and return to patrol mode if the player is not
noticed again.
It is important for us to understand:
● How well do you know how to write clean code and use SOLID
● How well do you know and use design patterns
● How well you build initialization order in the project
● How well do you know how to write optimized code in Unity
● How well do you structure the project
● How well do you work with prefabs
● Which variables you reveal to game / level designers and how are they accessed
It will be a plus if you will use Dependency Injection, especially Zenject Framework.
You can choose whether the final game will be in 2D or 3D.
You can use any available assets for game visuals.
You can use any plugin for Pathfinding.
You can’t use third party solutions for anything except Pathfinding.
You can’t use the Singleton pattern.
Please use Unity version 2021.3.19f1

## DamageDealer Class Documentation

### Description
The `DamageDealer` class is responsible for managing the damage dealt by enemies to the player at specified intervals. It tracks the player, attack damage, and interval between attacks.

### Constructors

#### `DamageDealer(GameObject player, float attackDamage, float intervalDamage)`
- **Parameters:**
  - `player`: The GameObject representing the player.
  - `attackDamage`: The amount of damage dealt in each attack.
  - `intervalDamage`: The time interval between consecutive attacks.

### Properties

- `private readonly GameObject player`: The player GameObject.
- `private readonly float intervalDamage`: The time interval between consecutive attacks.
- `private readonly float attackDamage`: The amount of damage dealt in each attack.
- `private float timeSinceLastDamage`: The time elapsed since the last attack.

### Methods

#### `DealDamage()`
- **Description:** Deals damage to the player at specified intervals.
- **Usage:** Call this method in the enemy's update loop to check for and deal damage to the player.

---

## DataHolder Class Documentation

### Description
The `DataHolder` class is responsible for holding a piece of text to be passed between scenes without destruction on scene changes.

### Properties

- `public string TextToPass`: The text to be passed between scenes.
- `private static DataHolder Instance`: The singleton instance of the `DataHolder`.

### Methods

#### `Awake()`
- **Description:** Ensures that only one instance of `DataHolder` exists and persists between scenes.

---

## DataReceiver Class Documentation

### Description
The `DataReceiver` class is responsible for receiving and displaying text passed through the `DataHolder` in the UI.

### Fields

- `[SerializeField] private TextMeshProUGUI Text`: The TextMeshProUGUI component for displaying the received text.

### Methods

#### `Start()`
- **Description:** Retrieves the `DataHolder` instance and sets the received text to the UI component.

---

## Enemy Class Documentation

### Description
The `Enemy` class represents an enemy in the game. It utilizes the `VisionDetector` to detect and pursue the player.

### Fields

- `[SerializeField] private float visionRadius`: The radius within which the enemy can detect the player.
- `[SerializeField] private float attackRadius`: The radius within which the enemy can attack the player.
- `[SerializeField] private float attackDamage`: The damage dealt by the enemy in each attack.
- `[SerializeField] private float intervalDamage`: The time interval between consecutive attacks.
- `[SerializeField] private NavMeshAgent navMeshAgent`: The NavMeshAgent component for navigation.
- `private GameObject player`: The player GameObject.
- `private VisionDetector visionDetector`: The vision detector for detecting the player.

### Methods

#### `Start()`
- **Description:** Initializes the enemy's configuration and vision detector.

#### `Update()`
- **Description:** Updates the enemy's behavior, moving towards the player if visible.

#### `MoveTowardsPlayer()`
- **Description:** Moves the enemy towards the player using NavMeshAgent.

---

## EnemyPatrol Class Documentation

### Description
The `EnemyPatrol` class handles the patrol behavior of enemies between predefined patrol points.

### Fields

- `[SerializeField] private int numberOfPatrolPoints`: The number of patrol points.
- `[SerializeField] private float patrolPointDistance`: The distance between patrol points.
- `[SerializeField] private NavMeshAgent navMeshAgent`: The NavMeshAgent component for navigation.
- `private Transform[] patrolPoints`: The array of patrol points.
- `private int currentPatrolIndex`: The current index of the patrol point.

### Methods

#### `Start()`
- **Description:** Initializes the patrol points and starts patrolling.

#### `Update()`
- **Description:** Checks if the enemy has reached the current patrol point and updates its destination accordingly.

#### `NavMeshAgentOnNavMesh()`
- **Description:** Checks if the NavMeshAgent is on the NavMesh.

#### `PatrolToNextPoint()`
- **Description:** Sets the destination of the NavMeshAgent to the next patrol point.

---

## EnemySpawn Class Documentation

### Description
The `EnemySpawn` class is responsible for spawning enemies in the maze based on specified conditions.

### Fields

- `[SerializeField] private GameObject enemyPrefab`: The prefab of the enemy to be spawned.
- `[SerializeField] private GameObject Player`: The player GameObject.
- `[SerializeField] private int numberOfEnemies`: The number of enemies to spawn.
- `[SerializeField] private float minDistanceBetweenEnemies`: The minimum distance between spawned enemies.
- `[SerializeField] private float minDistanceToPlayer`: The minimum distance between enemies and the player.
- `private IEnemySpawner enemySpawner`: The enemy spawner interface.

### Methods

#### `Start()`
- **Description:** Generates a maze using `MazeGenerator` and spawns enemies based on specified conditions.

---

## EnemySpawner Class Documentation

### Description
The `EnemySpawner` class is responsible for spawning enemies in the maze without overlapping and ensuring a minimum distance from the player.

### Constructors

#### `EnemySpawner(GameObject enemyPrefab)`
- **Parameters:**
  - `enemyPrefab`: The prefab of the enemy to be spawned.

### Methods

#### `SpawnEnemies(MazeGeneratorWalls[,] maze, GameObject player, int numberOfEnemies, float minDistanceBetweenEnemies, float minDistanceToPlayer)`
- **Description:** Spawns enemies in the maze based on specified conditions.
- **Parameters:**
  - `maze`: The maze layout.
  - `player`: The player GameObject.
  - `numberOfEnemies`: The number of enemies to spawn.
  - `minDistanceBetweenEnemies`: The minimum distance between spawned enemies.
  - `minDistanceToPlayer`: The minimum distance between enemies and the player.

#### `IsDistanceEnough(Vector2 currentPosition, List<Vector2> createdPositions, float minDistance)`
- **Description:** Checks if the distance between the current position and existing positions is sufficient.
- **Parameters:**
  - `currentPosition`: The current position.
  - `createdPositions`: The list of already created positions.
  - `minDistance`: The minimum distance required.

#### `InstantiateEnemy(int x, int y)`
- **Description:** Instantiates an enemy at the specified position.
- **Parameters:**
  - `x`: The x-coordinate of the position.
  - `y`: The y-coordinate of the position.

---

## Finish Class Documentation

### Description
The `Finish` class triggers the end of the game when the player reaches the finish area.

### Fields

- `private DataHolder DataHolder`: The DataHolder instance.

### Methods

#### `OnTriggerEnter2D(Collider2D other)`
- **Description:** Checks if the player has entered the finish area, updates the DataHolder, and reloads the scene.

---

## MazeGenerator Class Documentation

### Description
The `MazeGenerator` class generates a maze using a backtracking algorithm and ensures a path from start to finish.

### Fields

- `[SerializeField] public int widthMaze = 15`: The width of the maze.
- `[SerializeField] public int heightMaze = 10`: The height of the maze.
- `private MazeGeneratorWalls farthest`: The farthest cell from the start.

### Methods

#### `GenerateMaze()`
- **Description:** Generates a maze using a backtracking algorithm.
- **Returns:** A 2D array representing the maze layout.

#### `

RemoveWallsWitchBacktracking(MazeGeneratorWalls[,] maze)`
- **Description:** Removes walls using a backtracking algorithm.

#### `RemoveWalls(MazeGeneratorWalls currentCell, MazeGeneratorWalls chosenCell)`
- **Description:** Removes walls between the current cell and the chosen cell.

#### `Finish(MazeGeneratorWalls[,] maze)`
- **Description:** Ensures a path from the start to the finish and updates the farthest cell.

#### `GetFarthestCell()`
- **Description:** Gets the farthest cell from the start.

---

## MazeSpawn Class Documentation

### Description
The `MazeSpawn` class spawns maze walls and a finish point, and builds a NavMesh for navigation.

### Fields

- `[SerializeField] private GameObject wallPrefab`: The prefab of the maze wall.
- `[SerializeField] private GameObject finish`: The prefab of the finish point.
- `[SerializeField] private NavMeshSurface navMeshSurface`: The NavMeshSurface component.

### Methods

#### `Start()`
- **Description:** Generates a maze using `MazeGenerator`, spawns walls, a finish point, and builds the NavMesh.

---

## PatrolPointCreator Class Documentation

### Description
The `PatrolPointCreator` class is an abstract class responsible for creating patrol points for enemies.

### Methods

#### `CreatePatrolPoints(Transform parent, int numberOfPoints, float distance, ref Transform[] points)`
- **Description:** Creates patrol points around a specified parent.
- **Parameters:**
  - `parent`: The parent transform around which patrol points will be created.
  - `numberOfPoints`: The number of patrol points to create.
  - `distance`: The distance between patrol points.
  - `points`: A reference to the array where patrol points will be stored.

#### `GetRandomPointInsideMaze()`
- **Description:** Gets a random point inside the maze.

---

## Player Class Documentation

### Description
The `Player` class controls the player's movement, health, and handles player death.

### Fields

- `[SerializeField] private float speed`: The movement speed of the player.
- `[SerializeField] private float maxHealth`: The maximum health of the player.
- `[SerializeField] private TextMeshProUGUI healthText`: The TextMeshProUGUI component for displaying health.
- `private float currentHealth`: The current health of the player.
- `private DataHolder DataHolder`: The DataHolder instance.

### Methods

#### `Start()`
- **Description:** Initializes the player's position and health.

#### `TakeDamage(float damage)`
- **Description:** Reduces the player's health by the specified amount.
- **Parameters:**
  - `damage`: The amount of damage to be taken.

#### `Die()`
- **Description:** Handles player death, updates DataHolder, and reloads the scene.

#### `Update()`
- **Description:** Calls the PlayerControl method to handle player movement.

#### `PlayerControl()`
- **Description:** Handles player movement based on input.

---

## VisionDetector Class Documentation

### Description
The `VisionDetector` class detects the player within the enemy's vision radius and deals damage if the player is within the attack radius.

### Fields

- `private readonly float attackRadius`: The radius within which the enemy can attack.
- `private readonly float visionRadius`: The radius within which the enemy can detect the player.
- `private readonly GameObject player`: The player GameObject.
- `private readonly DamageDealer damageDealer`: The DamageDealer instance.
- `private readonly Transform enemyTransform`: The transform of the enemy.

### Methods

#### `IsPlayerVisible()`
- **Description:** Checks if the player is visible within the enemy's vision.
- **Returns:** True if the player is visible; otherwise, false.
