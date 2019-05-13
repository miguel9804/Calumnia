using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Padre : MonoBehaviour
{

    private Iglesia iglesia;
    [SerializeField]
    private GameObject igl;
    private Animator anim;

    void Start()
    {
        iglesia = igl.GetComponent<Iglesia>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (iglesia.Activo == true)
        {
            anim.SetBool("Ataque", true);
        }
        else
        {
            anim.SetBool("Ataque", false);
        }
    }
   


   
   
}
