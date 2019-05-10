using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Letrero : LogicaTorres
{
    public override void OnMouseDown()
    {
        GameObject temp;
        Vector3 pos = this.transform.position;
        pos.y = pos.y + y;
        pos.x = pos.x + x;
        temp = Instantiate(torre);
        temp.transform.position = pos;
        temp.layer = 5;
        Destroy(this.gameObject);
    }
}
