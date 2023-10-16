# Miasma
An open-world narrative-driven survival game, drawing inspiration from Project Zomboid, Stardew Valley, and Graveyard Keeper.

Current Features:
- Resource Gathering (Trees/Ores), including an inventory system.
- Ranged combat.
- Enemy AI using A* Pathfinding and a Finite State Machine to handle behavioural states.

Much of the focus of this project has been learning to develop in a flexible and scalable way - avoiding bad code such as tight coupling and adhering to SOLID principles where possible. 

The current branch is dedicated to prototyping melee combat as this will be a large focus of the game. Creating an engaging and challenging melee combat system is difficult in a skewed top-down perspective so I'm currently examining games such as Hyper Light Drifter and Cat Quest to see what makes them work so well, although I am aiming for a more souls-like style of combat with slower, timing-based gameplay. In particular, I'm really interested in adopting Sekiro's method of using Parrys to create an attack window. Ultimately, I'd like to incorporate this but slow it down a bit.
- So far, I've been developing the enemy AI. Currently, it follows the player when attacked and attempts to attack the player. It can take damage from the player which sends it into a temporary "damaged" state, interrupting any current attack and stunning it for a short duration.
- The player can also attack the enemy using melee combat. I've used Cat Quest's lock-on mechanic where the player "jumps" towards the enemy when attacking if the enemy is within a given radius around the player. This is important because distance perception is quite difficult with a skewed top-down perspective. By introducing lock-on, the player can focus less on janky distance calculations and more on reacting to animation timings.
What I need to do:
- Get rid of the external A* pathfinding library and use my own. While it does a great job I can foresee a great deal of time wasted on trying to get it to work with my combat mechanics. Writing my own library would provide far greater flexibility.
- Introduce player interrupts. Currently the player can interrupt the enemy attack but the enemy cannot do the same to the player.
- Introduce parrying. This is a particularly difficult roadblock because I firstly need some animations for this to work and secondly need to tune those animations a great deal to get it feeling right. I have a lot more experience in the scripting side of things while handling animations is all new to me.

https://i.imgur.com/APaxT3M.gif
