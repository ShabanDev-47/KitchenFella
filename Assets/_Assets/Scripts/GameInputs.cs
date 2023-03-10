using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputs : MonoBehaviour
{
    public static GameInputs Instance { get; private set; }
    public event EventHandler OnInteract;
    public event EventHandler OnInteractAlter;
    public event EventHandler OnPause;
    private PlayerController playerController;

    private void Awake()
    {
        Instance = this;

        playerController = new PlayerController();
        playerController.Player.Enable();
        playerController.Player.Interact.performed += Interact_performed;
        playerController.Player.InteractAlter.performed += InteractAlter_performed;
        playerController.Player.Pause.performed += Pause_performed;
    }
    private void OnDestroy()
    {
        playerController.Dispose();
        playerController.Player.Interact.performed -= Interact_performed;
        playerController.Player.InteractAlter.performed -= InteractAlter_performed;
        playerController.Player.Pause.performed -= Pause_performed;


    }

    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPause.Invoke(this, EventArgs.Empty);
    }

    private void InteractAlter_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAlter.Invoke(this, EventArgs.Empty);
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
