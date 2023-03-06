using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCounter : BaseCounter
{
    public override void Interact(PlayerMovement player)
    {
        if (player.HasKitchenObject())
        {
            player.GetKitchenObject().DestroySelf();
        }
    }
}
