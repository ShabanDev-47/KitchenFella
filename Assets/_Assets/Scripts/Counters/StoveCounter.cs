using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounter : BaseCounter,IHasProgress
{
    public event EventHandler<IHasProgress.OnprogressChangedArg> OnProgressChanged;
    public event EventHandler<OnStateChangedArgs> OnStateChanged;
    public class OnStateChangedArgs : EventArgs
    {
        public State state;
    }
    [SerializeField] private List <FryingRecipeSO> fryingRecipes = new();
    [SerializeField] private List<BuringRecipeSO> burningRecipes = new();
    [SerializeField] float fryingTimer;
    [SerializeField] float burningTimer;

    private FryingRecipeSO fryingRecipeSO;
    private BuringRecipeSO buringRecipeSO;

    private State state;

    public enum State
    {
        idle,
        frying,
        fried,
        burned,
    }

    
    private void Start()
    {
        state = State.idle;
        OnStateChanged?.Invoke(this, new OnStateChangedArgs { state = state });
    }

    private void Update()
    {
        if (HasKitchenObject())
        {
            switch (state)
            {
                case State.idle:
                    break;
                case State.frying:
                    OnProgressChanged?.Invoke(this, new IHasProgress.OnprogressChangedArg { progressNormalised = fryingTimer / fryingRecipeSO.fryingTimerMax });
                    fryingTimer += Time.deltaTime;
                    if(fryingTimer > fryingRecipeSO.fryingTimerMax)
                    {
                        
                        
                        GetKitchenObject().DestroySelf();

                        KitchenObject.SpawnKitchenObject(fryingRecipeSO.output, this);
                        
                        Debug.Log("fried");
                        state = State.fried;
                        burningTimer = 0f;
                        buringRecipeSO = GetBurningRecipeSOWithInput(GetKitchenObject().GetObjectSO());
                        OnStateChanged?.Invoke(this, new OnStateChangedArgs { state = state });
                        
                    }
                    break;
                case State.fried:
                    OnProgressChanged?.Invoke(this, new IHasProgress.OnprogressChangedArg { progressNormalised = burningTimer / buringRecipeSO.burningTimerMax });
                    burningTimer += Time.deltaTime;
                    if (burningTimer > buringRecipeSO.burningTimerMax)
                    {


                        GetKitchenObject().DestroySelf();

                        KitchenObject.SpawnKitchenObject(buringRecipeSO.output, this);
                        Debug.Log("burned");
                        state = State.burned;
                        OnStateChanged?.Invoke(this, new OnStateChangedArgs { state = state });
                        OnProgressChanged?.Invoke(this, new IHasProgress.OnprogressChangedArg { progressNormalised = burningTimer / buringRecipeSO.burningTimerMax });
                        OnProgressChanged?.Invoke(this, new IHasProgress.OnprogressChangedArg { progressNormalised =0f });

                    }
                    break;

                case State.burned:
                    break;
            }

        }

        Debug.Log(state);
    }
    public override void Interact(PlayerMovement player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                if (HasReciepeWithInput(player.GetKitchenObject().GetObjectSO()))
                {
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                   // cuttingProgress = 0;
                    fryingRecipeSO = GetFryingRecipeSOWithInput(GetKitchenObject().GetObjectSO());
                    state = State.frying;
                    fryingTimer = 0f;
                    OnStateChanged?.Invoke(this, new OnStateChangedArgs { state = state });
                    OnProgressChanged?.Invoke(this, new IHasProgress.OnprogressChangedArg { progressNormalised = fryingTimer / fryingRecipeSO.fryingTimerMax });


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
                //Do nothing
            }
            else
            {
                // Give the object back to the player.
                GetKitchenObject().SetKitchenObjectParent(player);
                state = State.idle;
                OnStateChanged?.Invoke(this, new OnStateChangedArgs { state = state });
                OnProgressChanged?.Invoke(this, new IHasProgress.OnprogressChangedArg { progressNormalised = 0f });

            }

        }

    }

    private bool HasReciepeWithInput(KitchenObjectsSO kitchenObjectsSO)
    {
        FryingRecipeSO fryingSO = GetFryingRecipeSOWithInput(kitchenObjectsSO);
        return fryingSO != null;


    }

    private KitchenObjectsSO GetOutputForInput(KitchenObjectsSO inputKitchenObjectSO)
    {
        FryingRecipeSO fryingSO = GetFryingRecipeSOWithInput(inputKitchenObjectSO);
        if (fryingSO != null)
        {
            return fryingSO.output;
        }
        else
        {
            return null;
        }
    }

    private FryingRecipeSO GetFryingRecipeSOWithInput(KitchenObjectsSO inputKitchenSO)
    {
        foreach (FryingRecipeSO fryingReciepeSO in fryingRecipes)
        {
            if (fryingReciepeSO.input == inputKitchenSO)
            {
                return fryingReciepeSO;
            }
        }
        return null;
    }

    private BuringRecipeSO GetBurningRecipeSOWithInput(KitchenObjectsSO inputKitchenSO)
    {
        foreach (BuringRecipeSO burningRecipeSO in burningRecipes)
        {
            if (burningRecipeSO.input == inputKitchenSO)
            {
                return burningRecipeSO;
            }
        }
        return null;
    }
}
