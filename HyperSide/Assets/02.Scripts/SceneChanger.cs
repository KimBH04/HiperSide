using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public void Stage(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
