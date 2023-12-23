using UnityEngine;

namespace MazeEscape
{
    public class VisionDetector 
    {
        private readonly float attackRadius;
        private readonly float visionRadius;
        private readonly GameObject player;
        private readonly DamageDealer damageDealer;
        private readonly Transform enemyTransform;
        
        public VisionDetector(Transform enemyTransform, GameObject player, float visionRadius, 
            float attackRadius, float attackDamage, float intervalDamage)
        {
            this.enemyTransform = enemyTransform;
            this.player = player;
            this.visionRadius = visionRadius;
            this.attackRadius = attackRadius;
            
            damageDealer = new DamageDealer(player,attackDamage, intervalDamage );
        }
        
        public bool IsPlayerVisible()
        {
            Vector2 direction = player.transform.position - enemyTransform.position;
            float distanceToPlayer = Vector2.Distance(enemyTransform.position, player.transform.position);
            
            RaycastHit2D hit = Physics2D.Raycast(enemyTransform.position, direction, visionRadius,
                LayerMask.GetMask("Wall", "Player"));
            
            if (hit.collider != null && hit.collider.gameObject.CompareTag("Player"))
            {
                if (distanceToPlayer <= attackRadius)
                {
                     damageDealer.DealDamage();
                }
                return true;
            }
            return false;
        }
    }
}