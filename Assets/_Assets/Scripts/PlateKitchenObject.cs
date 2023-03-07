using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    private List<KitchenObjectsSO> kitchenObjects = new List<KitchenObjectsSO>(); 
   [SerializeField] private List <KitchenObjectsSO> ValidSO = new List<KitchenObjectsSO>();
   public bool TryAddIngredient(KitchenObjectsSO kitchenObjectsSO)
    {
        if(!ValidSO.Contains(kitchenObjectsSO))
        {
            return false;
        }
        if (kitchenObjects.Contains(kitchenObjectsSO))
        {
            return false;
        }
        else
        {
            kitchenObjects.Add(kitchenObjectsSO);
            return true;
        }
       
    }
}
