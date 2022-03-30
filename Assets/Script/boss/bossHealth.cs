using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossHealth : MonoBehaviour
{
    private int lifeScoreCount;
    private bool canDamage;
    private Animator anim;
    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        lifeScoreCount = 10;
        canDamage = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D target)
    {
       
        if (target.gameObject.tag == "bullet")
        {
            lifeScoreCount--;
            if (lifeScoreCount ==0)
            {
                
                GetComponent<BossScript>().deActiveBoss();
                anim.Play("bossDead");
                //gameObject.SetActive(false);
            }
            //target.gameObject.SetActive(false);
            //gameObject.SetActive(false);
        }

    }
    IEnumerator DeactiveBoss()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
