using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject GamoverUI;
    [SerializeField] private TextMeshProUGUI tm;
    // Start is called before the first frame update
    void Start()
    {
        KitchenGameManager.Instance.OnStateChanged += Instance_OnStateChanged;
        Hide();

    }

    private void Instance_OnStateChanged(object sender, System.EventArgs e)
    {
        if (KitchenGameManager.Instance.IsGameOver())
        {
            Show();
            tm.text = DeliveryManager.Instance.GetRecipesCompleted().ToString();

        }
        else
        {
            Hide();
        }
    }

    // Update is called once per frame
    void Update()
    {
        tm.text = DeliveryManager.Instance.GetRecipesCompleted().ToString();
    }

    private void Show()
    {
        GamoverUI.SetActive(true);
        tm.gameObject.SetActive(true);
    }

    private void Hide()
    {
        GamoverUI.SetActive(false);
        tm.gameObject.SetActive(false);
    }
}
