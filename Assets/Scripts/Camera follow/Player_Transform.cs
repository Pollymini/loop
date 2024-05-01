using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Transform : MonoBehaviour
{
    public Transform pT;
    void Start()
    {
        pT = gameObject.transform.GetChild(0).transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
