using System.Collections;
using UnityEngine;
//using UnityEngine.UIElements;

public class FireBullet : MonoBehaviour
{
    //public TextAsset customText;
    public Animator anim;
    private float speed = 10f;
    private bool canMove;
    // Start is called before the first frame update

    // geter and setter method
    private void Awake()
    {
        anim = GetComponent<Animator>();
        canMove = true;
    }
    void Start()
    {
        //bulletDisable(5f);


    }
    void Update()
    {
        Move();
    }
    void Move()
    {
        if (canMove)
        {
            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;
            transform.position = temp;
        }
       
    }
    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }

    IEnumerator bulletDisable(float timer)
    {
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);
        
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if ( target.gameObject.tag == "snail" ||target.gameObject.tag == "Beetle" )
        {
           
            gameObject.SetActive(true);
            anim.Play("exploid");
            canMove = false;
            if (!canMove)
            {
                print("hit with object");
                target.gameObject.SetActive(false);

            }
          
           StartCoroutine(bulletDisable(0.9f));

        }
    }
}
