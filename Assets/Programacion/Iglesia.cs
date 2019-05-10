using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iglesia : MonoBehaviour
{
    [SerializeField]
    private GameObject aura;
    [SerializeField]
    private Transform creacion;
    [SerializeField]
    private float tiempo_aura;
    private static Iglesia instancia;
    private bool activar;
    private bool activo;
    private float seg;
    private const string ENEMIGO = "Enemigo";

  

    public static Iglesia Instancia
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

    public  bool Activo
    {
        get
        {
            return activo;
        }
        private set
        {
            activo = value;
        }
    }

    private void Start()
    {
        seg = 10f;
        Instancia = this;
    }
    void Update()
    {
        
        seg += 1f * Time.deltaTime;
        if(seg >5f)
        {
           Activo = false;
        }
        if (seg > 10f)
        {
            activar = true;
        }
        else
        {
           activar = false;
        }

    }
    private void ActivarAura()
    {
        GameObject crear_aura = Instantiate(aura, creacion.position, creacion.rotation);
        
        Destroy(crear_aura.gameObject, tiempo_aura);

    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(ENEMIGO))
        {
            if(activar == true)
            {
                Activo = true;
                ActivarAura();
                seg = 0f;
            }
        }
    }
   
}
