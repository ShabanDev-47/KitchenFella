using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dumbTest : MonoBehaviour
{
    [SerializeField] Transform container;
    [SerializeField] Transform recipeTemplat;

    private void OnEnable()
    {
       // UpdateVisual();
        recipeTemplat.gameObject.SetActive(false);
        DeliveryManager.OnReciepeSpawned += OnReciepeSpawnedd;
        DeliveryManager.OnReciepeSpawned += OnReciepeCompleted;

        //DeliveryManager.Instance.OnReciepeCompleted += Instance_OnReciepeCompleted;
    }

    private void OnReciepeSpawnedd(object sender, EventArgs e)
    {
        UpdateVisual();
    }
    private void OnReciepeCompleted (object sender, EventArgs e)
    {
        UpdateVisual();
    }

    // Update is called once per frame
    void Update()
    {

        //UpdateVisual();
    }

    private void UpdateVisual()
    {
        foreach (Transform child in container)
        {
            if (child == recipeTemplat) continue;
            Destroy(child.gameObject);
        }

        foreach (RecipeSO recipe in DeliveryManager.Instance.GetWaitingRecipeSOs())
        {
           // Debug.Log("Bkjsad");
            Transform t = Instantiate(recipeTemplat, container);
            t.gameObject.SetActive(true);
            t.GetComponent<DeliveryManagerSingleUi>().SetReciepeSO(recipe);

        }
    }
}
