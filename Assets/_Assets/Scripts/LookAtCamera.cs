using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField] private Mode mode;
    private enum Mode
    {
        LookAt,
        LookForwared,
    }
    private void LateUpdate()
    {
        switch (mode)
        {
            case Mode.LookAt:
                transform.LookAt(Camera.main.transform);
                break;
            case Mode.LookForwared:
                transform.forward = Camera.main.transform.forward;
               // transform.LookAt(transform.forward);
                break;
        }
        
    }
}
