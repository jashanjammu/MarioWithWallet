
using UnityEngine;
using UnityEngine.UI;



public class ScoreCountScript : MonoBehaviour
{

    public Text coinCount;
    private int coin;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void coinCollector() {
        coin++;
        coinCount.text = " x" + coin;
    }
    void OnTriggerEnter2D(Collider2D target)
    { 
        if (target.gameObject.tag == "coin")
        {
            coinCollector();
            target.gameObject.SetActive(false);
        }
    }
}
