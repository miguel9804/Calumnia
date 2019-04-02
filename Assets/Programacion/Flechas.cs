using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flechas : MonoBehaviour {
    private GameObject objetivo;
    private float disparoLife = 2f;
    private float speed = 5f;
   
    private const string ENEMIGO = "Enemigo";
   
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(ENEMIGO))
        {
            //Debug.Log("Ataco al enemigo");
            Destroy(this.gameObject);
        }
    }
    public void ActivarFlecha(Torres torre)
    {
        objetivo = torre.Enemigo;
    }
    // Update is called once per frame
    void Update () {
        
        Vector3 direccion;
       
            if (objetivo != null)
            {
                direccion = objetivo.transform.position - this.transform.position;
                this.transform.position += speed * direccion * Time.deltaTime;
                Destroy(this.gameObject, disparoLife);

            }

	}
}
