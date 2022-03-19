
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public TMP_Text levelText;
    public int CurrentLevelIndex { get; set; }

    private void Awake()
    {
        CurrentLevelIndex = PlayerPrefsKeys.CurrentLevel;
    }

    private void Start()
    {
        LoadLastScene();
    }

    public void LoadLastScene()
    {
        if (CurrentLevelIndex != 0)
        {
            if (SceneManager.GetActiveScene().buildIndex!=CurrentLevelIndex)
            {
                SceneManager.LoadScene(CurrentLevelIndex);
            }
        }
        SetCurrentLevelText();
    }

    public void SetCurrentLevelText()
    {
        levelText.SetText("Level "+(CurrentLevelIndex +1));
    }
    public void NextLevel()
    {
        CurrentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        if (CurrentLevelIndex == SceneManager.sceneCountInBuildSettings -1) return;
        CurrentLevelIndex++;
        SceneManager.LoadScene(CurrentLevelIndex);
        PlayerPrefsKeys.CurrentLevel = CurrentLevelIndex;
        UIManager.Instance.FinishPanel.gameObject.SetActive(false);
    }

}
