using UnityEngine;
using Cinemachine;
using Unity.Netcode;

public class FollowPlayer : NetworkBehaviour
{
    public GameObject tPlayer;
    public Transform tFollowTarget;
    private CinemachineVirtualCamera vcam;

    // Use this for initialization

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        CinemachineVirtualCamera vcam = GetComponent<CinemachineVirtualCamera>();

    }

    // Update is called once per frame
    void Update()
    {
        if (tPlayer == null)
        {
            tPlayer = GameObject.FindWithTag("Player");
            if (tPlayer != null)
            {
               
               
            }
        }
    }
}