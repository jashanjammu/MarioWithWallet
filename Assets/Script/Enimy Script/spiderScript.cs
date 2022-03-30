using System.Collections;
using UnityEngine;

public class spiderScript : MonoBehaviour
{
    private Rigidbody2D myBody;
    private Animator anim;
    private Vector3 moveDirection = Vector3.down;
    private Vector3 originPosition;
    private Vector3 moveposition;

    private bool canMove;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        originPosition = transform.position;
        originPosition.y += 6f;

        moveposition = transform.position;
        moveposition.y -= 6f;

        canMove = true;

    }
    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            transform.Translate(moveDirection * Time.smoothDeltaTime);


            if (transform.position.y >= originPosition.y)
            {
                moveDirection = Vector3.down;
                changeDirection(0.82f);
                // print("leftttttt");


            }
            else if (transform.position.y <= moveposition.y)
            {
                moveDirection = Vector3.up;
                changeDirection(-0.82f);
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
    IEnumerator deadspider(float timer)
    {
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);


    }
    void OnTriggerEnter2D(Collider2D target)
    {
        print(target);
        if (target.gameObject.tag == "bullet")
        {
           

            anim.Play("deadSpider");
            GetComponent<BoxCollider2D>().isTrigger = true;
            myBody.bodyType = RigidbodyType2D.Dynamic;
            canMove = false;
            StartCoroutine(deadspider(3f));


        }
    }

    }
