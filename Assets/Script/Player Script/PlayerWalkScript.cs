using UnityEngine;


public class PlayerWalkScript : MonoBehaviour
{
    public float speed = 5f;
     Rigidbody2D myBody;
    public Animator anim;
    public Transform grountCheck;
    public LayerMask groundLayer;
    private bool isGrounded;
    private bool jumped;
    private float jumpPower = 13f;

    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }
    void Start()
    {

      }

    // Update is called once per frame
    void Update()
    {
        checkIfGround();
        playJump();

    }

    void FixedUpdate()
    {
        move();
    }
    void move()
    {
       float h = Input.GetAxis("Horizontal");



        if (h > 0)
        {
            myBody.velocity = new Vector2(+speed, myBody.velocity.y);
            changeDirection(1);
        }
        else if (h < 0)
        {
            // move left side block
            myBody.velocity = new Vector2(-speed, myBody.velocity.y);
            changeDirection(- 1);
        }
        else {
            myBody.velocity = new Vector2(0f, myBody.velocity.y);
        }
        anim.SetInteger("Speed",Mathf.Abs((int)myBody.velocity.x));
    }

    void changeDirection(int backFace) 
    {
        Vector3 direction = transform.localScale;
        direction.x = backFace;
        transform.localScale = direction;

    }

    void checkIfGround() {
       
        isGrounded = Physics2D.Raycast(grountCheck.position ,Vector2.down,0.1f,groundLayer);

        if (isGrounded)
        {            
            if (jumped)
            {               
                jumped = false;
                anim.SetBool("jump" ,false);
            }
        }
    }

    void playJump()
    {
        if (isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {                
                jumped = true;
                myBody.velocity = new Vector2(myBody.velocity.x, jumpPower);
                anim.SetBool("jump",true);
               
                
            }
         }
    }
 }
