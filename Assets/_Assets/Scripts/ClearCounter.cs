using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjectsSO kitchenObject;
    [SerializeField] private Transform topCounterPoint;
    public void Interact()
    {
        Debug.Log("Interact");
        GameObject kitchenObj = Instantiate(kitchenObject.prefab, topCounterPoint);
        kitchenObj.transform.localPosition = Vector3.zero;

        Debug.Log(kitchenObj.GetComponent<KitchenObject>().GetObjectSO().objectName);
    }
}
