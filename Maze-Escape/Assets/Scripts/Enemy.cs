using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

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
        private float timeSinceLastDamage;

        private void Start()
        {
            navMeshAgent.updateRotation = false;
            navMeshAgent.updateUpAxis = false;
            player = GameObject.FindGameObjectWithTag("Player");
            timeSinceLastDamage = intervalDamage;
        }

        private void Update()
        {
            if (IsPlayerInVisionRadius())
            {
                MoveTowardsPlayer();
            }
        }

        private void MoveTowardsPlayer()
        {
            navMeshAgent.SetDestination(player.transform.position);
        }

        private bool IsPlayerInVisionRadius()
        {
            if (player == null)
            {
                return false;
            }

            Vector2 direction = player.transform.position - transform.position;
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, visionRadius,
                LayerMask.GetMask("Wall", "Player"));
            
            if (hit.collider != null && hit.collider.gameObject.CompareTag("Player"))
            {
                if (distanceToPlayer <= attackRadius)
                {
                    Damage();
                }
                return true;
            }
            return false;
        }

        private void Damage()
        {
            timeSinceLastDamage += Time.deltaTime;
            if (timeSinceLastDamage >= intervalDamage)
            {
                timeSinceLastDamage = 0f;
                Player playerHealth = player.GetComponent<Player>();
                playerHealth.TakeDamage(attackDamage);
            }
            
        }
    }
}