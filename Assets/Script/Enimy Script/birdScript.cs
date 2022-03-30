using System.Collections;
using UnityEngine;

public class birdScript : MonoBehaviour
{
    private Rigidbody2D myBody;
    private Animator anim;
    private Vector3 moveDirection = Vector3.left;
    private Vector3 originPosition;
    private Vector3 moveposition;

    public GameObject birdEgg;
    public LayerMask playerLayer;
    private bool attacked;
    private bool canMove;

    private bool birdeCheck;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        originPosition = transform.position;
        originPosition.x += 6f;

        moveposition = transform.position;
        moveposition.x -= 6f;

        canMove = true;
      
    }

    // Update is called once per frame
    void Update()
    {
       
        moveBird();
        dropEgg();
       
    }

    void moveBird()
    {

        if (canMove)
        {
            transform.Translate(moveDirection * Time.smoothDeltaTime);
            

            if (transform.position.x >= originPosition.x)
            {
                moveDirection = Vector3.left;
                changeDirection(0.92f);
               // print("leftttttt");


            }
           else if (transform.position.x <= moveposition.x)
            {
                moveDirection = Vector3.right;
                changeDirection(-0.92f);
               // print("reftttttt");
            }

        }
    }
    void changeDirection(float direction)
    {
       
        Vector3 tempScale = transform.localScale;
        tempScale.y = direction;
        transform.localScale = tempScale;
    }

    void dropEgg()
    {
        if (!attacked)
        {
            if (Physics2D.Raycast(transform.position,Vector2.down,Mathf.Infinity,playerLayer))
            {
                Instantiate(birdEgg, new Vector3(transform.position.x,transform.position.y -1f,transform.position.z),Quaternion.identity);
                attacked = true;
                anim.Play("birdFly");
                birdeCheck = true;
                if (birdeCheck)
                {
                    StartCoroutine(ReplayBird(0.9f));

                }

                



            }
        }
    }
    IEnumerator ReplayBird(float timer)
    {
        yield return new WaitForSeconds(timer);
        anim.Play("bird");
        attacked = false;
    }
    IEnumerator deadBird(float timer)
    {
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);
        
        
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "bullet")
        {
            
            anim.Play("birdDead");
            GetComponent<BoxCollider2D>().isTrigger = true;
            myBody.bodyType = RigidbodyType2D.Dynamic;
            canMove = false;
            StartCoroutine(deadBird(3f));
           

        }
    }
}
