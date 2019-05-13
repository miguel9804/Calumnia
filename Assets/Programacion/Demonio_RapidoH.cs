using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demonio_RapidoH : Enemigos
{
    private Demonio_Rapido padre;
    protected override void Start()
    {
        padre = GameObject.FindGameObjectWithTag("Demonio rapido").GetComponent<Demonio_Rapido>();
        indice = padre.Indice_hijo;
        pos_siguiente = ruta.transform.GetChild(indice).position;
        Vida = 10;
        daño = 1;
        tiempo_ataque = 1f;
    }
    protected override void Update()
    {
        seg += 1f * Time.deltaTime;
        if(seg>1f)
        {
            vel = Random.Range(2.2f, 3.2f);
        }
        Vector3 dir = pos_siguiente - this.transform.position;
        this.transform.position += dir * vel * Time.deltaTime;
        if (dir.magnitude <= dis_punto)
        {
            if (indice+1 < ruta.transform.childCount)
            {
                indice++;
                pos_siguiente = ruta.transform.GetChild(indice).position;
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
        if (collision.gameObject.tag.Equals("Parar_DR"))
        {
            barrera = GameObject.FindGameObjectWithTag("Barrera").GetComponentInParent<Barrera>();
            barrera.Vida -= 10;
            Oleadas.Enemigos.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag.Equals("Barrera"))
        {
            barrera = GameObject.FindGameObjectWithTag("Barrera").GetComponentInParent<Barrera>();
            barrera.Vida -= 10;
            Oleadas.Enemigos.Remove(this.gameObject);
            Destroy(this.gameObject);

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

            barrera = GameObject.FindGameObjectWithTag("Barrera").GetComponentInParent<Barrera>();
            barrera.Vida -= 10;
            Oleadas.Enemigos.Remove(this.gameObject);
            Destroy(this.gameObject);

        }
    }
}
