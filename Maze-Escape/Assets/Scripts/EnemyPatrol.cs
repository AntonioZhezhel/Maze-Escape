using UnityEngine;
using UnityEngine.AI;

namespace MazeEscape
{
    public class EnemyPatrol : MonoBehaviour
    {
        [SerializeField] private int numberOfPatrolPoints;
        [SerializeField] private float patrolPointDistance;
        [SerializeField] private NavMeshAgent navMeshAgent;

        private Transform[] patrolPoints;
        private int currentPatrolIndex;

        private void Start()
        {
            patrolPoints = new Transform[numberOfPatrolPoints];
            PatrolPointCreator.CreatePatrolPoints(
                transform, numberOfPatrolPoints, patrolPointDistance, ref patrolPoints);

            if (patrolPoints.Length > 0)
            {
                PatrolToNextPoint();
            }
        }

        private void Update()
        {
            if (NavMeshAgentOnNavMesh() && !navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
            {
                PatrolToNextPoint();
            }
        }
        
        private bool NavMeshAgentOnNavMesh()
        {
            return navMeshAgent.isOnNavMesh;
        }

        private void PatrolToNextPoint()
        {
            if (patrolPoints.Length == 0)
            {
                return;
            }

            navMeshAgent.destination = patrolPoints[currentPatrolIndex].position;

            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }

        // private void CreatePatrolPoints()
        // {
        //     patrolPoints[0] = new GameObject("PatrolPoint0").transform;
        //     patrolPoints[0].position = transform.position;
        //     Vector3 randomPointInsideMaze = GetRandomPointInsideMaze();
        //
        //     Vector3 patrolPointPosition = transform.position +
        //                                   (randomPointInsideMaze - transform.position).normalized * patrolPointDistance;
        //
        //     for (int i = 1; i < numberOfPatrolPoints; i++)
        //     {
        //         GameObject patrolPoint = new GameObject("PatrolPoint" + i);
        //         patrolPoint.transform.position = patrolPointPosition;
        //
        //         patrolPoints[i] = patrolPoint.transform;
        //     }
        // }
        //
        // private Vector3 GetRandomPointInsideMaze()
        // {
        //     MazeGenerator mazeGenerator = new MazeGenerator();
        //
        //     float x = Random.Range(1, (mazeGenerator.widthMaze - 1));
        //     float y = Random.Range(1, (mazeGenerator.heightMaze - 1));
        //
        //     Vector3 randomPoint = new Vector3(x - (mazeGenerator.widthMaze - 1) / 2f,
        //         y - (mazeGenerator.heightMaze - 1) / 2f);
        //
        //     return randomPoint;
        // }
    }
}