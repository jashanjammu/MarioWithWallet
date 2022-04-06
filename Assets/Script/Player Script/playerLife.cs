using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerLife : MonoBehaviour
{
    public Text PlayerLife;
    private int lifeScoreCount;
    private bool canDamage;
    // Start is called before the first frame update
    void Start()
    {
       
        lifeScoreCount = 3;
        PlayerLife.text = " x" + lifeScoreCount;
        canDamage = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void lifeBlock() 
    {
       // print("your life score assigned-------" + lifeScoreCount);
        lifeScoreCount--;
        print("your life score left"+lifeScoreCount);

        if (lifeScoreCount >=0)
        {
           PlayerLife.text= "x" + lifeScoreCount;
        }

        if (lifeScoreCount == 0)
        { 
            // restart the game
        }

        canDamage = false;
        StartCoroutine(waitForSecond());


    }
    IEnumerator waitForSecond()
    {
        yield return new WaitForSeconds(2f);
        canDamage = true;
    }

}
