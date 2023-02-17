using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class CanvasControler : MonoBehaviour
{
    public bool IsPlayin { get; set; }
    [SerializeField] GameObject GameCanvas;
    [SerializeField] GameObject LossCanvas;
    [SerializeField] GameObject WinCanvas;
    [SerializeField] TextMeshProUGUI LevelCount;
    [SerializeField] TextMeshProUGUI ComplitedLevel;
    [SerializeField] SceneControler sceneControler;

    private void Awake()
    {
        LevelCount.text = $"Level : {SceneManager.GetActiveScene().buildIndex + 1}";
        ComplitedLevel.text = $"Level : {SceneManager.GetActiveScene().buildIndex + 1} Complited!";
    }


    public void LoseGame()
    {
        Progress.SnakeLance = -1;
        IsPlayin = false;
        LossCanvas.SetActive(true);
    }

    public void WinGame()
    {
        IsPlayin = false;
        WinCanvas.SetActive(true);
    }

    public void StartGame()
    {
        IsPlayin = true;
        GameCanvas.SetActive(false);
    }

    public void RestartLevel()
    {
        Progress.SnakeLance = -1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        sceneControler.LoadNextScene();
    }
}


