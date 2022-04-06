using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sin : MonoBehaviour
{
    public  int coin ;
    public  static Sin instance;
    // Start is called before the first frame update
    void Start()
    {
        MakeSinglenton();
    }

    void MakeSinglenton()
    {
        if (instance != null)
        {
            Destroy(gameObject);

        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);


        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
   public  void SinMethod() 
    {
        print("hello this is SinMethod");
    }
    public void SinMethod2()
    {
        print("hello this is second SinMethod");
    }
}
