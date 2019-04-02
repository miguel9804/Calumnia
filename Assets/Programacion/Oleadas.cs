﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Oleadas : MonoBehaviour {
    public static ArrayList enemigos = new ArrayList();
    [SerializeField]
    private GameObject enemigo1;
    [SerializeField]
    private GameObject enemigo2;
    [SerializeField]
    private GameObject enemigo3;
    [SerializeField]
    private Transform spawn;
    private int waves = 5;
    private int contador = 0;
    private int terminar_nivel;
    [SerializeField]
    private GameObject space;
    
    void Oleada1()
    {
        GameObject temp;
        Vector3 pos_inicial = spawn.position;
        Vector3 incremento = new Vector3(0, -5);
        Vector3 n = new Vector3(0, -10);
        for(int i=0;i<2;i++)
        {
            temp = Instantiate(enemigo1, pos_inicial + incremento, Quaternion.identity);
            pos_inicial = temp.transform.position;
            enemigos.Add(temp);
        }
            
        
    }
    void Oleada2()
    {
        GameObject temp;
        Vector3 pos_inicial = spawn.position;
        Vector3 incremento = new Vector3(0, -5);
        for (int i = 0; i < 4; i++)
        {
            temp = Instantiate(enemigo1, pos_inicial + incremento, Quaternion.identity);
            pos_inicial = temp.transform.position;
            enemigos.Add(temp);
        }
    }
    void Oleada3()
    {
        GameObject temp;
        GameObject temp2;
        Vector3 pos_inicial = spawn.position;
        Vector3 incremento = new Vector3(0,-5); 
        for(int i =0; i<4;i++)
        {
            temp = Instantiate(enemigo1, pos_inicial + incremento, Quaternion.identity);
            pos_inicial = temp.transform.position;
            enemigos.Add(temp);
            if (i>=2)
            {
                temp2 = Instantiate(enemigo2, pos_inicial + incremento, Quaternion.identity);
                pos_inicial = temp2.transform.position;
                enemigos.Add(temp2);
            }

        }

    }
    void Oleada4()
    {
        GameObject temp;
        GameObject temp2;
        Vector3 pos_inicial = spawn.position;
        Vector3 incremento = new Vector3(0, -5);
        for (int i = 0; i < 6; i++)
        {
            temp = Instantiate(enemigo1, pos_inicial + incremento, Quaternion.identity);
            pos_inicial = temp.transform.position;
            enemigos.Add(temp);
            if (i >= 3)
            {
                temp2 = Instantiate(enemigo2, pos_inicial + incremento, Quaternion.identity);
                pos_inicial = temp2.transform.position;
                enemigos.Add(temp2);
            }

        }

    }
    void Oleada5()
    {
        GameObject temp;
        GameObject temp2;
        GameObject temp3;
        Vector3 pos_inicial = spawn.position;
        Vector3 incremento = new Vector3(0, -5);
        for (int i = 0; i < 4; i++)
        {
            temp = Instantiate(enemigo1, pos_inicial + incremento, Quaternion.identity);
            pos_inicial = temp.transform.position;
            enemigos.Add(temp);
            if (i >= 2)
            {
                temp2 = Instantiate(enemigo2, pos_inicial + incremento, Quaternion.identity);
                pos_inicial = temp2.transform.position;
                enemigos.Add(temp2);
                
            }
            if (i == 3)
            {
                temp3 = Instantiate(enemigo3, pos_inicial + incremento, Quaternion.identity);
                pos_inicial = temp3.transform.position;
                enemigos.Add(temp3);
            }


        }

    }



    // Update is called once per frame
    void Update () {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            contador++;
            terminar_nivel++;
            Debug.Log(contador);
            Destroy(space.gameObject);
            if (contador == 1)
            {
                Oleada1();
                
            }
            else if (contador == 2)
            {
                Oleada2();
                
            }
            else if (contador == 3)
            {
                Oleada3();
                
            }
            else if (contador == 4)
            {
                Oleada4();
                
            }
            else if ( contador==5)
            {
                Oleada5();
            }
             if (terminar_nivel > waves)
             {
                    SceneManager.LoadScene("Ganar");
             }
            
            
            
        }
        
        
	}
}
