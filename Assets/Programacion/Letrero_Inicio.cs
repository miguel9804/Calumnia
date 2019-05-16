using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letrero_Inicio : MonoBehaviour
{
    private float seg;
    // Start is called before the first frame update
    void Start()
    {
        seg = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        seg += 1f * Time.deltaTime;
        if(seg>3f)
        {
            Destroy(this.gameObject);
        }
    }
}
