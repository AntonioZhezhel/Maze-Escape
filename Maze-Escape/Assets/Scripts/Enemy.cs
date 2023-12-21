using System;
using UnityEngine;
using UnityEngine.AI;

namespace MazeEscape
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float visionRadius;
        [SerializeField] private NavMeshAgent navMeshAgent;
        private Transform player;
        
        private int playerTag;
        private int wallLayer;

        private void Start()
        {
            navMeshAgent.updateRotation = false;
            navMeshAgent.updateUpAxis = false;
            player = GameObject.FindGameObjectWithTag("Player").transform;
            navMeshAgent = GetComponent<NavMeshAgent>();
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
            navMeshAgent.SetDestination(player.position);
        }
        
        private bool IsPlayerInVisionRadius()
        {
            if (player == null)
            {
                return false;
            }
            
            Vector2 direction = player.position - transform.position;
            
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, visionRadius, 
                 LayerMask.GetMask("Wall", "Player"));
            
             return hit.collider != null && hit.collider.gameObject.CompareTag("Player");
        }
    }
}