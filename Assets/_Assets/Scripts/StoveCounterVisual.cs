using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterVisual : MonoBehaviour
{
    [SerializeField] private GameObject particle;
    [SerializeField] private GameObject sizzles;
    [SerializeField] private StoveCounter stoveCounter;
    // Start is called before the first frame update
    void Start()
    {
        stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
    }

    private void StoveCounter_OnStateChanged(object sender, StoveCounter.OnStateChangedArgs e)
    {
        bool showVisual = e.state == StoveCounter.State.frying || e.state == StoveCounter.State.fried;

        particle.SetActive(showVisual);
        sizzles.SetActive(showVisual);
    }
}
