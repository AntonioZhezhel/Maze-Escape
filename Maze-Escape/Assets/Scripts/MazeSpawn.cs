using NavMeshPlus.Components;
using UnityEngine;

namespace MazeEscape
{
    public class MazeSpawn : MonoBehaviour
    {
        [SerializeField] private GameObject wallPrefab;
        [SerializeField] private GameObject finish;
        [SerializeField] private NavMeshSurface navMeshSurface;
        
        private void Start()
        {
            MazeGenerator mazeGenerator = new MazeGenerator();
            MazeGeneratorWalls[,] maze = mazeGenerator.GenerateMaze();

            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    Walls walls = Instantiate(wallPrefab, new Vector2(x - (mazeGenerator.widthMaze - 1) / 2f,
                        y - (mazeGenerator.heightMaze - 1) / 2f), Quaternion.identity).GetComponent<Walls>();

                    walls.wallLeft.SetActive(maze[x, y].WallLeft);
                    walls.wallBottom.SetActive(maze[x, y].WallBottom);
                }
            }

            navMeshSurface.BuildNavMesh();

            FinishCreator finishCreator = new FinishCreator(mazeGenerator.widthMaze, mazeGenerator.heightMaze);
            finishCreator.CreateFinish(maze,finish);
        }
    }
}