using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MazeEscape
{
    public class EnemySpawn : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private GameObject Player;
        [SerializeField] private int numberOfEnemies;
        [SerializeField] private float minDistanceBetweenEnemies;
        [SerializeField] private float minDistanceToPlayer;

        private void Start()
        {
            MazeGenerator mazeGenerator = new MazeGenerator();
            MazeGeneratorWalls[,] maze = mazeGenerator.GenerateMaze();

            List<Vector2> createdPositions = new List<Vector2>();

            int enemiesCreated = 0;

            while (enemiesCreated < numberOfEnemies)
            {
                int x = Random.Range(0, maze.GetLength(0));
                int y = Random.Range(0, maze.GetLength(1));

                if (!maze[x, y].WallLeft && !maze[x, y].WallBottom &&
                    IsDistanceEnough(new Vector2(x, y), createdPositions, minDistanceBetweenEnemies) &&
                    Vector2.Distance(new Vector2(x, y), Player.transform.position) > minDistanceToPlayer)
                {
                    Instantiate(enemyPrefab, new Vector3(x - (mazeGenerator.widthMaze - 1) / 2f,
                        y - (mazeGenerator.heightMaze - 1) / 2f, 0), Quaternion.identity);

                    createdPositions.Add(new Vector2(x, y));
                    enemiesCreated++;
                }
            }
        }

        private bool IsDistanceEnough(Vector2 currentPosition, List<Vector2> createdPositions, float minDistance)
        {
            return createdPositions.All(position => !(Vector2.Distance(currentPosition, position) < minDistance));
        }
    }
}