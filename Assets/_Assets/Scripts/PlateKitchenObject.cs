using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    public event EventHandler<OnIngerdiantAddedArgs> OnIngerdiantAdded;
    public class OnIngerdiantAddedArgs : EventArgs
    {
        public KitchenObjectsSO kitchenObjectsSO;
    }
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
            OnIngerdiantAdded?.Invoke(this, new OnIngerdiantAddedArgs { kitchenObjectsSO = kitchenObjectsSO });
            return true;
        }
       
    }
}
