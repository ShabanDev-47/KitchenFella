using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlateCounter : BaseCounter
{
    public event EventHandler OnPlateSpawn;
    public event EventHandler OnPlateRemoved;

    private float spawnPlateTimer;
    private float spawnTimerMax;
    [SerializeField] KitchenObjectsSO plateSO;
    private int platesSpawnAmount;
    private int platesSpawnAmountMax = 4;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimerMax = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        spawnPlateTimer +=Time.deltaTime;
        if(spawnPlateTimer > spawnTimerMax)
        {
            spawnPlateTimer = 0;
            if (platesSpawnAmount < platesSpawnAmountMax)
            {
                platesSpawnAmount++;

                OnPlateSpawn?.Invoke(this, EventArgs.Empty);
            }
        }

    }

    public override void Interact(PlayerMovement player)
    {
        if (!player.HasKitchenObject())
        {
            if(platesSpawnAmount > 0)
            {
                platesSpawnAmount--;
                KitchenObject.SpawnKitchenObject(plateSO, player);

                OnPlateRemoved?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
