using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WalletScreenScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void loadScreen()
    {
        SceneManager.LoadScene("wallet_scene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
