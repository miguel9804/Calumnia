using System.Collections;
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
    private Transform spawn;
    private int waves = 4;
    private int contador = 0;
    private int terminar_nivel;
    [SerializeField]
    private GameObject space;
    
    void Oleada1()
    {
        GameObject temp;
        Vector3 pos_inicial = spawn.transform.position;
        Vector3 incremento = new Vector3(0, 5);
        for (int i = 0; i < 2; i++)
        {
            temp = Instantiate(enemigo1, pos_inicial + incremento, Quaternion.identity);
            pos_inicial = temp.transform.position;
            enemigos.Add(temp);
        }
    }
    void Oleada2()
    {
        GameObject temp;
        Vector3 pos_inicial = spawn.transform.position;
        Vector3 incremento = new Vector3(0, 5);
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
        Vector3 pos_inicial = spawn.transform.position;
        Vector3 incremento = new Vector3(0,5); 
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
        Vector3 pos_inicial = spawn.transform.position;
        Vector3 incremento = new Vector3(0, 5);
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

	IEnumerator spawnOleadas()
    {
        contador++;
        Debug.Log("Empieza la oleada:"+contador);


        if (contador == 1)
        {
            Oleada1();
            yield return new WaitForSeconds(2f);
        }
        else if(contador==2)
        {
            Oleada2();
            yield return new WaitForSeconds(2f);
        }
        else if(contador==3)
        {
            Oleada3();
            yield return new WaitForSeconds(2f);
        }
        else if(contador==4)
        {
            Oleada4();
            yield return new WaitForSeconds(2f);
        }
    }
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(space.gameObject);
            if(contador<=waves)
            {
                StartCoroutine(spawnOleadas());
                terminar_nivel++;
            }
            else
            {
                StopCoroutine(spawnOleadas());
                if (terminar_nivel > waves)
                {
                    SceneManager.LoadScene("Ganar");
                }
            }
            
            
        }
        
        
	}
}
