using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CuttingCounter : BaseCounter,IHasProgress
{
    [SerializeField] private CuttingRecipeSO[] kitchenObjectsSOArray;
    public event EventHandler<IHasProgress.OnprogressChangedArg> OnProgressChanged;
    public event EventHandler OnProgressChangedAnimate;
    //public class OnprogressChangedArg : EventArgs
    //{
    //  public float progressNormalised;
    //}

    private int cuttingProgress;
    public override void Interact(PlayerMovement player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                if (HasReciepeWithInput(player.GetKitchenObject().GetObjectSO()))
                {
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                    cuttingProgress = 0;
                    CuttingRecipeSO cuttingSO = GetCuttingRecipeSOWithInput(GetKitchenObject().GetObjectSO());

                    OnProgressChanged?.Invoke(this, new IHasProgress.OnprogressChangedArg { progressNormalised = (float)cuttingProgress / cuttingSO.cuttingProgressMax });
                }
            }
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
                
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    //PlateKitchenObject plateKitchenObject = player.GetKitchenObject() as PlateKitchenObject;
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();
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

    public override void InteractAlter(PlayerMovement player)
    {
        if (HasKitchenObject()&&HasReciepeWithInput(GetKitchenObject().GetObjectSO()))
        {
            cuttingProgress++;
            CuttingRecipeSO cuttingSO = GetCuttingRecipeSOWithInput(GetKitchenObject().GetObjectSO());
            OnProgressChanged?.Invoke(this, new IHasProgress.OnprogressChangedArg { progressNormalised = (float)cuttingProgress / cuttingSO.cuttingProgressMax });
            OnProgressChangedAnimate?.Invoke(this, EventArgs.Empty);

            if (cuttingProgress >= cuttingSO.cuttingProgressMax)
            {
                KitchenObjectsSO outputSO = GetOutputForInput(GetKitchenObject().GetObjectSO());
                // cut the object here
                GetKitchenObject().DestroySelf();
                KitchenObject.SpawnKitchenObject(outputSO, player);
                //GameObject kitchenObj = Instantiate(kitchenObjectsSO.prefab);
                //kitchenObj.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
            }
        }   
    }
    private bool HasReciepeWithInput(KitchenObjectsSO kitchenObjectsSO)
    {
        CuttingRecipeSO cuttingSO = GetCuttingRecipeSOWithInput(kitchenObjectsSO);
        return cuttingSO != null;
        

    }

    private KitchenObjectsSO GetOutputForInput(KitchenObjectsSO inputKitchenObjectSO)
    {
        CuttingRecipeSO cuttingSO = GetCuttingRecipeSOWithInput(inputKitchenObjectSO);
       if(cuttingSO != null)
        {
            return cuttingSO.output;
        }
        else
        {
            return null;
        }
    }

    private CuttingRecipeSO GetCuttingRecipeSOWithInput(KitchenObjectsSO inputKitchenSO)
    {
        foreach (CuttingRecipeSO cuttingRecipeSO in kitchenObjectsSOArray)
        {
            if (cuttingRecipeSO.input == inputKitchenSO)
            {
                return cuttingRecipeSO;
            }
        }
        return null;
    }
}


