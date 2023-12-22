using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxHealth; 
    private float currentHealth; 
    [SerializeField] private TextMeshProUGUI healthText;
    void Start()
    {
        currentHealth = maxHealth;
        healthText.SetText($"{currentHealth}"+"/"+$"{maxHealth}");
        MazeGenerator mazeGenerator = new MazeGenerator();
            
        transform.position = new Vector3(- (mazeGenerator.widthMaze -1)/2f,
            - (mazeGenerator.heightMaze-1)/2f); 
    }
    
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        healthText.SetText($"{currentHealth}"+"/"+$"{maxHealth}");
        if (currentHealth <= 0)
        {
            
            Die(); 
        }
    }

    private void Die()
    {
        throw new System.NotImplementedException();
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
