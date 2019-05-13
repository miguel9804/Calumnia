using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public  class Mazo : Enemigos
{
    protected override void Start()
    {
        Vida = 25;
        vel = 1.2f;
        daño = 8;
        tiempo_ataque = 6f;
    }
    protected override void Update()
    {
        Vector3 dir = pos_siguiente - this.transform.position;
        this.transform.position += dir * vel * Time.deltaTime;
        if (dir.magnitude <= dis_punto)
        {
            if (indice + 1 < ruta.transform.childCount)
            {
                indice++;
                pos_siguiente = ruta.transform.GetChild(indice).position;
            }
           
        }
        if (ataque == true)
        {
            Debug.Log(barr_frente);
            seg += 1f * Time.deltaTime;
            if (seg > tiempo_ataque)
            {
                barrera.Vida -= daño;
                seg = 0;
            }
            if (barrera.Vida <= 0)
            {
                if (seg > 1f)
                {
                    ataque = false;
                    vel = 1.5f;
                    seg_barr = 0f;
                }

            }
            seg_barr += 1f * Time.deltaTime;
            if (barr_frente == true)
            {
                if (seg_barr < 1f)
                {
                    Vector3 pos = this.transform.position;
                    pos.x = pos.x + 0.013f;
                    this.transform.position = pos;
                }

            }
            else if (barr_frente == false)
            {
                if (seg_barr < 1f)
                {
                    Vector3 pos = this.transform.position;
                    pos.y = pos.y + 0.02f;
                    this.transform.position = pos;
                }
            }
            
        }

        if (Vida <= 0)
        {
            Muerte();

        }

    }
    protected override void Muerte()
    {
        Oleadas.Enemigos.Remove(this.gameObject);
        Destroy(this.gameObject);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(FLECHA))
        {

            Debug.Log("La vida es: " + Vida);
            Vida = Vida - 2f;

        }

        if (collision.gameObject.tag.Equals(BASE))
        {

            Muerte();
        }
        if (collision.gameObject.tag.Equals("Parar_MZ"))
        {
            barr_frente = true;
            vel = 0;
            barrera = GameObject.FindGameObjectWithTag("Barrera").GetComponentInParent<Barrera>();
            ataque = true;

        }
        if (collision.gameObject.tag.Equals("Barrera"))
        {
            barr_frente = false;
            vel = 0;
            barrera = GameObject.FindGameObjectWithTag("Barrera").GetComponent<Barrera>();
            ataque = true;

        }
        if (collision.gameObject.tag.Equals("Cambio_Direccion"))
        {
            Vector3 scale = this.transform.position;
            scale.x = -this.transform.localScale.x;
            scale.y = this.transform.localScale.y;
            this.transform.localScale = scale;
        }


    }
    protected override void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Parar_MZ"))
        {
            ataque = false;

        }
        if (collision.gameObject.tag.Equals("Barrera"))
        {
            ataque = false;

        }
    }
}
