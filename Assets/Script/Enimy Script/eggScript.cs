using UnityEngine;

public class eggScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            //target.gameObject.SetActive(false);


        }
        gameObject.SetActive(false);
    }

}
