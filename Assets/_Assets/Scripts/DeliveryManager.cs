using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    public static event EventHandler OnReciepeSpawned;
    public static event EventHandler OnReciepeCompleted;
    public static DeliveryManager Instance { get;  private set; }


    [SerializeField] private RecipeListSO recipeListSOs;
    private List<RecipeSO> watingReciepeList;

    private float spawnTimer;
    private float spawnTimerMax;
    private int waitingReciepeMax;

    private void Awake()
    {
   
    }
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        waitingReciepeMax = 4;
        spawnTimerMax = 4f;
        watingReciepeList = new List<RecipeSO>();


        //RecipeSO r = recipeListSOs.recipes[UnityEngine.Random.Range(0, recipeListSOs.recipes.Count)];
        //Debug.Log(r.recipeName);
        //watingReciepeList.Add(r);

        

    }


    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer > spawnTimerMax)
        {
            spawnTimer = 0;
            if(watingReciepeList.Count < waitingReciepeMax)
            {
                RecipeSO r = recipeListSOs.recipes[UnityEngine.Random.Range(0, recipeListSOs.recipes.Count)];
                Debug.Log(r.recipeName);
                watingReciepeList.Add(r);
                if (watingReciepeList.Count >= 0)
                {
                    OnReciepeSpawned?.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }


    public void DelieverReciepe(PlateKitchenObject plateKitchenObject)
    {
        for(int i = 0; i < watingReciepeList.Count; i++)
        {
            RecipeSO waitingReceipeSO = watingReciepeList[i];

            if(waitingReceipeSO.kitchenObjectsSOs.Count == plateKitchenObject.GetKitchenObjectsSOList().Count)
            {
                // the reciepe has the same number of ingredients as the Plate
                bool plateContentMatches = true;
                // So do this..
                foreach (KitchenObjectsSO recipeKitchenSO in waitingReceipeSO.kitchenObjectsSOs)
                {
                    bool ingredientFound = false;

                    foreach (KitchenObjectsSO plateKitchenObjectSO in plateKitchenObject.GetKitchenObjectsSOList())
                    {
                        if(plateKitchenObject == recipeKitchenSO)
                        {
                          //  Debug.Log("Matcs");
                            ingredientFound = true;
                            
                            break;
                        }
                    }

                    //
                    if (!ingredientFound)
                    {
                        plateContentMatches = true;

                    }
                }

                if (plateContentMatches)
                {
                    Debug.Log("Matches");
                    watingReciepeList.RemoveAt(i);
                    OnReciepeCompleted?.Invoke(this, EventArgs.Empty);
                    Debug.Log(waitingReceipeSO);
                    return;
                }

               
            }
            
        }
        Debug.Log("Not Matches");


    }

    public List<RecipeSO> GetWaitingRecipeSOs()
    {
        return watingReciepeList;
    }




}
