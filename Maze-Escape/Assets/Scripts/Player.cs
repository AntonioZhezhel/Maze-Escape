using MazeEscape;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MazeEscape
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float maxHealth;
        [SerializeField] private TextMeshProUGUI healthText;

        private float currentHealth;
        private DataHolder DataHolder;

        void Start()
        {
            currentHealth = maxHealth;
            healthText.SetText($"{currentHealth}" + "/" + $"{maxHealth}");
            MazeGenerator mazeGenerator = new MazeGenerator();

            transform.position = new Vector3(-(mazeGenerator.widthMaze - 1) / 2f,
                -(mazeGenerator.heightMaze - 1) / 2f);
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;

            healthText.SetText($"{currentHealth}" + "/" + $"{maxHealth}");
            if (currentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            DataHolder = FindObjectOfType<DataHolder>();
            DataHolder.TextToPass = "Game Over";
            SceneManager.LoadScene(0);
        }

        void Update()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(x, y, 0);
            movement = Vector3.ClampMagnitude(movement, 1);
            transform.Translate(movement * speed * Time.deltaTime);
        }
    }
}