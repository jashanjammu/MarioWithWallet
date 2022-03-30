using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        //print(target.tag);
        if (target.gameObject.tag == "Player")
        {
            target.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
        else if (target.gameObject.tag == "Ground")
        {
            gameObject.SetActive(false);
        }

    }
}
