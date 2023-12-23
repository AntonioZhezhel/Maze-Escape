using UnityEngine;
using UnityEngine.SceneManagement;

namespace MazeEscape
{
    public class Menu : MonoBehaviour
    {
        public void OnPlayButton()
        {
            SceneManager.LoadScene(1);
        }
    }
}