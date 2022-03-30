using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxCollector : MonoBehaviour
{
    public Transform Bottom_Collision;
    public LayerMask playerLayer;

    private Animator anim;
    private Vector3 moveDirection = Vector3.up;
    private Vector3 originPosition;
    private Vector3 animPosition;
    private bool startAnim;
    private int count;
    // public int test;
    // Start is called be
    // fore the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        originPosition = transform.position;
        
        animPosition = transform.position;
       
        animPosition.y += 0.15f;
        int count = 0;

    }

    // Update is called once per frame
    void Update()
    {
        CheckForCollision();
        animationUpDown();


    }

    void CheckForCollision()
    {
        RaycastHit2D hit = Physics2D.Raycast(Bottom_Collision.position, Vector2.down, 0.1f, playerLayer);
        if (hit)
        {
            if (hit.collider.gameObject.tag == "Player")
            {

                if (count == 0)
                {
                    anim.Play("CoinIdelBox");
                    startAnim = true;
                    count++;
                }
            }
        }
    }
    void animationUpDown()
    {
        if (startAnim)
        {
            transform.Translate(moveDirection * Time.smoothDeltaTime);
           
        }
        if (transform.position.y >= animPosition.y)
        {
            
           
              moveDirection = Vector3.down;
                 

           
        }
        else if (transform.position.y <= originPosition.y)
        {
            startAnim = false;
        }
    
    }
}
