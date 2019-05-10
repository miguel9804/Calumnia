using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Torres : MonoBehaviour {
    private GameObject enemigo;
    private float UmbraldeDistancia = 3f;
    [SerializeField]
    private GameObject disparo;
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

    void Start()
    {
        
        seg=30f;
    }
    GameObject BuscarEnemigos()
    {
        List<GameObject> objetivos = Oleadas.Enemigos;
        GameObject temp;
        foreach(Object item in objetivos)
        {
            temp = (GameObject)item;
            if (Vector3.Distance(temp.transform.position, this.transform.position)<UmbraldeDistancia)
            {
                
                return temp;
            }
        }
        return null;
    }
    void Disparar()
    {
        GameObject obj = Instantiate(disparo, this.transform.position, Quaternion.identity);
        Flechas flecha = obj.GetComponent<Flechas>();
        flecha.ActivarFlecha(this);
    }
    
    // Update is called once per frame
    void Update()
        
    {
        seg += 1 + Time.deltaTime;
        Enemigo = BuscarEnemigos();
        if(seg>30f)
        {
            seg = 0f;
            

            if (Enemigo != null)
            {

                Disparar();
                //Debug.Log("Disparo");
                Debug.DrawLine(this.transform.position, enemigo.transform.position, Color.green);

            }
        }
        

    }
}
