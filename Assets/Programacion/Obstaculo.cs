using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    [SerializeField]
    private GameObject obstaculo;
    [SerializeField]
    private Transform creacion;
    private bool activar;
    private float seg;
    private const string ENEMIGO = "Enemigo";

  

    private void Start()
    {
       
        seg = 20f;
        activar = true;
    }
    void Update()
    {
       
        if (Barrera.Instancia.Construir == true)
        {
           
            seg += 1f * Time.deltaTime;
            if (seg > 20f)
            {
                activar = true;
                

            }
            else 
            {
                activar = false;
            }
        }
     
    }
    private void Crear()
    {
        GameObject crear_barrera = Instantiate(obstaculo, creacion.position, creacion.rotation);
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(ENEMIGO))
        {
            if (activar == true)
            {
                Crear();
                seg = 0;
            }
        }
    }
}
