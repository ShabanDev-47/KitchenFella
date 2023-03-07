using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounterVisual : MonoBehaviour
{
    [SerializeField] private Transform platCounterTopPoint;
    [SerializeField] GameObject plateVisual;
    [SerializeField] PlateCounter plateCounter;

    private List<GameObject> plates;


    private void Start()
    {
        plateCounter.OnPlateSpawn += PlateCounter_OnPlateSpawn;
        plateCounter.OnPlateRemoved += PlateCounter_OnPlateRemoved;
        plates = new();
    }

    private void PlateCounter_OnPlateRemoved(object sender, System.EventArgs e)
    {
        GameObject last = plates[plates.Count - 1];
        plates.Remove(last);
        Destroy(last);

    }

    private void PlateCounter_OnPlateSpawn(object sender, System.EventArgs e)
    {
        GameObject plate = Instantiate(plateVisual, platCounterTopPoint);

        float VisualOffsetY = 0.1f;
        plate.transform.localPosition = new Vector3(0f, VisualOffsetY * plates.Count, 0f);
        
        plates.Add(plate);
    }
}
