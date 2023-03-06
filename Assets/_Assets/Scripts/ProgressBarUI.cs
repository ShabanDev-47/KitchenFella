using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private GameObject hasProgressGameobject;
    [SerializeField] private Image barImage;

    private IHasProgress hasProgress;
    private void Start()
    {
        hasProgress = hasProgressGameobject.GetComponent<IHasProgress>();

        if(hasProgress == null)
        {
            Debug.LogError("hasprogress interface Error");
        }
        hasProgress.OnProgressChanged += HasProgress_OnProgressChanged;
        barImage.fillAmount = 0f;
        Hide();
    }

    private void HasProgress_OnProgressChanged(object sender, IHasProgress.OnprogressChangedArg e)
    {
        barImage.fillAmount = e.progressNormalised;

        if(e.progressNormalised ==0f  || e.progressNormalised == 1f)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
}
