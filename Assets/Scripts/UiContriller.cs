using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiContriller : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] Canvas gameover;
    private void Start()
    {
        Time.timeScale = 0;
        gameover.enabled = false;
    }

    public void StartGame()
    {
        canvas.enabled = false;
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ReturnToMenu()
    {
        canvas.enabled = true;
        gameover.enabled = false;
        Time.timeScale = 0;
    }

    public void GameOver()
    {
        gameover.enabled = true;
        Time.timeScale = 0;
    }

    public void Restart()
    { 
        gameover.enabled = false;
        SceneManager.LoadScene(0);
        StartGame();
    }
}
