using UnityEngine;

public class ScaleBackground : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        transform.localScale = new Vector3(1,1,1);
        float width = sr.sprite.bounds.size.x;
        float height = sr.sprite.bounds.size.y;

        float worldScreenHeight = Camera.main.orthographicSize * 2f;
        float worldScreenwidth = worldScreenHeight / Screen.height * Screen.width;

        Vector3 tempScale = transform.localScale;
        tempScale.x = worldScreenwidth / width + 0.1f;
        tempScale.y = worldScreenHeight / height + 0.1f;

        transform.localScale = tempScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
