using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class DeliveryManagerSingleUi : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI recipeText;
    [SerializeField] private Transform IconContainer;
    [SerializeField] private Transform IconTemplate;
    // Start is called before the first frame update
    void Awake()
    {
        IconTemplate.gameObject.SetActive(false);

    }
    public void SetReciepeSO(RecipeSO recipeSO)
    {
        recipeText.text = recipeSO.recipeName;

        foreach(Transform child in IconContainer)
        {
            if (child == IconTemplate) continue;
            Destroy(child.gameObject);
        }

        foreach(KitchenObjectsSO kitchenObjectsSO in recipeSO.kitchenObjectsSOs)
        {
            Transform icon = Instantiate(IconTemplate, IconContainer);
            icon.gameObject.SetActive(true);
            icon.GetComponent<Image>().sprite = kitchenObjectsSO.sprite;
        }
    }

  
}
