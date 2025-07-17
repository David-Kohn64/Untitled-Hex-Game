# Untitled Hex Game
Unity puzzle game


            3,0
        2,1     4,1
    1,2     3,2     5,2
0,3     2,3     4,3     6,3
    1,4     3,4     5,4
0,5     2,5     4,5     6,5
    1,6     3,6     5,6
0,7     2,7     4,7     6,7
    1,8     3,8     5,8
0,9     2,9     4,9     6,9
    1,10    3,10    5,10
        2,11    4,11
            3,12

Notes: 

Conversions from coords to unity position:
xPos = (x - mapComplexity) * xUnit; U<-R
x = (mapComplexity + (xPos / xUnit)); R<-U
yPos = ((mapComplexity * 2) - y) * yUnit;
y = (mapComplexity * 2) - (yPos / yUnit);


Level Ideas:
-Set off blue chain in two spots for faster deletion
-Maze of launch pads
-Constant On/Off
-Race the blue (clockwise vs counterclockwise launches)

Tile concepts:
-Wall/Can’t walk on
-Slide/Ice
-Growth
-Explode when adjacent
-Disappear after 3 sec
-Next jump is 2 jumps
-On/Off
-Button/Switch
-Teleporter
