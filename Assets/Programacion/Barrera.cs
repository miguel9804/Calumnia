using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrera : MonoBehaviour
{
    private  int vida;
    private static Barrera instancia;
    private  bool construir;
    

    public static Barrera Instancia
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

    public  int Vida
    {
        get
        {
            return vida;
        }

        set
        {
            vida = value;
        }
    }

    public  bool Construir
    {
        get
        {
            return construir;
        }

         set
        {
            construir = value;
        }
    }

    void Start()
    {
        Instancia = this;
        Vida = 30;
        Construir = true;
    
    }
    private void Update()
    {

        if (Vida <= 0)
        {
            Destruir();
        }
        else if (Vida > 0)
        {
            Construir = false;
        }
       
    }
    private void Destruir()
    {
        Destroy(this.gameObject);
        Construir = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemigo"))
        {

            Vida -= 1;
           

        }
    }


}
