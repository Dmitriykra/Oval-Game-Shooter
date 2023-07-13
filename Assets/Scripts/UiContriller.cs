using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiContriller : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    private void Start()
    {
        Time.timeScale = 0;
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
        Time.timeScale = 0;
    }
}
