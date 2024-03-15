This is a simple gardening game developed in Unity. It is developed for the simple aim of educating basics of gardening via a gardening simulator. Plants must be planted into suitable soils according to their favorable growth properties. 
Plant generation for this game uses the concept of L-systems, with each plant having unique strings for different character generation.

The plants and their respective generator strings are as follows:
Rhododendron: [*+FX]X[+F#X][/+F#-FX#]
Camellia: [F[-X+F[+FX]][*-X+F[+FX]][/-X+F[+FX]-X]]
Azalea: [F[-X+F[+FX#]][*-X+F[+FX#]][/-X+F[+FX#]-X]#]
Moor Grass: [F[/-X+F[+FX]-X]][*FX/F*X][F/*F]
Lavender: [F^^^[/-X^^^+F^^[+FX^^^]-X^^^]][*FX^^/F*X^^][F^/*F^^]
Phacelia: [F[+X/FX+/*^^^]F[-X/F+/F*^^^]+X/*XF^^^]

With the geometric interpretation characters of:
X : No rule attached, to read the axiom
F : Move forward by line length and draw a line
+ : Turn left by angle
- : Turn right by angle
* : Turn forwards (into the screen) by angle
/ : Turn backwards (out of screen) by angle
[ : Push current state into stack
] : Pop current state from the stack
# : Draw pink leaves
^ : Draw purple leaves

This is my first game ever made in Unity, developed in accordance to finish my MENG Software Engineering dissertation project.
