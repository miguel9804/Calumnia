using UnityEngine;
using System.Collections;

public class Torres : MonoBehaviour {
    private GameObject enemigo;
    private float UmbraldeDistancia = 3f;
    [SerializeField]
    private GameObject disparo;
    private static float seg;

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
        
        Torres.seg=30f;
    }
    GameObject BuscarEnemigos()
    {
        ArrayList objetivos = Oleadas.enemigos;
        GameObject temp;
        foreach(Object item in objetivos)
        {
            temp = (GameObject)item;
            if (Vector3.Distance(temp.transform.position, this.transform.position)<UmbraldeDistancia)
            {
                Debug.Log("Entro");
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
        if(Torres.seg>30f)
        {
            Torres.seg = 0f;
            

            if (Enemigo != null)
            {
                
                Disparar();
                Debug.DrawLine(this.transform.position, enemigo.transform.position, Color.green);

            }
        }
        

    }
}
