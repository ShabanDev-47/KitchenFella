using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] ClearCounter clearCounter;
    [SerializeField] GameObject counterVisual;
    private void Start()
    {
        PlayerMovement.Instance.OnSelectedCounterChanged += PlayerSelectedCounter;
    }

    private void PlayerSelectedCounter(object sender, PlayerMovement.OnSelectedCounterChangedArgs e)
    {
        if(e.selectedCounter == clearCounter)
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
        counterVisual.SetActive(true);
    }
    void Hide()
    {
        counterVisual.SetActive(false);
    }
}
