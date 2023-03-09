using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateIconUI : MonoBehaviour
{
    [SerializeField] private PlateKitchenObject plateKitchenObject;
    [SerializeField] private Transform IconTemplate;
    private void Awake()
    {
        IconTemplate.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        plateKitchenObject.OnIngerdiantAdded += PlateKitchenObject_OnIngerdiantAdded;

        
    }

    private void PlateKitchenObject_OnIngerdiantAdded(object sender, PlateKitchenObject.OnIngerdiantAddedArgs e)
    {
        UpdateVisual();
    }

    // Update is called once per frame
    void UpdateVisual()
    {
        foreach (Transform item in transform)
        {
            if (item == IconTemplate) continue;
            Destroy(item.gameObject);
        }
        foreach (KitchenObjectsSO item in plateKitchenObject.GetKitchenObjectsSOList())
        {
            Transform g = Instantiate(IconTemplate, transform);
            g.gameObject.SetActive(true);
            g.GetComponent<PlateKitchenUISingleImage>().SetKitchenObjectSO(item);
            
        }
    }
}
