using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Torres : MonoBehaviour {
    private GameObject enemigo;
    private float UmbraldeDistancia = 3f;
    [SerializeField]
    private GameObject disparo;
    private List<GameObject> numero_flechas;
    private  float seg;

    public GameObject Enemigo
    {
        get
        {
            return enemigo;
        }

        set
        {
            enemigo = value;
        }
    }

    public List<GameObject> Numero_flechas
    {
        get
        {
            return numero_flechas;
        }

        set
        {
            numero_flechas = value;
        }
    }

    void Start()
    {
        Lista_Flechas();
        seg=0.5f;
    }
    GameObject BuscarEnemigos()
    {
        List<GameObject> objetivos = Oleadas.Enemigos;
        GameObject temp;
        foreach(Object item in objetivos)
        {
            temp = (GameObject)item;
            if (Vector3.Distance(temp.transform.position, this.transform.position) < UmbraldeDistancia)
            {
                return temp;
            }
        }
        return null;
    }
    private void Lista_Flechas()
    {
        Numero_flechas = new List<GameObject>();
        for(int i=0;i<5;i++)
        {
            Agregar_Flechas();
        }
    }
    public void Agregar_Flechas()
    {
        GameObject obj = Instantiate(disparo, this.transform.position, Quaternion.identity);
        obj.gameObject.SetActive(false);
        Numero_flechas.Add(obj);
    }
    public void Reciclar_Flechas(GameObject flechas)
    {
        flechas.gameObject.SetActive(false);
        Numero_flechas.Add(flechas);
    }
    public GameObject Activar_Flechas()
    {
        GameObject obj = Numero_flechas[Numero_flechas.Count - 1];
        Numero_flechas.RemoveAt(Numero_flechas.Count - 1);
        obj.gameObject.SetActive(true);
        return obj;

    }

    public GameObject Obtener_Flecha()
    {
       if(Numero_flechas.Count==0)
        {
            Agregar_Flechas();
        }
        return Activar_Flechas();
    }
    void Disparar()
    {
        Flechas flecha = Obtener_Flecha().GetComponent<Flechas>();
        flecha.ActivarFlecha(this);
    }
    
    // Update is called once per frame
    void Update()
        
    {
        seg += 1 * Time.deltaTime;
        Enemigo = BuscarEnemigos();
        if(seg>0.5f)
        {
            seg = 0f;
            if (Enemigo != null)
            {
                Disparar();
                Debug.DrawLine(this.transform.position, enemigo.transform.position, Color.green);

            }
        }
        

    }
}
