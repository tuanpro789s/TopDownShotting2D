# TopDownShotting2D

## 1. Introduction to Top-Down Shooter Games

A **Top-Down Shooter Game** is an action game genre where the player controls a character from an overhead (top-down) perspective. The gameplay typically focuses on moving the character, aiming, and eliminating enemies using guns or other types of weapons.

## 2. Implementation Requirements

The following features and components are required:

* Display the **health bar** and other information for the player.
* Display the **score** and other information.
* Create a **pause menu** and a **game over menu**.
* Use **2D graphics software** to create **sprites** for the character, enemies, weapons, items, power-ups, scenery, and other game elements.
* Create **background music** and **sound effects** for the game.
* Implement player character movement based on input direction (**WASD keys or gamepad**).
* Display the player's **health status**.
* Handle the collection of **items** and **power-ups**.
* Handle **shooting** and other player actions.
* Create and move **Enemies** following various **movement patterns**.
* Handle **Enemy behavior**, such as attacking the player and dodging bullets.
* Track the **Enemy's health status** with a health bar.
* Handle the defeat of an Enemy and the subsequent **item drops**.
* Create and manage different **weapon types**.
* Handle the firing of **bullets**, including their trajectory, collision, and damage.
* Program **smarter Enemy behavior**, such as seeking cover, coordinated attacks, and reacting to player actions.

***

## II. Solution Approach

### 1. Approach Direction

* **Choice of Development Platform:** Programming on **Winform and C# Code (Visual Studio)**. *Note: This is chosen for faster development time and ease of operation.*
    *(Note: The detailed script analysis in section III suggests the use of the Unity engine, including components like `Rigidbody2D`, `SceneManager`, `OnTriggerEnter2D`, and `animator`, which are typical of Unity development, rather than a standard WinForms application.)*

* **Application Design Process:**
    * **Step 1:** Design the basic interface.
    * **Step 2:** Program the basic processing features.
    * **Step 3:** Program additional processing features.
    * **Step 4:** Finalize the interface design.

***

## III. Game Implementation/Setup

### Concept

* **Idea:** A shooter game set in a **magic world** with **mystical creatures** and **powerful magic**. The player character will focus on **dodging** and **shooting back** at enemies.
* **Player Experience:** Players will immerse themselves in a fast-paced, dramatic, stimulating, and enjoyable atmosphere, honing their **reflex skills** when dodging and retaliating against enemies.

### Creating Menu and Character

#### Menu

This is a **C# script** with three methods used to manage the menu functionalities in a **Unity game**:

* **Choimoi() (NewGame()):**
    * This method is called when the user wants to start a new game. It uses `SceneManager.LoadScene(1)` to load the second scene of the game. Typically, scene 0 is the main menu and scene 1 is the main gameplay scene.
* **Thoat() (Exit()):**
    * This method is called when the user wants to return to the main menu. It uses `SceneManager.LoadScene(0)` to reload the first scene, which is the main menu.
* **thoatgame() (QuitGame()):**
    * This method is called when the user wants to quit the game. It uses `Application.Quit()` to close the game application.

**Script Functionality:**

* When the user presses the **"New Game"** button in the menu, the `Choimoi()` method is called, loading the main game scene.
* When the user presses the **"Exit"** button, the `Thoat()` method is called, reloading the main menu.
* When the user presses the **"Quit Game"** button, the `thoatgame()` method is called, closing the game application.

#### Character (Creating animation for the character)

* Simulating the character's **running appearance**.

#### Enemy

#### Weapon

### 3. Movement Handling

#### 3.1 Movement Processing

**Writing a movement processing function:**
* Writing a function to create movement in the **`move` class** for all Objects.

**Player Movement/Roll Logic:**

The code starts with a conditional block that checks two conditions:
1.  If the **Space key** is pressed (`Input.GetKeyDown(KeyCode.Space)`).
2.  If the `rollTime` variable is less than or equal to zero.

If both conditions are met, the following actions are performed:
* A boolean animator parameter **"Roll"** is set to `true` (`animator.SetBool("Roll", true)`).
* The `moveSpeed` variable is set to `rollBoost`.
* The `rollOnce` variable is set to `true`.

Following this block, another condition checks if `rollTime` is less than or equal to zero AND `rollOnce` is `true`. If so, it performs these actions:
* It sets the boolean animator parameter **"Roll"** to `false` (`animator.SetBool("Roll", false)`).
* It resets `moveSpeed` to `-rollBoost`.
* It sets `rollOnce` to `false`.

If none of the above conditions are met, `rollTime` is reduced by `Time.deltaTime`.

**Character Flipping:**
* A conditional statement flips the character's sprite on the x-axis if `moveInput.x` is less than zero (`characterSR.flipX = moveInput.x < 0`). This flips the character based on the direction of movement.

**Player Character Movement Script Analysis:**

This is a player character control script in a Unity game. It manages **movement, rolling, and the player's health system**. Key features include movement, rolling, and taking damage.

**Variables and Components:**
* `moveSpeed`, `rollBoost`, `rollTime`, `RollTime`, `rollOnce`: Variables to manage movement speed, roll speed, roll duration, and roll state.
* `rb` (`Rigidbody2D`), `animator`, `characterSR` (`SpriteRenderer`): Unity components accessed and used in the script.
* `moveInput`: Stores the player's movement input.
* `playerHealth`: A variable referencing the character's `Health` component.

**Initialization and Update:**
* In `Start()`, Unity components are retrieved and assigned to their respective variables.
* In `Update()`, the script handles the following operations:
    * Gets movement input from the player and updates `moveInput`.
    * Updates the `animator` based on `moveInput`.
    * **Handles the roll action:**
        * If the player presses the **Space key** and `rollTime` is zero, the roll starts by setting the `rollOnce` flag and increasing `moveSpeed`.
        * If `rollTime` is zero and `rollOnce` is `true`, the roll ends by clearing the `rollOnce` flag and decreasing `moveSpeed`.
        * If `rollTime` is greater than zero, `rollTime` is reduced over time.
    * Flips the character's direction based on the movement direction.

**TakeDamage Function:**
* `TakeDamage(int damage)`: A method to reduce the player's health by calling the `TakeDam()` method of the `Health` component.

**Enemy Movement Script Analysis:**

This is an **Enemy AI control script**, including features such as **movement, pathfinding, shooting, and player search**. It uses the **Pathfinding library** to find the shortest path and variables to control the Enemy's behavior.

**Variables and Components:**
* `roaming`: Determines whether the Enemy is walking around (roaming).
* `moveSpeed`: The Enemy's movement speed.
* `nextWPDistance`: The distance to the next waypoint on the path.
* `updateContinuesPath`: Determines whether the path needs to be updated continuously.
* `seeker`: The Pathfinding component to find the path.
* `isShootable`: Determines whether the Enemy can fire a bullet.
* `bullet`: The Enemy's bullet object.
* `bulletSpeed`: The speed of the bullet.
* `timeBtwFire`: The time between shots.
* `fireCoolDown`: The Enemy's fire cooldown time.
* `reachDestination`: A flag to check if the Enemy has reached its destination.
* `path`: The path the Enemy will follow.
* `movecoroutine`: A variable storing the movement coroutine.

**Initialization and Update:**
* In `Start()`, the script begins calculating the path for the Enemy.
* In `Update()`, the script reduces the Enemy's cooldown time and calls the `EnemyFireBullet()` method if the cooldown time has elapsed.

**Shooting Functionality:**
* `EnemyFireBullet()`: Creates a new bullet, gets the player's position, calculates the direction, and adds force to the bullet.

**Path Calculation:**
* `CalculatePath()`: Finds a new destination and starts calculating a new path if the `seeker` has completed the previous path.
* `OnPathComplete(Path p)`: Called when the path calculation is complete. If there are no errors, the path is stored, and `MoveToTarget()` is called.
* `MoveToTarget()`: Starts the `MoveToTargetCoroutine()`.
* `MoveToTargetCoroutine()`: Moves the Enemy along the calculated path. It updates the position, checks if the next point has been reached, and stops when the endpoint is reached.

**Finding Destination:**
* `FindTarget()`: Finds a new destination point based on the **"roaming"** mode or by moving straight to the player.

#### 3.2 Collision Handling Causing Damage

This script simulates the behavior of an Enemy in the game: when the Player comes into contact with the Enemy, it causes damage to the Player within a **predetermined random value range**.

This **C# script** is used to control an Enemy in a Unity game. It has the following main functions:

1.  **Dealing Damage to the Player on Contact:**
    * When the Enemy collides with the Player (when entering the **Trigger zone**), the script starts dealing damage to the Player.
    * The damage is calculated **randomly** within the range of `minDamage` and `maxDamage`.
    * Damage is dealt to the Player **every 0.1 seconds** by calling `playerS.TakeDamage(damage)`.
2.  **Handling Damage to the Enemy:**
    * In `Start()`, the script retrieves its own `Health` component.
    * The `TakeDamage(int damage)` method is used to reduce the Enemy's health by calling `health.TakeDam(damage)`.
3.  **Collision Management:**
    * In `OnTriggerEnter2D(Collider2D collision)`, when the Enemy collides with the Player, the script stores a reference to the Player component and starts calling `DamagePlayer()` every 0.1 seconds.
    * In `OnTriggerExit2D(Collider2D collision)`, when the Enemy leaves the collision area with the Player, the script stops calling `DamagePlayer()`.

**Script Functionality:**

* When the Enemy collides with the Player, the script stores a reference to the Player component and starts calling `DamagePlayer()` every 0.1 seconds.
* In `DamagePlayer()`, the script calculates a random damage value between `minDamage` and `maxDamage`, then calls `playerS.TakeDamage(damage)` to reduce the Player's health.
* When the Enemy leaves the collision area with the Player, the script stops calling `DamagePlayer()`.
* If the Enemy is attacked, the `TakeDamage(int damage)` method is called to reduce the Enemy's health using the `Health` component.

#### 3.3 Character Health Bar and Interaction

This is a **C# script** used to display the **health bar** in a Unity game.

**Variables and Components:**
* `fillBar`: An `Image` variable to display the health bar fill.
* `valueText`: A `TextMeshProUGUI` variable to display the current and maximum health values.

**UpdateBar(int currenValue, int maxValue) Method:**
* This method is used to **update the state of the health bar and the health value**.
* It takes two parameters: `currenValue` (current health value) and `maxValue` (maximum health value).
* In this method, the script performs the following:
    * Updates the `fillAmount` of `fillBar` by calculating the ratio of `currenValue` to `maxValue`. This adjusts the length of the health bar.
    * Updates the `valueText` by concatenating `currenValue` and `maxValue` in the format **"currenValue / maxValue"**.

**Script Functionality:**

* When the health bar status needs to be updated, the script is called with two parameters: `currenValue` and `maxValue`.
* Based on these two parameters, the script calculates and updates the length of the `fillBar` and the text value displayed on the health bar.
* The update of the health bar and text value is performed immediately, ensuring that the health bar and displayed value always reflect the correct status of the character.

---

This is a **C# script** used to manage the **health** of a player character in the game (this script manages the character's health, updates the health bar, handles damage taken, and handles character death).

**Variables and Components:**
* `maxHealth`: The character's maximum health.
* `currentHealth`: The character's current health.
* `healthBar`: A reference to the `HealthBar` component to update the health bar UI.
* `OnDeath`: A **`UnityEvent`** triggered when the character dies.
* `safeTime`: The invulnerability time after being injured.
* `_safeTimeCoolDown`: The remaining invulnerability time.

**Initialization and Update:**
* In `Start()`, the current health is set equal to `maxHealth`, and the health bar is updated.
* In `OnEnable()`, the `OnDeath` event is registered to handle the event when the character dies.
* In `Update()`, `_safeTimeCoolDown` is reduced over time. When the **Space key** is pressed, `TakeDamage(20)` is called to reduce the character's health.

**Taking Damage and Handling Death:**
* **`TakeDamage(int damage)`:** This method is called when the character is attacked. It checks if there is any invulnerability time remaining, then reduces the current health. If health reaches 0 or below, the `OnDeath` event is triggered.
* **`Death()`:** This method is called when the `OnDeath` event is triggered. It destroys the character's object (`Destroy(gameObject)`).

**Script Functionality:**

* When the game starts, the character's current health is set to `maxHealth`, and the health bar is updated.
* When the character is attacked, `TakeDamage(int damage)` is called. If the invulnerability time has passed, the current health is reduced, and the health bar is updated.
* If the current health is 0 or less, the `OnDeath` event is triggered, and the `Death()` method is called to destroy the character's object.
* In `Update()`, the remaining invulnerability time is reduced, and when the Space key is pressed, the character takes damage (for testing purposes).

**Image of Health Bar in Game:**


#### 3.4 Bullet Dealing Damage

This is a **C# script** used to handle **bullets** in a Unity game.

**Variables and Components:**
* `minDamage`: The minimum damage of the bullet.
* `maxDamage`: The maximum damage of the bullet.
* `goodSizeBullet`: A flag to determine if the bullet is "large" or "small."

**Collision Handling:**
* In **`OnTriggerEnter2D(Collider2D collision)`**, the script checks which object the bullet has collided with.
    * If the bullet collides with the **Player** and is **not** "large" (`!goodSizeBullet`), it calculates a random damage value between `minDamage` and `maxDamage`, then calls `Player.TakeDamage(damage)` to reduce the Player's health.
    * If the bullet collides with an **Enemy** and **is** "large" (`goodSizeBullet`), it calculates a random damage value between `minDamage` and `maxDamage`, then calls `EbemyController.TakeDamage(damage)` to reduce the Enemy's health.
    * If the bullet collides with the **Boss** and **is** "large" (`goodSizeBullet`), it calculates a random damage value between `minDamage` and `maxDamage`, then calls `BossHealth.TakeDamage(damage)` to reduce the Boss's health.
* After dealing damage, the bullet is destroyed by calling `Destroy(gameObject)`.

**Script Functionality:**

* When the bullet collides with another object (Player, Enemy, or Boss), `OnTriggerEnter2D(Collider2D collision)` is called.
* The script checks if the colliding object is the Player, Enemy, or Boss.
* If it's the Player and the bullet is not "large," the script calculates a random damage value and calls `Player.TakeDamage(damage)` to reduce the Player's health.
* If it's an Enemy or Boss and the bullet is "large," the script calculates a random damage value and calls `EbemyController.TakeDamage(damage)` or `BossHealth.TakeDamage(damage)` to reduce the corresponding object's health.
* After dealing damage, the bullet is destroyed.

#### 3.5 Monster Summoning Function (Spawner)

This is a **C# script** used to manage the **deployment and defeat of enemies** in a Unity game.

**Variables and Components:**
* `enemyPrefab`: The Enemy's prefab.
* `startTimeBtwSpawn`: The time interval between enemy deployments.
* `playerTransform`: The player's position.
* `timeBtwSpawn`: The time countdown for the next enemy deployment.
* `currentEnemies`: The number of enemies currently on the field.
* `maxEnemies`: The maximum number of enemies allowed on the field at the same time.
* `spawnRadius`: The distance near the player where enemies can spawn.
* `playerAlive`: A flag to check if the player is still alive.

**Update and Deployment:**
* In `Update()`, the script checks if a new enemy can be deployed (based on `timeBtwSpawn`, `currentEnemies`, `maxEnemies`, and `playerAlive`).
* If deployment is possible, the `SpawnEnemyNearPlayer()` method is called to create a new enemy.
* `SpawnEnemyNearPlayer()` calculates the deployment position based on the player's position and `spawnRadius`, then creates a new enemy object.
* After deployment, `currentEnemies` is incremented by 3 (this value seems unusual and might be a typo in the original Vietnamese text, but is translated faithfully).

**Handling Enemy Defeat:**
* The `EnemyDied()` method is called when an enemy is defeated.
* In this method, `currentEnemies` is decremented by 1.
* If the current number of enemies is 7 or less, the `SpawnEnemyNearPlayer()` method is called to deploy more new enemies.

**Handling Player Death:**
* The `PlayerDied()` method is called when the player dies.
* In this method, `playerAlive` is set to `false`, preventing further enemy deployment.

**Script Functionality:**

* In `Update()`, the script checks if a new enemy can be deployed (based on conditions like `timeBtwSpawn`, `currentEnemies`, `maxEnemies`, and `playerAlive`).
* If deployment is possible, `SpawnEnemyNearPlayer()` is called to create a new enemy, near the player's position.
* When an enemy is defeated, `EnemyDied()` is called, reducing `currentEnemies` and potentially deploying more enemies if the current count is less than 7.
* When the player dies, `PlayerDied()` is called, setting `playerAlive` to `false` to prevent further enemy deployment.

### Background Music

### Button Setup

### Camera Following Player

### References

* OOP with C# knowledge (Acquired in school).
* Analysis and self-guided game development tutorial: **Top down shooting** [https://www.youtube.com/watch?v=vjzEiA1bkiw&list=PLHEyg4GEx-GDCpuS3Hm69bB1quBaT8gdS](https://www.youtube.com/watch?v=vjzEiA1bkiw&list=PLHEyg4GEx-GDCpuS3Hm69bB1quBaT8gdS)
