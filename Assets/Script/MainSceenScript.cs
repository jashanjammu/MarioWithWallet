using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceenScript : MonoBehaviour
{
    public static MainSceenScript instance;
    // Start is called before the first frame update
    void Start()
    {
        print("this is second sceen" + Sin.instance.coin);

    }

   

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainScriptMethod()
    {
        print("this is a main Script method");
    }
}
