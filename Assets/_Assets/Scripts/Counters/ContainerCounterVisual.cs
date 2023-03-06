using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ContainerCounterVisual : MonoBehaviour
{
    private const string OPEN_CLOSE = "OpenClose";

    private Animator animator;
    [SerializeField] private ContainerCounter containerCounter;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>(); 
        
    }
    private void Start()
    {
        containerCounter.OnPlayerCounter += ContainerCounter_OnPlayerCounter;
    }
    private void OnDisable()
    {
        containerCounter.OnPlayerCounter -= ContainerCounter_OnPlayerCounter;   
    }
    private void ContainerCounter_OnPlayerCounter(object sender, System.EventArgs e)
    {

        animator.SetTrigger(OPEN_CLOSE);
    }


}
