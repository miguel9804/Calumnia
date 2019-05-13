using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flechas : MonoBehaviour {
    private Torres torres;
    [SerializeField]
    private GameObject torr;
    private GameObject objetivo;
    private float disparoLife = 1.5f;
    private float seg;
    private float speed = 5f;
    private const string ENEMIGO = "Enemigo";

    private void Start()
    {
       torres = torr.GetComponent<Torres>();
        seg=0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Enemigo")|| collision.gameObject.tag.Equals("Demonio rapido"))
        {
            torres.Reciclar_Flechas(this.gameObject);
         
        }

        
    }
    public void ActivarFlecha(Torres torre)
    {
        objetivo = torre.Enemigo;
    }
    // Update is called once per frame
    void Update() {

        Vector3 direccion;

        if (objetivo != null)
        {
            seg += 1f * Time.deltaTime;
            direccion = objetivo.transform.position - this.transform.position;
            this.transform.position += speed * direccion * Time.deltaTime;
            
            if (seg>disparoLife)
            {
                torres.Reciclar_Flechas(this.gameObject);
                seg = 0;
            }
            
        }
        else if (objetivo == null)
        {
            torres.Reciclar_Flechas(this.gameObject);
        }


    }
}
