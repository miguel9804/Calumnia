using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaTorres : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    private GameObject torre;
    [SerializeField]
    private float y;
    [SerializeField]
    private float x;
 

    void OnMouseDown()
    {
        //Debug.Log("Test");
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
