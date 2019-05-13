using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Base : MonoBehaviour
{
    private int vidas = 100;
    private Animator bas;
    private static Base instancia;
    public int Vidas
    {
        get
        {
            return vidas;
        }

        set
        {
            vidas = value;
        }
    }

    public static Base Instancia
    {
        get
        {
            return instancia;
        }

        set
        {
            instancia = value;
        }
    }

    private void Start()
    {
        Instancia = this;
        bas = GetComponent<Animator>();
        bas.SetInteger("Vida_Base", 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemigo")|| collision.gameObject.tag.Equals("Demonio rapido"))
        {
            
            Instancia.Vidas = Vidas - 5;
            FormaBase();
            if(Instancia.Vidas<=0)
            {
                Destroy(this.gameObject);
            }
        }
    }
    void FormaBase()
    {
        if(Instancia.Vidas <= 75 && Instancia.Vidas > 40)
        {
            bas.SetInteger("Vida_Base", 1);

        }
       else if (Instancia.Vidas <= 40 && Instancia.Vidas > 5)
        {
            bas.SetInteger("Vida_Base", 2);

        }
       else if (Instancia.Vidas <= 5 && Instancia.Vidas > 0)
        {
            bas.SetInteger("Vida_Base", 3);

        }
       else if(Instancia.Vidas <= 0)
        {
            SceneManager.LoadScene("Game over");
        }
    }
}
