using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManagerUI : MonoBehaviour
{
    [SerializeField] Transform container;
    [SerializeField] Transform recipeTemplat;
   
    // Start is called before the first frame update
    private void Awake()
    {

         recipeTemplat.gameObject.SetActive(false);
    }
    void Start()
    {
        UpdateVisual();

      //  DeliveryManager.OnReciepeSpawned += Instance_OnReciepeSpawned;
        //DeliveryManager.OnReciepeCompleted += Instance_OnReciepeCompleted;


    }

    private void Instance_OnReciepeSpawned(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void Instance_OnReciepeCompleted(object sender, System.EventArgs e)
    {
       UpdateVisual();
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
            Transform t = Instantiate(recipeTemplat, container);
            t.gameObject.SetActive(true);
            t.GetComponent<DeliveryManagerSingleUi>().SetReciepeSO(recipe);
        }
    }


}
