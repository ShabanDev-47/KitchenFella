using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movSpeed;
    [SerializeField] GameInputs gameInputs;
    [SerializeField] LayerMask layerMask;

    private float rotSpeed = 10f;
    private bool isWalking;
    private Vector3 lastDir;
    private void Start()
    {
        gameInputs.OnInteract += GameInputs_OnInteract;
        movSpeed = 4f;
        
    }

    private void GameInputs_OnInteract(object sender, System.EventArgs e)
    {
        Vector3 movDir = gameInputs.MovementNormalized();

        if (movDir != Vector3.zero)
        {
            lastDir = movDir;
        }

        float interactionDis = 2f;
        if (Physics.Raycast(transform.position, lastDir, out RaycastHit _rayhit, interactionDis, layerMask))
        {
            if (_rayhit.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                clearCounter.Interact();
            }

        }
        else
        {
            Debug.Log("-");
        }
    }

    private void Update()
    {
      //  HandleInteract();
        HandleMovement();
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
                clearCounter.Interact();
            }
           
        }
        else
        {
            Debug.Log("-");
        }

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
 
}
