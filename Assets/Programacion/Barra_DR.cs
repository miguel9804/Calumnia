using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barra_DR :Barra_Vida
{
    private Demonio_Rapido dr;
    [SerializeField]
    private GameObject dr_go;
    protected override void Actualizador_vida()
    {
        dr = dr_go.GetComponent<Demonio_Rapido>();
        if (dr.Vida == 13)
        {
            anim.SetInteger("Vida_Enemigos", 5);
        }
        else if (dr.Vida <= 10.4f && dr.Vida > 7.8f)
        {
            anim.SetInteger("Vida_Enemigos", 4);
        }
        else if (dr.Vida <= 7.8f && dr.Vida > 5.2f)
        {
            anim.SetInteger("Vida_Enemigos", 3);
        }
        else if (dr.Vida <= 5.2f && dr.Vida > 2.6f)
        {
            anim.SetInteger("Vida_Enemigos", 2);
        }
        else if (dr.Vida <= 2.6 && dr.Vida > 0)
        {
            anim.SetInteger("Vida_Enemigos", 1);
        }
        else if (dr.Vida <= 0)
        {
            anim.SetInteger("Vida_Enemigos", 0);
        }

    }
    private void Update()
    {
        Actualizador_vida();
    }
}
