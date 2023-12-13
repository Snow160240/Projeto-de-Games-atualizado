using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
   [SerializeField] Button playButton;
   [SerializeField] Button creditsButton;
   [SerializeField] Button exitButton;
   [SerializeField] GameObject creditsPanel;

    private void Awake()
    {
        creditsPanel.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Credits()
    {
        creditsPanel.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void CloseCreditis()
    {
        creditsPanel.SetActive(false);
    }
}
