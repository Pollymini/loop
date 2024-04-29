using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Solo_Camera_Follw : MonoBehaviour
{

   

  
    public Transform playerTransform;
    private void Start()
    {


        playerTransform = GameObject.Find("/Player_Holder/Player 1").transform;
        if (playerTransform == null)
        {
            Debug.Log("Player == NULL");
        }
    }

    void Update()
    {
       if(playerTransform != null)
        {
            transform.position = new Vector3(playerTransform.transform.position.x, playerTransform.transform.position.y, playerTransform.transform.position.z);
        }
        else
        {
            return;
        }
    }
    
}

