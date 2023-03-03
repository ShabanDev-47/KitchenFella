using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    [SerializeField] private KitchenObjectsSO kitchenObject;
    public event EventHandler OnPlayerCounter;
    public override void Interact(PlayerMovement player)
    {
        if (!player.HasKitchenObject())
        {
            //player isn't carrying anything..
            GameObject kitchenObj = Instantiate(kitchenObject.prefab);
            kitchenObj.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
            OnPlayerCounter.Invoke(this, EventArgs.Empty);
        }
  

    }

}
