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

    private EventService eventService;
    private void Start()
    {
        restartButton.onClick.AddListener(OnRestartClick);
    }

    public void Init(EventService eventService)
    {
        this.eventService = eventService;
    }
    private void OnRestartClick() 
    {
        SceneManager.LoadScene(0);
    }

    public void SetGameText(string textToSet)
    {
        textGameText.text = textToSet;
    }
}
