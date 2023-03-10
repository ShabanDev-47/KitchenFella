using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDownUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tm;
    // Start is called before the first frame update
    void Start()
    {
        KitchenGameManager.Instance.OnStateChanged += Instance_OnStateChanged;
        Hide();

    }

    private void Instance_OnStateChanged(object sender, System.EventArgs e)
    {
        if (KitchenGameManager.Instance.IsCountDownActive())
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    // Update is called once per frame
    void Update()
    {
        tm.text = Mathf.Ceil(KitchenGameManager.Instance.GetCountDownTimer()).ToString();
    }

    private void Show()
    {
        tm.gameObject.SetActive(true);
    }

    private void Hide()
    {
        tm.gameObject.SetActive(false);
    }
}
