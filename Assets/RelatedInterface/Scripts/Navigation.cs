using UnityEngine;
using UnityEngine.SceneManagement;

namespace RelatedInterface.Scripts
{
    public class Navigation : MonoBehaviour
    {
        public void Reload()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}
