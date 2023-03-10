using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SizzleAudio : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private StoveCounter stoveCounter;
    // Start is called before the first frame update
    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    void Start()
    {
        stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
    }

    private void StoveCounter_OnStateChanged(object sender, StoveCounter.OnStateChangedArgs e)
    {
        if(e.state==StoveCounter.State.frying || e.state == StoveCounter.State.fried)
        {
            source.Play();
        }
        else
        {
            source.Pause();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
