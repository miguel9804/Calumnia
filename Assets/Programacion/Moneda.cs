using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour {

    public GameObject centenas, decenas, unidades;
    private Animator ce, de, un;
    private string[] estado = { "Moneda_0", "Moneda_1", "Moneda_2", "Moneda_3", "Moneda_4", "Moneda_5", "Moneda_6", "Moneda_7", "Moneda_8", "Moneda_9" };
    private float tiempoLimite = 30f;
    private float tiempo = 0f;
    private int dinero = 0;

    public int Dinero
    {
        get
        {
            return dinero;
        }

        set
        {
            dinero = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        ce = centenas.GetComponent<Animator>();
        de = decenas.GetComponent<Animator>();
        un = unidades.GetComponent<Animator>();



    }

    // Update is called once per frame
    void Update()
    {
        tiempo++;
        if (tiempo > tiempoLimite)
        {
            dinero++;
            ActualizadorContador(dinero);
            tiempo = 0;
        }

    }
    public void ActualizadorContador(int numero)
    {
        int unidades = numero % 10;
        int decenas = numero % 100 - unidades;
        int centenas = numero % 1000 - decenas;
        //Debug.Log("numero " + numero + " centenas " + centenas / 100 + " decenas " + decenas / 10 + " unidades " + unidades);

        decenas = decenas / 10;
        centenas = centenas / 100;

        if (numero > 9)
        {
            de.Play(estado[decenas]);
        }
        else
        {
            de.Play(estado[0]);
        }

        if (numero > 99)
        {
            ce.Play(estado[centenas]);
        }
        else
        {
            ce.Play(estado[0]);
        }
        un.Play(estado[unidades]);

    }
}
