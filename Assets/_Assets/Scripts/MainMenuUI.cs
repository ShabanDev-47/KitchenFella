using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] Button playButotn;
    [SerializeField] Button quitButton;

    private void Awake()
    {
        playButotn.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.GameScene);
        });

        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });

        Time.timeScale = 1f;
    }

}
