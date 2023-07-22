using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuCanvas : MonoBehaviour
{
    [SerializeField] bool hasLevelSelect;


    [SerializeField] GameObject changeLogButton;



    [SerializeField] TextMeshProUGUI titleText;
    [SerializeField] GameObject[] allUI;
    [SerializeField] GameObject[] startUI;
    [SerializeField] GameObject[] levelSelectUI;
    [SerializeField] GameObject backButton;
    [SerializeField] GameObject[] settingsUI;
    [SerializeField] GameObject[] credits;
    [SerializeField] GameObject[] highscores;
    [SerializeField] GameObject[] changeLog;


  
    private void Start()
    {
        DisableUI();
        TurnOnStartMenu();
        
    }
    public void TurnOnChangeLog()
    {
        DisableUI();
        foreach (var item in changeLog)
        {
            item.SetActive(true);
        }
        titleText.text = "Changelog";
    }
    public void TurnOnHighScores()
    {
        DisableUI();
        foreach (var item in highscores)
        {
            item.SetActive(true);
        }
        titleText.text = "High Scores";
    }
    public void TurnOnCreditsMenu()
    {
        DisableUI();
        foreach (var item in credits)
        {
            item.SetActive(true);
        }
        titleText.text = "Credits";
    }
    public void TurnOnSettingsMenu()
    {
        DisableUI();
        foreach (var item in settingsUI)
        {
            item.SetActive(true);
        }
        titleText.text = "Settings";
    }
    void TurnOnStartMenu()
    {
        DisableUI();
        foreach (var item in startUI)
        {
            item.SetActive(true);
        }
        changeLogButton.SetActive(true);
        backButton.SetActive(false);
        titleText.text = "Main Menu";
    }

    void DisableUI()
    {
        foreach (var item in allUI)
        {
            item.SetActive(false);
        }
        changeLogButton.SetActive(false);
        backButton.SetActive(true);
    }

  public  void PlayButton()
    {
        DisableUI();

        if (!hasLevelSelect)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            OpenLevelSelect();
            titleText.text = "Level Select";
        }
    }


   void OpenLevelSelect()
    {
       
        foreach (var item in levelSelectUI)
        {
            item.SetActive(true);
        }
    }

    public void BackButton()
    {
        DisableUI();
        TurnOnStartMenu();
    }
    public void LoadLevel(int i)
    {
        SceneManager.LoadScene(i);  
    }
}
