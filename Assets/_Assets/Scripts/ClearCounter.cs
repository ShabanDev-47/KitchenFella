using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour,IKitchenObjectParent
{
    [SerializeField] private KitchenObjectsSO kitchenObject;
    [SerializeField] private Transform topCounterPoint;
    [SerializeField] private ClearCounter secondClearCounter;
    private KitchenObject kitchenObjectt;
 
    public void Interact(PlayerMovement player)
    {
        if (kitchenObjectt == null)
        {
            GameObject kitchenObj = Instantiate(kitchenObject.prefab, topCounterPoint);
            kitchenObj.GetComponent<KitchenObject>().SetKitchenObjectParent(this);   

        }else
        {
            //attach the kitchen object (cheese or something) to the player 
            kitchenObjectt.SetKitchenObjectParent(player);
        }
        
    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return topCounterPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObjectt = kitchenObject;
    }
    public KitchenObject GetKitchenObject()
    {
        return this.kitchenObjectt;
    }

    public void ClearKitchenObject()
    {
        kitchenObjectt = null;
    }

    public bool HasKitchenObject()
    {
        return kitchenObjectt != null;
    }
}
