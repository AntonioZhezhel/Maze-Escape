using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MazeEscape
{
    public class EnemySpawner : MonoBehaviour, IEnemySpawner
    {
        private readonly GameObject enemyPrefab;

        public EnemySpawner(GameObject enemyPrefab)
        {
            this.enemyPrefab = enemyPrefab;
        }

        public void SpawnEnemies(MazeGeneratorWalls[,] maze, GameObject player, int numberOfEnemies,
            float minDistanceBetweenEnemies, float minDistanceToPlayer)
        {
            List<Vector2> createdPositions = new List<Vector2>();

            int enemiesCreated = 0;

            while (enemiesCreated < numberOfEnemies)
            {
                int x = Random.Range(0, maze.GetLength(0));
                int y = Random.Range(0, maze.GetLength(1));

                if (!maze[x, y].WallLeft && !maze[x, y].WallBottom &&
                    IsDistanceEnough(new Vector2(x, y), createdPositions, minDistanceBetweenEnemies) &&
                    Vector2.Distance(new Vector2(x, y), player.transform.position) > minDistanceToPlayer)
                {
                    InstantiateEnemy(x, y);
                    createdPositions.Add(new Vector2(x, y));
                    enemiesCreated++;
                }
            }
        }

        private bool IsDistanceEnough(Vector2 currentPosition, List<Vector2> createdPositions, float minDistance)
        {
            return createdPositions.All(position => !(Vector2.Distance(currentPosition, position) < minDistance));
        }

        private void InstantiateEnemy(int x, int y)
        {
            MazeGenerator mazeGenerator = new MazeGenerator();
            Instantiate(enemyPrefab, new Vector3(x - (mazeGenerator.widthMaze - 1) / 2f,
                y - (mazeGenerator.heightMaze - 1) / 2f, 0), Quaternion.identity);
        }
    }
    
}