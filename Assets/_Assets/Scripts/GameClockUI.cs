using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameClockUI : MonoBehaviour
{
    [SerializeField] Image image;
    // Update is called once per frame
    void Update()
    {
        image.fillAmount = KitchenGameManager.Instance.GetGamePlayingTimer();
    }
}
