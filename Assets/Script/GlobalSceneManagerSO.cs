using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "GlobalSceneManagerSO", menuName = "Managers/GlobalSceneManagerSO")]
public class GlobalSceneManagerSO : ScriptableObject
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void UnloadScene(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);
    }

    public void RemoveScene(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);
        Resources.UnloadUnusedAssets();
    }
}

