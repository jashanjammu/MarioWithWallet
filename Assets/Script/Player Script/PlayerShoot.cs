using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject fireBullet;
    private void Awake()
    {
       

    }
    void Update()
    {
        ShootBullet();
    }
    void ShootBullet()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
           
            GameObject bullet = Instantiate(fireBullet, transform.position, Quaternion.identity);
            bullet.GetComponent<FireBullet>().Speed *= transform.localScale.x; 
          
        }
    }
}
