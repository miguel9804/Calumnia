using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruir_Letrero : MonoBehaviour
{
    [SerializeField]
    private GameObject letrero;
    void OnMouseDown()
    {
        Destroy(letrero.gameObject);
    }
}
