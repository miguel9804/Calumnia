using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Creditos : MonoBehaviour
{
    private static float seg;

    // Update is called once per frame
    void Update()
    {
        seg += 1f * Time.deltaTime;
        if(seg>5f)
        {
            SceneManager.LoadScene("Creditos");
        }
    }
}
