using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barra_Base : Barra_Vida
{
  
    protected override void Actualizador_vida()
    {

        if (Base.Instancia.Vidas == 100)
        {
            anim.SetInteger("Barra_bas", 8);
        }
        else if (Base.Instancia.Vidas <= 85 && Base.Instancia.Vidas > 70)
        {
            anim.SetInteger("Barra_bas", 7);
        }
        else if (Base.Instancia.Vidas <= 70 && Base.Instancia.Vidas > 55)
        {
            anim.SetInteger("Barra_bas", 6);
        }
        else if (Base.Instancia.Vidas <= 55 && Base.Instancia.Vidas > 40)
        {
            anim.SetInteger("Barra_bas", 5);
        }
        else if (Base.Instancia.Vidas <= 40 && Base.Instancia.Vidas > 25)
        {
            anim.SetInteger("Barra_bas", 4);
        }
        else if (Base.Instancia.Vidas <= 25 && Base.Instancia.Vidas > 10)
        {
            anim.SetInteger("Barra_bas", 3);

        }
        else if (Base.Instancia.Vidas <= 10 && Base.Instancia.Vidas > 0)
        {
            anim.SetInteger("Barra_bas", 2);
        }
        else if (Base.Instancia.Vidas <= 0)
        {
            anim.SetInteger("Barra_bas", 1);
        }

    }
    private void Update()
    {
        Actualizador_vida();
    }

}
