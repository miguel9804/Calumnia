using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demonio_Rapido : Enemigos
{
    [SerializeField]
    private GameObject hijos;

  
    private int indice_hijo;

    public int Indice_hijo
    {
        get
        {
            return indice_hijo;
        }

        set
        {
            indice_hijo = value;
        }
    }

    protected override void Start()
    {
        Vida = 13; 
        daño = 1;
        tiempo_ataque = 1f;
    }
    protected override void Update()
    {
        Vector3 dir = pos_siguiente - this.transform.position;
        this.transform.position += dir * vel * Time.deltaTime;
        if (dir.magnitude <= dis_punto)
        {
            if (indice+1< ruta.transform.childCount)
            {
                indice++;
                Indice_hijo = indice;
                pos_siguiente = ruta.transform.GetChild(indice).position;
            }

        }
        if (ataque == true)
        {
            seg += 1f * Time.deltaTime;
            if (seg > tiempo_ataque)
            {
                barrera.Vida -= daño;
                seg = 0;
            }
            if (barrera.Vida <= 0)
            {
                ataque = false;
                vel = 2.2f;
                seg_barr = 0f;
            }
            seg_barr += 1f * Time.deltaTime;
            if (barr_frente == false)
            {
                if (seg_barr < 1f)
                {
                    Vector3 pos = this.transform.position;
                    pos.y = pos.y + 0.005f;
                    this.transform.position = pos;
                }

            }

        }
        if (Vida <= 0)
        {
            Muerte();
            Moneda.Instancia.Dinero += 3;
        }


    }
    private void Crear_Hijos()
    {
        int n;
        n = Random.Range(1, 4);
        for(int i=0; i<n;i++)
        {
            GameObject crear = Instantiate(hijos, this.transform.position, this.transform.rotation);
            Oleadas.Enemigos.Add(crear);
        }
    }
    protected override void Muerte()
    {
        Oleadas.Enemigos.Remove(this.gameObject);
        Destroy(this.gameObject);
        int n;
        n = Random.Range(1, 4);
      
        if(n>=2)
        {
            Crear_Hijos();
        }
       
    }
    private void Muerte_Base()
    {
        Oleadas.Enemigos.Remove(this.gameObject);
        Destroy(this.gameObject);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(FLECHA))
        {
            Vida = Vida - 2f;
        }

        if (collision.gameObject.tag.Equals(BASE))
        {
            Muerte_Base();
        }
        if (collision.gameObject.tag.Equals("Parar_DR"))
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
        if (collision.gameObject.tag.Equals("Parar_DR"))
        {
            ataque = false;


        }
        if (collision.gameObject.tag.Equals("Barrera"))
        {
            ataque = false;

        }
    }
}
