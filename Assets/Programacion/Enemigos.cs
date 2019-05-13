using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemigos : MonoBehaviour
{
    [SerializeField]
    protected GameObject ruta;
    protected int indice;
    protected Vector3 pos_siguiente;
    protected float dis_punto = 0.5f;
    private float vida;
    [SerializeField]
    protected float vel;
    protected bool ataque;
    protected int daño;
    protected Barrera barrera;
    protected float tiempo_ataque;
    protected float seg;
    protected float seg_barr;
    protected bool barr_frente;
    //protected Animator anim;
    protected const string FLECHA = "Flecha";
    protected const string BASE = "Base";
    protected const string AURA = "Aura";

    public float Vida
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

    protected void Awake()
    {
        //anim = GetComponent<Animator>();
        seg = 0;
        seg_barr = 0;
        ataque = false;
        pos_siguiente = ruta.transform.GetChild(0).position;
    }
    protected abstract void Start();



    protected abstract void Update();

    protected abstract void Muerte();


    protected abstract void OnTriggerEnter2D(Collider2D collision);
    

    protected  void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(AURA))
        {
            Vida = Vida - 0.1f;
        }
    }
    protected abstract void OnTriggerExit2D(Collider2D collision);
  

}
