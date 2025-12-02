using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneScript : MonoBehaviour
{
    public int sceneIndex;

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
