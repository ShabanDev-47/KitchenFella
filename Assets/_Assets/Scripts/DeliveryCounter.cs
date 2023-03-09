using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    public override void Interact(PlayerMovement player)
    {
        if (player.HasKitchenObject())
        {
            if(player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
            {
                DeliveryManager.Instance.DelieverReciepe(plateKitchenObject);
                player.GetKitchenObject().DestroySelf();
            }
        }
    }
}
