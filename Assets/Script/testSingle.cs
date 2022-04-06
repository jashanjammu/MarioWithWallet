using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class testSingle : MonoBehaviour
{
   // private Sin ssin;  this is a instance
    // Start is called before the first frame update
    void Start()
    {
        Sin.instance.coin = 3;
        print("this is first sceen" + Sin.instance.coin);
      //  Invoke("loadScreen",3f);

        //ssin = GameObject.Find("testSingleton").GetComponent<Sin>(); //ssin is a instance which declare on top second war to Access a mothed pf another class;
        //ssin.SinMethod();
        //ssin.SinMethod2();

        //GameObject.Find("testSingleton").GetComponent<Sin>().SinMethod(); //first way in this no need to create a instance

        // by  using a singletons 
        Sin.instance.SinMethod();
       // MainSceenScript.instance.MainScriptMethod();

    }
    void loadScreen()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
