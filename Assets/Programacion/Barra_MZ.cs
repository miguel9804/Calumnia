using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barra_MZ : Barra_Vida
{
    private Mazo maz;
    [SerializeField]
    private GameObject maz_go;
    protected override void Actualizador_vida()
    {
        maz = maz_go.GetComponent<Mazo>();
        if (maz.Vida == 25)
        {
            anim.SetInteger("Vida_Enemigos", 5);
        }
        else if (maz.Vida <= 20 && maz.Vida > 15)
        {
            anim.SetInteger("Vida_Enemigos", 4);
        }
        else if (maz.Vida <= 15 && maz.Vida > 10)
        {
            anim.SetInteger("Vida_Enemigos", 3);
        }
        else if (maz.Vida <= 10 && maz.Vida > 5)
        {
            anim.SetInteger("Vida_Enemigos", 2);
        }
        else if (maz.Vida <= 5 && maz.Vida > 0)
        {
            anim.SetInteger("Vida_Enemigos", 1);
        }
        else if (maz.Vida <= 0)
        {
            anim.SetInteger("Vida_Enemigos", 0);
        }

    }
    private void Update()
    {
        Actualizador_vida();
    }
}
