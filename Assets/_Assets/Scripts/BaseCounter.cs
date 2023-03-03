using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour,IKitchenObjectParent
{
    [SerializeField] private Transform topCounterPoint;
    //[SerializeField] private ClearCounter secondClearCounter;
    private KitchenObject kitchenObjectt;
    public virtual void Interact(PlayerMovement player)
    {
        Debug.LogError("This isn't meant to be called from base class");
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
