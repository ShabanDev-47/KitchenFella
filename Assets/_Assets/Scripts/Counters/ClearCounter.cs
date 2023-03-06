using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    private KitchenObjectsSO kitchenObject;

 
    public override void Interact(PlayerMovement player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject())
                player.GetKitchenObject().SetKitchenObjectParent(this);
            else
            {
                //Do nothing, player isn't carrying anything
            }

        }
        else
        {
            // if there is something on the counter && the player has an object
            if (player.HasKitchenObject())
            {
                //Do nothing
            }
            else
            {
                // Give the object back to the player.
                GetKitchenObject().SetKitchenObjectParent(player);
            }  
            
        }
    }

}
