using UnityEngine;

namespace MazeEscape
{
    public interface IWallCreator
    {
        void CreateWalls(MazeGeneratorWalls[,] maze, GameObject wallPrefab);
    }
}