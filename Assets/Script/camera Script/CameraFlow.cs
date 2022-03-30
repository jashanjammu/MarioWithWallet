using UnityEngine;



public class CameraFlow : MonoBehaviour
{
    // Start is called before the first frame update
    public float resetSpeed = 0.5f;
    public float cameraSpeed = 0.3f;

    public Bounds cameraBounds;
    private Transform target;

    private float offSetZ;
    private Vector3 lastTargetPosition;
    private Vector3 currentVelocity;
    private bool followPlayer;

    private void Awake()
    {
        BoxCollider2D myCol = GetComponent<BoxCollider2D>();
        myCol.size = new Vector2(Camera.main.aspect * 2f *Camera.main.orthographicSize,15f);
        cameraBounds = myCol.bounds;
    }
      void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform ;
        lastTargetPosition = target.position;
        offSetZ = (transform.position - target.position).z;
        followPlayer = true;
    }
      void FixedUpdate()
    {
        if (followPlayer)
        {
            Vector3 aheadTarrgetPos = target.position + Vector3.forward * offSetZ;

            if (aheadTarrgetPos.x >= transform.position.x)
            {
                Vector3 newCameraPosition = Vector3.SmoothDamp(transform.position,aheadTarrgetPos,ref currentVelocity,cameraSpeed);

                transform.position = new Vector3(newCameraPosition.x, transform.position.y, newCameraPosition.z);
                lastTargetPosition = target.position;
            }
        }
        
    }



}