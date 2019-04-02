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
    public static int seg;
    void Start()
    {
        Iglesia.seg = 700;
    }

    
    void Update()
    {
        seg = 1 +seg;
        Debug.Log(seg);
        if(Iglesia.seg>700)
        {
            Iglesia.seg = 0;
            GameObject crear_aura = Instantiate(aura, creacion.position, creacion.rotation);
            Destroy(crear_aura.gameObject,tiempo_aura);
        }
    }
}
