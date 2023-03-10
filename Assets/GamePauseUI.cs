using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GamePauseUI : MonoBehaviour
{
    [SerializeField] Button resume;
    [SerializeField] Button mainMenu;
    [SerializeField] GameObject PauseMenu;


    private void Awake()
    {
        resume.onClick.AddListener(() => { 
            KitchenGameManager.Instance.PauseGame();      
        });

        mainMenu.onClick.AddListener(() =>
        {

            Loader.Load(Loader.Scene.MainMenuScene);
        });
    }

    void Start()
    {
        KitchenGameManager.Instance.OnGamePaused += Instance_OnGamePaused;
        KitchenGameManager.Instance.OnGameUnPaused += Instance_OnGameUnPaused;
        Hide();
        
    }

    private void Instance_OnGameUnPaused(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void Instance_OnGamePaused(object sender, System.EventArgs e)
    {
        Show();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Show()
    {
        PauseMenu.SetActive(true);
    }

    private void Hide()
    {
        PauseMenu.SetActive(false);
    }
}
