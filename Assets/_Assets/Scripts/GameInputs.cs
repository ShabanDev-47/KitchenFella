using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputs : MonoBehaviour
{
    public event EventHandler OnInteract;
    private PlayerController playerController;

    private void Awake()
    {
        playerController = new PlayerController();
        playerController.Player.Enable();
        playerController.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteract?.Invoke(this, EventArgs.Empty);
       
    }

    public Vector3 MovementNormalized()
    {
        Vector2 Dir = playerController.Player.Move.ReadValue<Vector2>();
        Vector3 movDir = new Vector3 (Dir.x, 0f, Dir.y);
        
       return movDir = movDir.normalized;
    }
}
