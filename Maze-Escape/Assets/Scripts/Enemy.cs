using UnityEngine;
using UnityEngine.AI;

namespace MazeEscape
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float visionRadius;
        [SerializeField] private float attackRadius;
        [SerializeField] private float attackDamage;
        [SerializeField] private float intervalDamage;
        [SerializeField] private NavMeshAgent navMeshAgent;

        private GameObject player;
        private VisionDetector visionDetector;

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");

            transform.rotation = Quaternion.Euler(0, 0, 0);
            navMeshAgent.updateRotation = false;
            navMeshAgent.updateUpAxis = false;
            
            visionDetector = new VisionDetector(
                transform, player, visionRadius, attackRadius, attackDamage, intervalDamage);
        }

        private void Update()
        {
            if (visionDetector.IsPlayerVisible())
            {
                MoveTowardsPlayer();
            }
        }

        private void MoveTowardsPlayer()
        {
            navMeshAgent.SetDestination(player.transform.position);
        }
    }
}