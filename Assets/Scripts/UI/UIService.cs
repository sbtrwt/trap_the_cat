using System.Collections;
using System.Collections.Generic;
using TMPro;
using TrapTheCat.Events;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIService : MonoBehaviour
{
    [SerializeField] TMP_Text textGameText;
    [SerializeField] Button restartButton;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] Button restartPanelButton;

    private EventService eventService;
    private void Start()
    {
        restartButton.onClick.AddListener(OnRestartClick);
        restartPanelButton.onClick.AddListener(OnRestartClick);
        
    }

    public void Init(EventService eventService)
    {
        this.eventService = eventService;
        eventService.OnGameOver.AddListener(OnGameOver);
    }
    private void OnRestartClick() 
    {
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void SetGameText(string textToSet)
    {
        textGameText.text = textToSet;
    }
    public void OnGameOver(bool isGameOver)
    {
        gameOverPanel.SetActive(isGameOver);
    }
}
