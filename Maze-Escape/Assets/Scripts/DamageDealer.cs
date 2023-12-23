using UnityEngine;

namespace MazeEscape
{
    public class DamageDealer 
    {
        private readonly GameObject player;
        private readonly float intervalDamage;
        private readonly float attackDamage;
        private float timeSinceLastDamage;
        
        public DamageDealer(GameObject player, float attackDamage, float intervalDamage )
        {
            this.player = player;
            this.intervalDamage = intervalDamage;
            this.attackDamage = attackDamage;
            
            timeSinceLastDamage = intervalDamage;
        }

        public void DealDamage()
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