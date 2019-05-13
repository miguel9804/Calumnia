using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barra_ES : Barra_Vida
{
    private Espantapajaros esp;
    [SerializeField]
    private GameObject esp_go;
    protected override void Actualizador_vida()
    {
        esp = esp_go.GetComponent<Espantapajaros>();
        if(esp.Vida==20)
        {
            anim.SetInteger("Vida_Enemigos", 5);
        }
        else if(esp.Vida<=16 && esp.Vida>12)
        {
            anim.SetInteger("Vida_Enemigos", 4);
        }
        else if (esp.Vida <= 12 && esp.Vida > 8)
        {
            anim.SetInteger("Vida_Enemigos", 3);
        }
        else if (esp.Vida <= 8 && esp.Vida > 4)
        {
            anim.SetInteger("Vida_Enemigos", 2);
        }
        else if (esp.Vida <= 4 && esp.Vida > 0)
        {
            anim.SetInteger("Vida_Enemigos", 1);
        }
        else if (esp.Vida<=0)
        {
            anim.SetInteger("Vida_Enemigos", 0);
        }

    }
    private void Update()
    {
        Actualizador_vida();
    }
}
