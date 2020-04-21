# Unity project, new technologies course


Deployment adress
https://simmer.io/@FranciG/ouas-new-technologies

Controls: WASD/arrow keys + mouse left for attack.

Enemies wander around and start to chase the player when passing close by.

Paella restores player health.
Game objective is to reach the flying saucer and survive for as long as possible.

## Game description

The player appears in a prefedifned point when the game starts.  The camera chases the player as he walks around the map.
The enemies appear in different spawn points pre-defined in the map automatically at a defined time interval (every 15/20 seconds, depending on the settings of the spawn point).
Power-ups appear in a simmilar way.
The player starts with a level of health, and can keep con getting power ups, until maximun health is reached. When health is 0, the game is terminated. There is a healthbar to display health level.
Enemies have been scripted to wander around the map, but when the player passes trough a circle collider, a chasing script is triggered, so enemies start to chase the player until the player is out of the circle collider that triggers the case script.

The player loses health points when collides with a smaller square collider all enemies have. Different enemy types have different health points and cause different damage rate.

Player weapon also causes a pre-defined damage to enemies. Enemies disappear when all their health poins are lost.
When the player or the enemies are damaged, their sprites will flash red when hit during 0.1 seconds.
The player shoots to the enemies with a mouse left click, and moves around with arrow keys or asdw. The game is terminated by pushing esc key or when the player runs out of health points.

The map is composed of 3 layers. Ocean with a collider that won't allow to pass trough it, rocks and trees that also have the same functionality,  and layer ground, where the player and the enemies are free to walk around. Player, enemies, power ups and so on are in different layers, so different actions are taken when the colliders that are on those layers interact.

All functionallity is implemented using C#.
The characters graphics and power ups are self-made. For the map and the objects such as rocks an trees I used pre-made graphics.
