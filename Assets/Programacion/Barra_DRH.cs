using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barra_DRH : Barra_Vida
{
    private Demonio_RapidoH drH;
    [SerializeField]
    private GameObject drH_go;
    protected override void Actualizador_vida()
    {
        drH = drH_go.GetComponent<Demonio_RapidoH>();
        if (drH.Vida == 10)
        {
            anim.SetInteger("Vida_Enemigos", 5);
        }
        else if (drH.Vida <= 8 && drH.Vida > 6)
        {
            anim.SetInteger("Vida_Enemigos", 4);
        }
        else if (drH.Vida <= 6 && drH.Vida > 4)
        {
            anim.SetInteger("Vida_Enemigos", 3);
        }
        else if (drH.Vida <= 4 && drH.Vida > 2)
        {
            anim.SetInteger("Vida_Enemigos", 2);
        }
        else if (drH.Vida <= 2 && drH.Vida > 0)
        {
            anim.SetInteger("Vida_Enemigos", 1);
        }
        else if (drH.Vida <= 0)
        {
            anim.SetInteger("Vida_Enemigos", 4);
        }

    }
    private void Update()
    {
        Actualizador_vida();
    }
}
