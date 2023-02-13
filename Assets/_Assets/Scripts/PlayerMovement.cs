using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movSpeed;
    [SerializeField] GameInputs gameInputs;
    private float rotSpeed = 10f;
    private bool isWalking;
    private void Start()
    {
        movSpeed = 4f;
    }
    private void Update()
    {
        Vector3 movDir = gameInputs.MovementNormalized();

        isWalking = movDir != Vector3.zero;
        transform.position += movDir * movSpeed * Time.deltaTime;
        transform.forward += Vector3.Slerp(transform.forward, movDir, Time.deltaTime * rotSpeed);
        
    }

    public bool IsWalking()
    {
        return isWalking;
    }
    

  
}
