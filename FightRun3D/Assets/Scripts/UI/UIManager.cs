using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public Slider animatorTime;
    public GameObject mainMenuPanel, inGamePanel, endGamePanel, gameOverPanel;
    public GameObject currentPanel;
    public Text inGamePointText,endGamePointText;

    private void Awake()
    {
        currentPanel = mainMenuPanel;
    }

    #region Buttons
    public void StartGame()
    {
        PanelChange(currentPanel,inGamePanel);
        EventManager.Instance.CheckEvents(StateManager.Instance.state = State.InGame);
        UpdateScore();
    }

    public void RestartGame()
    {
        LevelManager.Instance.ChangeLevel("LEVEL " + LevelManager.Instance.CurrentLevel);
    }

    public void NextLevelButton()
    {
        LevelManager.Instance.ChangeLevel("LEVEL " + LevelManager.Instance.CurrentLevel);
    }
    #endregion

    #region Panel Change
    public void EndGame()
    {
        PanelChange(currentPanel,endGamePanel);
    }
    public void GameOver()
    {
        PanelChange(currentPanel,gameOverPanel);
    }
    public void InGame()
    {
        PanelChange(currentPanel,inGamePanel);
    }
    public void PanelChange(GameObject closePanel,GameObject openPanel)
    {
        closePanel.SetActive(false);
        openPanel.SetActive(true);
        currentPanel = openPanel;
    }
    #endregion

    #region Score
    public void UpdateScore()
    {
        if (StateManager.Instance.state == State.EndGame)
        {
            endGamePointText.text = GameManager.Instance.Score.ToString();
        }
        else
        {
            inGamePointText.text = GameManager.Instance.Score.ToString();
        }
        
    }

    #endregion

}
