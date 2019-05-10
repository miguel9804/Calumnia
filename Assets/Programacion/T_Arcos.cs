using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Arcos : LogicaTorres
{
    [SerializeField]
    private GameObject letrero;

    public override void OnMouseDown()
    {
        if(Moneda.Instancia.Dinero>=50)
        {
            Moneda.Instancia.Dinero -= 50;
            
            Moneda.Instancia.Compro = true;
            GameObject temp;
            Vector3 pos = this.transform.position;
            pos.y = pos.y + y;
            pos.x = pos.x + x;
            temp = Instantiate(torre);
            temp.transform.position = pos;
            temp.layer = 5;
            Destroy(letrero.gameObject);
        }
        

    }

}
   

