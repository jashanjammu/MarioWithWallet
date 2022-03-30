using System.Collections;
using UnityEngine;

public class frogScript : MonoBehaviour
{
    private Animator anim;
    private bool animation_Started;
    private bool animation_finished;

    private int jumpTimes;
    private bool jumpLeft = true;

     private string coroutine_Name = "frogJump";

    private void Awake()
    {
        anim = GetComponent<Animator>();

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator frogJump()
    {
        
        yield return new WaitForSeconds(Random.Range(1f,7f));
        if (jumpLeft)
        {
            anim.Play("frogLeft");
             //anim.SetBool("value", true);
           
        }
        else 
        { 
            
        }
        StartCoroutine(frogJump());
            
    
    }
    void animationFinished() {

        anim.Play("idelLeft");
       
       StartCoroutine(frogJump());



    }

     
}
