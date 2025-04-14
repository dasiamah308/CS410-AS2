# CS410-AS2


The dot product is used to determine the direction the player is facing and how far they are from enemies. If the player is facing a certain range, the screen starts to shake. Under the same distance/direction condition, I am also using linear interpolation to add a color fading effect while the screen shakes. (with the intention to make it feel panicked). It just uses a "limit" for how close I want the effect to trigger and properties of the dot product to determine if the player is facing the ghost within the cone I set (kind of like FOV).

I use the trigger for sound effect on triggerboxes placed on the map to make an eerie sound effect. Just uses simple prefab gameobjects, OnTriggerEnter(), and imported sounds found on Unity Hub.

I used the trigger for particle effect to light the sides of the hallway when the player turns into the first hall. I also imported a free fire particle effect to use, as I tried making my own, but it was not good at all. Just uses simple gameobjects and OnTriggerEnter()

Did this solo.
