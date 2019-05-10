using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Base : MonoBehaviour
{
    private const string ENEMIGO = "Enemigo";
    private int vidas = 100;
    //private Animator bas;

    private void Start()
    {
        //bas = GetComponent<Animator>();
       // bas.SetInteger("Vida_Base", 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(ENEMIGO))
        {
            
            vidas = vidas - 10;
            Debug.Log(vidas);
            //FormaBase();
            if(vidas<=0)
            {
                Destroy(this.gameObject);
            }
        }
    }
   /* void FormaBase()
    {
        if(vidas<=75 && vidas>50)
        {
            bas.SetInteger("Vida_Base", 1);

        }
       else if (vidas <= 50 && vidas >25)
        {
            bas.SetInteger("Vida_Base", 2);

        }
       else if (vidas <= 25 && vidas>10)
        {
            bas.SetInteger("Vida_Base", 3);

        }
       else if (vidas <= 10 && vidas >0)
        {
            bas.SetInteger("Vida_Base", 4);

        }
       else if(vidas<=0)
        {
            SceneManager.LoadScene("Game over");
        }
    }*/
}
