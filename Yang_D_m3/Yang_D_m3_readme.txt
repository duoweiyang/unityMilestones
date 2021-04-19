Duo-Wei Yang
dyang305@gatech.edu
dyang305

- Working game start menu which has a start game button and exit button over a white panel that does not cover the whole screen. 
- The camera background has a post-processing effect (grain, depth of field).
- If you press the escape button, you may restart with the "Restart Game" button or quit with the "Exit" button
- Press escape to toggle the in-game menu on or off
- The game is paused when in-game menu is enabled
- There is a collectable pink ball with sound effect that only SomeDude_RootMotion can collect
- The trigger-based animated prefab objects are fruits on a prefab tree. There are three trees in the scene and four fruits on each tree.
- If the player is reasonably close enough to the tree, the fruits wiggle and drop to the ground. The fruits from these trees could potentially be collectables or HP regeneration items for the group project game.
- If the player is at 5 radius from a certain fruit, the object resets/grows back onto the tree. This is done by spherical collision per each fruit, which is why they don't all grow back at the same time necessarily. 
- Animations are done via Mecanim. 
- The fruit and trees were all made by myself inside Unity.
- Name on HUD is my name

Instructions:
- Press "Start Game" to begin or "Exit" to quit.
- Use arrow keys or WASD to move characters around
- Press T to switch characters
- Press left control key to make SomeDude_RootMotion (second character) press the red ball when near the blue circle (not needed for M3, but is still there) 
- Press different numbers for different max speeds for the characters (0 being the highest/default speed and 1 being the lowest)
- Press escape key to restart or quit the game
- Open demo.unity for the main scene and open GameMenuScene for the starter menu/scene