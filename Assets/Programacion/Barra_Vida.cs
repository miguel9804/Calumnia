using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Barra_Vida : MonoBehaviour
{
    protected Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    protected abstract void Actualizador_vida();
    
}
