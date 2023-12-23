using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace MazeEscape
{
    public class EnemyPatrol : MonoBehaviour
    {
        [SerializeField] private int numberOfPatrolPoints;
        [SerializeField] private float patrolPointDistance;
        [SerializeField] private NavMeshAgent navMeshAgent;

        private Transform[] patrolPoints;
        private int currentPatrolIndex = 0;

        private void Start()
        {
            patrolPoints = new Transform[numberOfPatrolPoints];

            CreatePatrolPoints();
            PatrolToNextPoint();
        }

        private void Update()
        {
            if (!navMeshAgent.isOnNavMesh)
            {
                return;
            }

            if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
            {
                PatrolToNextPoint();
            }
        }

        private void PatrolToNextPoint()
        {
            if (patrolPoints.Length == 0)
            {
                Debug.LogWarning("No patrol points assigned!");
                return;
            }

            navMeshAgent.destination = patrolPoints[currentPatrolIndex].position;

            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }

        private void CreatePatrolPoints()
        {
            patrolPoints[0] = new GameObject("PatrolPoint0").transform;
            patrolPoints[0].position = transform.position;
            Vector3 randomPointInsideMaze = GetRandomPointInsideMaze();

            Vector3 patrolPointPosition = transform.position +
                                          (randomPointInsideMaze - transform.position).normalized * patrolPointDistance;

            for (int i = 1; i < numberOfPatrolPoints; i++)
            {
                GameObject patrolPoint = new GameObject("PatrolPoint" + i);
                patrolPoint.transform.position = patrolPointPosition;

                patrolPoints[i] = patrolPoint.transform;
            }
        }

        private Vector3 GetRandomPointInsideMaze()
        {
            MazeGenerator mazeGenerator = new MazeGenerator();

            float x = Random.Range(1, (mazeGenerator.widthMaze - 1));
            float y = Random.Range(1, (mazeGenerator.heightMaze - 1));

            Vector3 randomPoint = new Vector3(x - (mazeGenerator.widthMaze - 1) / 2f,
                y - (mazeGenerator.heightMaze - 1) / 2f);

            return randomPoint;
        }
    }
}