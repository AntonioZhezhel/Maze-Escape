using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSpawn : MonoBehaviour
{
    [SerializeField] private GameObject wallPrefab;

    private void Start()
    {
        MazeGenerator mazeGenerator = new MazeGenerator();
        MazeGeneratorWalls[,] maze = mazeGenerator.GenerateMaze();

        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y <maze.GetLength(1); y++)
            {
                MazeGeneratorWalls cell = maze[x, y];
                Vector3 spawnPosition = new Vector3(cell.x, 0, cell.y);
                if (cell.wallLeft)
                {
                    GameObject wall = Instantiate(wallPrefab, spawnPosition, Quaternion.identity);
                    wall.transform.Rotate(0, 90, 0);
                }
                if (cell.wallBottom)
                {
                    GameObject wall = Instantiate(wallPrefab, spawnPosition, Quaternion.identity);
                }
            }
        }
    }
}
