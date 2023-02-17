using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneControler : MonoBehaviour
{

    private int LastSceneIndex;

    private void Awake()
    {
        var sceneCount = SceneManager.sceneCount;
        LastSceneIndex = sceneCount - 1;
    }

    public void LoadNextScene()
    {
        if (SceneManager.GetActiveScene().buildIndex== LastSceneIndex) 
        { 
            SceneManager.LoadScene(0);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
