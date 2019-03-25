using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {



    private void cargaNivel(string nombreNivel)
    {
        
        SceneManager.LoadScene(nombreNivel);
    }
}
