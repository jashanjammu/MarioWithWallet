using System.Collections;
using UnityEngine;

public class SnailMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1.0f;
    Rigidbody2D myBody;
     Animator anim;
    private bool moveLeft;  
    public Transform downCollision;
    public LayerMask playerLayer;
    private bool canMove;
    private bool stunned;


    public Transform left_collision, right_collision, top_collision;
    private Vector3 left_collision_pos, right_collision_pos;



    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        left_collision_pos = left_collision.position;
        right_collision_pos = right_collision.position;
    }
    void Start()
    {
        moveLeft = true;
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    void move()
    {
        if ( canMove)
        {

            if (moveLeft)
            {

               myBody.velocity = new Vector2(-speed, myBody.velocity.y);

            }
            else
            {
               myBody.velocity = new Vector2(speed, myBody.velocity.y);

            }
        }
        checkCollision();
        //anim.SetInteger("Speed", Mathf.Abs((int)myBody.velocity.x));
    }

     void checkCollision()

    {
        RaycastHit2D leftHit = Physics2D.Raycast(left_collision.position,Vector2.left,0.1f,playerLayer);
        RaycastHit2D rightHit = Physics2D.Raycast(right_collision.position, Vector2.right, 0.1f, playerLayer);

        Collider2D topHit = Physics2D.OverlapCircle(top_collision.position, 0.2f, playerLayer);
        
        if (topHit != null)
        {
           
            if (topHit.gameObject.tag == "Player")
            {
               
                if (!stunned)
                {
                    topHit.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(topHit.gameObject.GetComponent<Rigidbody2D>().velocity.x,7f);
                    canMove = false;
                    myBody.velocity = new Vector2(0,0);
                    anim.Play("stunned");
                    stunned = true;

                    //BEETLE CODE
                    if (tag == "Beetle" )
                    {
                        anim.Play("stunned");
                        StartCoroutine( Dead (0.5f));
                    }
 
                }
            }
        }
       
        if (leftHit)
        {
            print("this is a left");
            if (leftHit.collider.gameObject.tag == "Player")
            {
                if (!stunned)
                {
                    //apply damage to player
                    leftHit.collider.gameObject.GetComponent<playerLife>().lifeBlock();
                }
                else
                {
                    if (tag != "Beetle")
                    {
                        myBody.velocity = new Vector2(15f, myBody.velocity.y);
                    }
                   
                }
            }
        }
        if (rightHit)

        {
            print("this is a right");
            if (rightHit.collider.gameObject.tag == "Player")
            {
                if (!stunned)
                {
                    //apply damage to player
                    rightHit.collider.gameObject.GetComponent<playerLife>().lifeBlock();
                }
                else
                {
                    if (tag != "Beetle")
                    {
                        myBody.velocity = new Vector2(15f, myBody.velocity.y);
                    }
                }


            }
        }
            if (!Physics2D.Raycast(downCollision.position, Vector2.down, 0.1f))
        {
            
            changeDirection(); 


        }
    }

    void changeDirection()
    {
        moveLeft = !moveLeft;
        Vector3 tempScale = transform.localScale;

        if (moveLeft)
        {
            tempScale.x = Mathf.Abs(tempScale.x);
            left_collision.position = left_collision_pos;
            right_collision.position = right_collision_pos;
        }
        else
        {
            
            tempScale.x = -Mathf.Abs(tempScale.x);
            left_collision.position = right_collision_pos;
            right_collision.position = left_collision_pos;
        }

        transform.localScale = tempScale;

    }

    IEnumerator Dead(float time) {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);

    }

    //private void OnCollisionEnter2D(Collision2D target)
    //{
    //    if (target.gameObject.tag == "Player")
    //    {
    //        anim.Play("stunned");
    //    }
    //}
}
