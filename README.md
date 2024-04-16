Open ExampleScene and switch between NewTest and OldTest by turning the GameObjects on and off.

In OldTest I make my own mesh and keep track of and draw the WorldSpace vertices manually.
In NewTest I use a regular Unity mesh asset and let Unity handle the transformations (I only calculate the rotations).

OldTest demonstrates general transformations.
NewTest demonstrates Slerp.
