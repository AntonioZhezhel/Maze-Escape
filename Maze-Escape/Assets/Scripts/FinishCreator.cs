using UnityEngine;

namespace MazeEscape
{
    public class FinishCreator : MonoBehaviour
    {
        public void CreateFinish(MazeGeneratorWalls finishCell, int widthMaze, int heightMaze, GameObject finishPrefab)
        {
            float rotation = 0;
            if (finishCell.x != 0 && finishCell.x != widthMaze - 1)
            {
                rotation = -90;
            }
            Instantiate(finishPrefab, new Vector3(finishCell.x - (widthMaze - 1) / 2f,
                finishCell.y - (heightMaze - 1) / 2f), Quaternion.Euler(0, 0, rotation));
        }
    }
}