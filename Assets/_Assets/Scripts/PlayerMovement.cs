using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerMovement : MonoBehaviour,IKitchenObjectParent
{
    public static PlayerMovement Instance { get; private set; }
    public event EventHandler<OnSelectedCounterChangedArgs> OnSelectedCounterChanged;
    public class OnSelectedCounterChangedArgs : EventArgs
    {
        public ClearCounter selectedCounter;
    }

    [SerializeField] float movSpeed;
    [SerializeField] GameInputs gameInputs;
    [SerializeField] LayerMask layerMask;
    private ClearCounter selectedCounter;
    private KitchenObject kitchenObjectt;
    [SerializeField] private Transform kitchenObjectHoldPoint;


    private float rotSpeed = 10f;
    private bool isWalking;
    private Vector3 lastDir;
    private void Awake()
    {
        Instance = this;
        if (Instance == null)
        {
            Debug.LogError("More than one player Instance !");
        }
        
    }
    private void Start()
    {
        gameInputs.OnInteract += GameInputs_OnInteract;
        movSpeed = 4f;
        
    }

    private void GameInputs_OnInteract(object sender, System.EventArgs e)
    {
        if(selectedCounter != null)
        {
            selectedCounter.Interact(this);
        }
 
    }

    private void Update()
    {
      //  HandleInteract();
        HandleMovement();
        HandleInteract();
    }

    public bool IsWalking()
    {
        return isWalking;
    }
    private void HandleInteract()
    {
        Vector3 movDir = gameInputs.MovementNormalized();

        if(movDir != Vector3.zero)
        {
            lastDir = movDir;
        }
          
        float interactionDis = 2f;
        if (Physics.Raycast(transform.position, lastDir, out RaycastHit _rayhit, interactionDis,layerMask)){
            if(_rayhit.transform.TryGetComponent(out ClearCounter clearCounter))
            {
               // clearCounter.Interact();
                if(clearCounter != selectedCounter)
                {
                    selectedCounter = clearCounter;
                    SetSelectedCounter(clearCounter);
                    
                }
            }
            else
            {
                selectedCounter = null;
                SetSelectedCounter(null);
            }          
        }
        else
        {
            selectedCounter = null;
            SetSelectedCounter(null);
        }
        Debug.Log(selectedCounter);

    }

    private void HandleMovement()
    {
        Vector3 movDir = gameInputs.MovementNormalized();
        float playerRadius = .5f;
        float distance = movSpeed * Time.deltaTime;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up, playerRadius, movDir, distance);
        if (!canMove)
        {
            //Can't move in movDir
            //Attempt only mov on X axis

            Vector3 movDirX = new Vector3(movDir.x, 0, 0).normalized;

            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up, playerRadius, movDirX, distance);
            if (canMove)
                movDir = movDirX;

            else
            {
                // on Z
                Vector3 movDirZ = new Vector3(0, 0, movDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up, playerRadius, movDirZ, distance);
                if (canMove)
                    movDir = movDirZ;
                else
                {
                    //Cannot move in Any Dir
                }
            }
        }


        //Normal movement Case
        if (canMove)
        {
            isWalking = movDir != Vector3.zero;
            transform.position += movDir * distance;
            transform.forward += Vector3.Slerp(transform.forward, movDir, Time.deltaTime * rotSpeed);
        }

    }
    private void SetSelectedCounter(ClearCounter selectedCounter)
    {
        this.selectedCounter = selectedCounter;
        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedArgs { selectedCounter = selectedCounter });
    }
    public Transform GetKitchenObjectFollowTransform()
    {
        return kitchenObjectHoldPoint;
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
