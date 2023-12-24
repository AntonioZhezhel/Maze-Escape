using UnityEngine;

namespace MazeEscape
{
    public class FinishCreator
    {
        private readonly int widthMaze;
        private readonly int heightMaze;

        public FinishCreator(int width, int height)
        {
            widthMaze = width;
            heightMaze = height;
        }

        public void CreateFinish(MazeGeneratorWalls[,] maze, GameObject finishPrefab)
        {
            MazeGeneratorWalls farthest = FindFarthestCell(maze);

            float rotation = 0;

            if (farthest.x != 0 && farthest.x != widthMaze - 1)
            {
                rotation = -90;
            }

            InstantiateFinish(finishPrefab, farthest.x, farthest.y, rotation);
        }

        private MazeGeneratorWalls FindFarthestCell(MazeGeneratorWalls[,] maze)
        {
            MazeGeneratorWalls farthest = maze[0, 0];

            for (int x = 0; x < widthMaze; x++)
            {
                if (maze[x, heightMaze - 2].distanceFromStart > farthest.distanceFromStart)
                {
                    farthest = maze[x, heightMaze - 2];
                }

                if (maze[x, 0].distanceFromStart > farthest.distanceFromStart)
                {
                    farthest = maze[x, 0];
                }
            }

            for (int y = 0; y < heightMaze; y++)
            {
                if (maze[widthMaze - 2, y].distanceFromStart > farthest.distanceFromStart)
                {
                    farthest = maze[widthMaze - 2, y];
                }

                if (maze[0, y].distanceFromStart > farthest.distanceFromStart)
                {
                    farthest = maze[0, y];
                }
            }

            return farthest;
        }

        private void InstantiateFinish(GameObject finishPrefab, int x, int y, float rotation)
        {
            Vector3 position = new Vector3(x - (widthMaze - 1) / 2f, y - (heightMaze - 1) / 2f, 0);
            Quaternion quaternion = Quaternion.Euler(0, 0, rotation);

            GameObject finishObject = Object.Instantiate(finishPrefab, position, quaternion);
        }
    }
   
}