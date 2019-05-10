using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class  LogicaTorres : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    protected GameObject torre;
    [SerializeField]
    protected float y;
    [SerializeField]
    protected float x;
    

    public abstract void OnMouseDown();
    
}
