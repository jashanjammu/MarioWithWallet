using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AllArt.Solana.Nftest;
using Solnet.Rpc;

public class callNft : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Nftest test = new Nftest();
       
        

        try
        {
            SolanaRpcClient sol = new SolanaRpcClient("http://api.devent.solana.com");
            Nftest.TryGetNftData("CYYR4hFFzvvL1CusJCoNaigBfT4PPYGRvHmWrC9NcgvC",sol , true);
            
        }
        catch
        {
            print("error");
        }
    }

}

    // Update is called once per frame
//    void Update()
//    {
        
//    }
//}
