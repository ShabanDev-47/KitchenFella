using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour
{
    [SerializeField] private PlateKitchenObject plateKitchenObject;
    [SerializeField] private List<KitchenObjectSO_GameObjects> kitchenObjectSO_GameObjectsList = new();

    [Serializable]
    public struct KitchenObjectSO_GameObjects
    {
        public KitchenObjectsSO kitchenObjectsSO;
        public GameObject gameObject;
    }
    
    private void Start()
    {
        plateKitchenObject.OnIngerdiantAdded += PlateKitchenObject_OnIngerdiantAdded;
        foreach (KitchenObjectSO_GameObjects item in kitchenObjectSO_GameObjectsList)
        {
                item.gameObject.SetActive(false);
            
        }
    }

    private void PlateKitchenObject_OnIngerdiantAdded(object sender, PlateKitchenObject.OnIngerdiantAddedArgs e)
    {
        foreach (KitchenObjectSO_GameObjects item in kitchenObjectSO_GameObjectsList)
        {
            if(e.kitchenObjectsSO == item.kitchenObjectsSO)
            {
                item.gameObject.SetActive(true);
            }
        }
    }
}
