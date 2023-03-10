using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrashCounter : BaseCounter
{
    public static event EventHandler OnTrashCounter;
    public override void Interact(PlayerMovement player)
    {
        if (player.HasKitchenObject())
        {
            player.GetKitchenObject().DestroySelf();
            OnTrashCounter?.Invoke(this, EventArgs.Empty);
        }
    }
}
