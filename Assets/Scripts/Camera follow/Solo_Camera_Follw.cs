using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Solo_Camera_Follw : MonoBehaviour
{
    public Player_Transform playerP;
  
    public Transform playerTransform;


    void Start()
    {
       
    }


        

    void Update()
    {
        playerP = GameObject.Find("Player_Holder(Clone)").GetComponent<Player_Transform>();

        playerTransform = playerP.pT;

        if (playerTransform == null)
        {
            Debug.Log("Player transform 0");
        }

        if (playerTransform != null)
        {
            transform.position = new Vector3(playerTransform.transform.position.x, playerTransform.transform.position.y, playerTransform.transform.position.z);
        }
       
    }


    
}
        
       

