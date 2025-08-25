using UnityEngine.SceneManagement;

namespace GameSystem
{
    public class SceneController
    {
        public void ReloadGameScene()
        {
            SceneManager.LoadScene(0);
        }
    }
}