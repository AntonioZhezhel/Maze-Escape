using UnityEngine;

namespace MazeEscape
{
    public interface IFinishCreator
    {
        void CreateFinish(MazeGeneratorWalls finishCell, GameObject finishPrefab);
    }
}