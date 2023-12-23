using UnityEngine;

namespace MazeEscape
{
    public interface IEnemySpawner
    {
        void SpawnEnemies(MazeGeneratorWalls[,] maze, GameObject player, int numberOfEnemies,
            float minDistanceBetweenEnemies, float minDistanceToPlayer);
    }
}