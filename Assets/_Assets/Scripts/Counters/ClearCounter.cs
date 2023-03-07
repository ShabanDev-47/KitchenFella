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
                //PLayer is holding A plate? 
                if(player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    //PlateKitchenObject plateKitchenObject = player.GetKitchenObject() as PlateKitchenObject;
                   if(plateKitchenObject.TryAddIngredient(GetKitchenObject().GetObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();
                    }
                } else { 
                
                    if (GetKitchenObject().TryGetPlate(out plateKitchenObject))
                    {
                        //PlateKitchenObject plateKitchenObject = player.GetKitchenObject() as PlateKitchenObject;
                        if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetObjectSO()))
                        {
                            player.GetKitchenObject().DestroySelf();
                        }

                    }
                }

            }
            else
            {
                // Give the object back to the player.
                GetKitchenObject().SetKitchenObjectParent(player);
            }  
            
        }
    }

}
