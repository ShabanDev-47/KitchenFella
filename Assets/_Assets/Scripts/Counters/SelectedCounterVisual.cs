using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] BaseCounter baseCounter;
    [SerializeField] List <GameObject> counterVisuals = new();
    private void Start()
    {
        PlayerMovement.Instance.OnSelectedCounterChanged += PlayerSelectedCounter;
    }

    private void PlayerSelectedCounter(object sender, PlayerMovement.OnSelectedCounterChangedArgs e)
    {
        if(e.selectedCounter == baseCounter)
        {
            Show();
        }
        else
        {
            Hide();
        }

    }

    void Show()
    {
        foreach (GameObject visual in counterVisuals)
        {
            visual.SetActive(true);
        }
        
    }
    void Hide()
    {
        foreach (GameObject visual in counterVisuals)
        {
            visual.SetActive(false);
        }
    }
}
