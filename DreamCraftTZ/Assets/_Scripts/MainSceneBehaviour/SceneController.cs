using UnityEngine.SceneManagement;

namespace _Scripts.MainSceneBehaviour
{
    public class SceneController
    {
        public void ReloadGameScene()
        {
            SceneManager.LoadScene(0);
        }
    }
}