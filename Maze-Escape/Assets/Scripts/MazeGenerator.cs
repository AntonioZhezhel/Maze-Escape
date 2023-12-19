using System.Collections;
using System.Collections.Generic;
using MazeEscape;
using UnityEngine;

public class MazeGeneratorWalls
{
    public int x;
    public int y;

    public bool WallLeft = true;
    public bool WallBottom = true;

    public bool passedCell;
    public int distanceFromStart;
}

public class MazeGenerator : MonoBehaviour
{
    public int widthMaze = 15;
    public int heightMaze = 10;

    private MazeGeneratorWalls farthest;
    
    public MazeGeneratorWalls[,] GenerateMaze()
    {
        MazeGeneratorWalls[,] maze = new MazeGeneratorWalls[widthMaze, heightMaze];

        for (int x = 0; x < widthMaze; x++)
        {
            for (int y = 0; y < heightMaze; y++)
            {
                maze[x, y] = new MazeGeneratorWalls { x = x, y = y };
            }
        }

        for (int x = 0; x < widthMaze; x++)
        {
            maze[x, heightMaze - 1].WallLeft = false;
        }

        for (int y = 0; y < heightMaze; y++)
        {
            maze[widthMaze - 1, y].WallBottom = false;
        }

        RemoveWallsWitchBacktracking(maze);
        Finish(maze);
        return maze;
    }

    private void RemoveWallsWitchBacktracking(MazeGeneratorWalls[,] maze)
    {
        MazeGeneratorWalls currentCell = maze[0, 0];
        Stack<MazeGeneratorWalls> stack = new Stack<MazeGeneratorWalls>();

        currentCell.passedCell = true;
        currentCell.distanceFromStart = 0;

        do
        {
            List<MazeGeneratorWalls> failedCell = new List<MazeGeneratorWalls>();

            int x = currentCell.x;
            int y = currentCell.y;

            if (x > 0 && !maze[x - 1, y].passedCell)
            {
                failedCell.Add(maze[x - 1, y]);
            }

            if (y > 0 && !maze[x, y - 1].passedCell)
            {
                failedCell.Add(maze[x, y - 1]);
            }

            if (x < widthMaze - 2 && !maze[x + 1, y].passedCell)
            {
                failedCell.Add(maze[x + 1, y]);
            }

            if (y < heightMaze - 2 && !maze[x, y + 1].passedCell)
            {
                failedCell.Add(maze[x, y + 1]);
            }

            if (failedCell.Count > 0)
            {
                MazeGeneratorWalls chosenCell = failedCell[Random.Range(0, failedCell.Count)];
                RemoveWalls(currentCell, chosenCell);

                chosenCell.passedCell = true;
                stack.Push(chosenCell);
                currentCell = chosenCell;
                chosenCell.distanceFromStart = stack.Count;
            }
            else
            {
                currentCell = stack.Pop();
            }
        } while (stack.Count > 0);
    }

    private void RemoveWalls(MazeGeneratorWalls currentCell, MazeGeneratorWalls chosenCell)
    {
        if (currentCell.x == chosenCell.x)
        {
            if (currentCell.y > chosenCell.y)
            {
                currentCell.WallBottom = false;
            }
            else
            {
                chosenCell.WallBottom = false;
            }
        }
        else
        {
            if (currentCell.x > chosenCell.x)
            {
                currentCell.WallLeft = false;
            }
            else
            {
                chosenCell.WallLeft = false;
            }
        }
    }

    private void Finish(MazeGeneratorWalls[,] maze)
    {
         farthest = maze[0, 0];

        for (int x = 0; x < maze.GetLength(0); x++)
        {
            if (maze[x, maze.GetLength(1) - 2].distanceFromStart > farthest.distanceFromStart)
            {
                farthest = maze[x, maze.GetLength(1) - 2];
            }

            if (maze[x, 0].distanceFromStart > farthest.distanceFromStart)
            {
                farthest = maze[x, 0];
            }
        }

        for (int y = 0; y < maze.GetLength(1); y++)
        {
            if (maze[maze.GetLength(0) - 2, y].distanceFromStart > farthest.distanceFromStart)
            {
                farthest = maze[maze.GetLength(0) - 2, y];
            }

            if (maze[0, y].distanceFromStart > farthest.distanceFromStart)
            {
                farthest = maze[0, y];
            }
        }

        if (farthest.x == 0)
        {
            farthest.WallLeft = false;
            
        }else if(farthest.y == 0)
        {
            farthest.WallBottom = false;
        }else if(farthest.x == widthMaze - 2)
        {
            maze[farthest.x + 1, farthest.y].WallLeft = false;
            farthest = maze[farthest.x + 1, farthest.y];

        }else if(farthest.y == heightMaze - 2)
        {
            maze[farthest.x, farthest.y + 1].WallBottom = false;
            farthest = maze[farthest.x, farthest.y + 1];

        }

    }
    
    public MazeGeneratorWalls GetFarthestCell()
    {
        return farthest;
    }
    
   

}