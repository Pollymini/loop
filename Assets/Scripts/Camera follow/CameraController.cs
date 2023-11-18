
using Unity.Netcode;
using UnityEngine;

public class CameraController : NetworkBehaviour
{
   

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        if (base.IsOwner)
        {

        Camera cam = GetComponent<Camera>();
        cam.enabled = true;

        }


    }
    

}
