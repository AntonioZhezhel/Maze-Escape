using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MazeEscape
{
    public class Finish : MonoBehaviour
    {
        private DataHolder DataHolder;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                DataHolder = FindObjectOfType<DataHolder>();
                DataHolder.TextToPass = "You won!";
                SceneManager.LoadScene(0);
            }
        }
    }
}