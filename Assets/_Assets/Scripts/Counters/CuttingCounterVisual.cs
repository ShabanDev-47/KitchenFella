using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CuttingCounterVisual : MonoBehaviour
{
    private const string CUT = "Cut";

    private Animator animator;
    [SerializeField] private CuttingCounter cuttingCounter;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>(); 
        
    }
    private void Start()
    {
        cuttingCounter.OnProgressChangedAnimate += ContainerCounter_OnPlayerCounter;
    }
    private void OnDisable()
    {
        cuttingCounter.OnProgressChangedAnimate -= ContainerCounter_OnPlayerCounter;   
    }
    private void ContainerCounter_OnPlayerCounter(object sender, System.EventArgs e)
    {

        animator.SetTrigger(CUT);
    }


}
