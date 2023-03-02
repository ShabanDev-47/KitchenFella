using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
   public KitchenObjectsSO m_Object;
   public KitchenObjectsSO GetObjectSO()
   {
        return m_Object;
   }

    private IKitchenObjectParent kitchenObjectParent;
    public void SetKitchenObjectParent (IKitchenObjectParent kitchentObjectParent)
    {
        if (this.kitchenObjectParent != null)
        {
            this.kitchenObjectParent.ClearKitchenObject();
        }
            this.kitchenObjectParent = kitchentObjectParent;
        if (kitchentObjectParent.HasKitchenObject())
        {
            Debug.LogError("Counter Already has a KitchenObject");
        }
            kitchentObjectParent.SetKitchenObject(this);

            transform.parent = kitchentObjectParent.GetKitchenObjectFollowTransform();
            transform.localPosition = Vector3.zero;
        
    }

    public IKitchenObjectParent GetKitchenObjectParent()
    {
        return kitchenObjectParent;
    }

}
