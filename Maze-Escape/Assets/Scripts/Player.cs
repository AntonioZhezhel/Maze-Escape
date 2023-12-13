using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    
    void Start()
    {
        MazeGenerator mazeGenerator = new MazeGenerator();
            
        transform.position = new Vector3(- (mazeGenerator.widthMaze -1)/2f,
            - (mazeGenerator.heightMaze-1)/2f); 
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
