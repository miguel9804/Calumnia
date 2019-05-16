using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    [SerializeField]
    private GameObject obstaculo;
    private GameObject crear_barrera;
    [SerializeField]
    private Transform creacion;
    private bool activar;
    private Barrera barrera;
    private float seg;


    private void Start()
    {
        crear_barrera = Instantiate(obstaculo, creacion.position, creacion.rotation);
        barrera = GameObject.FindGameObjectWithTag("Barrera").GetComponent<Barrera>();
        barrera.Vida = 30;
        crear_barrera.SetActive(false);
        seg = 20f;
        activar = true;
    }
    void Update()
    {
        if(barrera.Vida<=0)
        {
            crear_barrera.SetActive(false);
            seg += 1f * Time.deltaTime;
            if (seg > 20f)
            {
                activar = true;
                barrera.Vida = 30;
            }
            else if(seg<20f)
            {
                activar = false;
            }
        }
        

     
    }
    private void Crear()
    {

        crear_barrera.SetActive(true);
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemigo")|| collision.gameObject.tag.Equals("Demonio rapido"))
        {
            if (activar == true)
            {
                Crear();
                seg = 0;
            }
        }
    }
}
