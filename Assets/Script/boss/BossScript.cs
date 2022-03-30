using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public GameObject stone;
    public Transform attack;

    public Animator anim;
    private string corutine_Name = "startAttack";
    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();

    }
    void Start()
    {
        StartCoroutine(corutine_Name);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Attack()
    {
        GameObject obj = Instantiate(stone, attack.position, Quaternion.identity);
       
        // stone.GetComponent<FireBullet>().Speed *= transform.localScale.x;
         obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-300f,-700),0f));
       
       
    }
    void backToIdel()
    {
        anim.Play("bossStand");
    }

    public void deActiveBoss()
    {
        StopCoroutine(corutine_Name);
        enabled = false;
        
    }
    IEnumerator startAttack()
    {
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        anim.Play("bossAttack");
        StartCoroutine(corutine_Name);

    }
}
