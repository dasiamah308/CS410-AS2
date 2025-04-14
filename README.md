# CS410-AS2


Using dot product to determine the directions the player is facing and how far they are from enemies. If the player if facing certain range the screen starts to shake. Under the same distance/direction condition, I also am using linear interpolation to add a color fading effect while the screen shake. (with the intention to make it feel panicked). it just uses a "limit" for how close i want the effect to trigger and properties of the dot product to determine if the player is facing the ghost within the cone i set (kind of like FOV).

I use the trigger for sound effect on triggerboxes placed on the map to make a eerie sound effect. Just uses simple prefab gameobjects, OnTriggerEnter(), and imported sounds found on Unity Hub.

I used the trigger for particle effect to light the sides of the hallway when the player turns the first initial hall. I also used an imported a free fire particle effect to use, as I tried making my own but it was not good at all. Just uses simple gameobjects and OnTriggerEnter()
