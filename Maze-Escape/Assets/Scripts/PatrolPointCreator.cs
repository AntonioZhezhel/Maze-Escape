using UnityEngine;

namespace MazeEscape
{
    public abstract class PatrolPointCreator
    {
        public static void CreatePatrolPoints(Transform parent, int numberOfPoints, float distance, ref Transform[] points)
        {
            points[0] = new GameObject("PatrolPoint0").transform;
            points[0].position = parent.position;

            Vector3 randomPointInsideMaze = GetRandomPointInsideMaze();
            Vector3 patrolPointPosition = parent.position + (randomPointInsideMaze - parent.position).normalized * distance;

            for (int i = 1; i < numberOfPoints; i++)
            {
                GameObject patrolPoint = new GameObject($"PatrolPoint{i}");
                patrolPoint.transform.position = patrolPointPosition;

                points[i] = patrolPoint.transform;
            }
        }

        private static Vector3 GetRandomPointInsideMaze()
        {
            MazeGenerator mazeGenerator = new MazeGenerator();

            float x = Random.Range(1, (mazeGenerator.widthMaze - 1));
            float y = Random.Range(1, (mazeGenerator.heightMaze - 1));

            return new Vector3(x - (mazeGenerator.widthMaze - 1) / 2f, y - (mazeGenerator.heightMaze - 1) / 2f);
        }
    }
}