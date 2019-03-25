using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Creditos : MonoBehaviour
{
    private static int seg;

    // Update is called once per frame
    void Update()
    {
        seg = 1 + seg;
        if(seg>80)
        {
            SceneManager.LoadScene("Creditos");
        }
    }
}
