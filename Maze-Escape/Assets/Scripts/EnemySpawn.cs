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

        private IEnemySpawner enemySpawner;

        private void Start()
        {
            MazeGenerator mazeGenerator = new MazeGenerator();
            MazeGeneratorWalls[,] maze = mazeGenerator.GenerateMaze();

            enemySpawner = new EnemySpawner(enemyPrefab);
            enemySpawner.SpawnEnemies(maze, Player, numberOfEnemies, minDistanceBetweenEnemies, minDistanceToPlayer);
        }
    }
}