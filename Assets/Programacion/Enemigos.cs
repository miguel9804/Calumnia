﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    public GameObject ruta;
    private int indice;
    private Vector3 pos_siguiente;
    public float vel;
    private float dis_punto = 0.5f ;
    [SerializeField]
    private float vida;
    private const string FLECHA = "Flecha";
    private const string BASE = "Base";
    private const string AURA = "Aura";
    
    
  
    

    void Start()
    {
        pos_siguiente = ruta.transform.GetChild(0).position;
       
    }



    void Update()
    {
       
        Vector3 dir = pos_siguiente - this.transform.position;
        this.transform.position += dir * vel * Time.deltaTime;
        //this.transform.position = this.transform.position+("")
  
            if (dir.magnitude <= dis_punto)
            {
                if (indice + 1 < ruta.transform.childCount)
                {
                    indice++;
                    pos_siguiente = ruta.transform.GetChild(indice).position;
                    //Debug.Log("xs= " + pos_siguiente.x + ", ys= " + pos_siguiente.y);
                }
                else
                {
                    indice = 0;
                    this.transform.position = pos_siguiente;
                    pos_siguiente = ruta.transform.GetChild(0).position;
                }
            }
       
        
    }
    void Muerte()
    {
        Oleadas.Enemigos.Remove(this.gameObject);
        Destroy(this.gameObject);
       
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(FLECHA))
        {

            Debug.Log("La vida es: " + vida);
            vida = vida - 2f;
            if (vida <= 0)
            {
                
                Muerte();
                
            }
        }
        
        if (collision.gameObject.tag.Equals(BASE))
        {
            
            Muerte();
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(AURA))
        {

                vida = vida-0.1f;
                Debug.Log("Daño aura, La vida es:" + vida);
                if (vida <= 0)
                {
                    Muerte();
                }

        }
    }


}
