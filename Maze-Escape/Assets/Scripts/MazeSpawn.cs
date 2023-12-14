
using UnityEngine;

namespace MazeEscape
{
    public class MazeSpawn : MonoBehaviour
    {
        [SerializeField] private GameObject wallPrefab;
        [SerializeField] private GameObject finish;

        private void Start()
        {
            MazeGenerator mazeGenerator = new MazeGenerator();
            MazeGeneratorWalls[,] maze = mazeGenerator.GenerateMaze();
            
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    Walls walls = Instantiate(wallPrefab, new Vector2(x - (mazeGenerator.widthMaze -1)/2f,
                        y - (mazeGenerator.heightMaze-1)/2f), Quaternion.identity).GetComponent<Walls>();

                    walls.wallLeft.SetActive(maze[x, y].WallLeft);
                    walls.wallBottom.SetActive(maze[x, y].WallBottom);
                }
            }
            
            MazeGeneratorWalls finishCell = mazeGenerator.GetFarthestCell();
            float rotation = 0 ;
            if (finishCell.x != 0 && finishCell.x != mazeGenerator.widthMaze -1)
            {
               rotation = -90; 
            }
            Instantiate(finish, new Vector3(finishCell.x - (mazeGenerator.widthMaze -1)/2f,
                finishCell.y- (mazeGenerator.heightMaze-1)/2f),Quaternion.Euler(0,0,rotation));
        }
    }
}