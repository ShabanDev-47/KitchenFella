using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public interface IHasProgress
{
    public event EventHandler<OnprogressChangedArg> OnProgressChanged;
    
    public class OnprogressChangedArg : EventArgs
    {
        public float progressNormalised;
    }

}
