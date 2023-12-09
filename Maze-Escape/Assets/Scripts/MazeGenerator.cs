using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGeneratorWalls
{
    public int x;
    public int y;
    
    public bool wallLeft = true;
    public bool wallBottom = true;
}

public class MazeGenerator 
{
    [SerializeField] private int WidthMaze = 10;
    [SerializeField] private int HeightMaze = 10;
    
    public MazeGeneratorWalls[,] GenerateMaze()
    {
        MazeGeneratorWalls[,] maze = new MazeGeneratorWalls[WidthMaze, HeightMaze];

        for (int x = 0; x <WidthMaze; x++)
        {
            for (int y = 0; y < HeightMaze; y++)
            {
                maze[x, y] = new MazeGeneratorWalls { x = x, y = y };
            }
        }
        return maze;
    }
    
}
