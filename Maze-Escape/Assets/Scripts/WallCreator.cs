using UnityEngine;

namespace MazeEscape
{
    public class WallCreator : MonoBehaviour,IWallCreator
    {
        public void CreateWalls(MazeGeneratorWalls[,] maze, GameObject wallPrefab)
        {
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    Walls walls = Instantiate(wallPrefab, new Vector2(x - (maze.GetLength(0) - 1) / 2f,
                        y - (maze.GetLength(1) - 1) / 2f), Quaternion.identity).GetComponent<Walls>();

                    walls.wallLeft.SetActive(maze[x, y].WallLeft);
                    walls.wallBottom.SetActive(maze[x, y].WallBottom);
                }
            }
        }
    }
}