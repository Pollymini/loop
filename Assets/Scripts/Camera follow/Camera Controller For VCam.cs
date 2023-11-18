using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using Cinemachine;

public class CameraControllerForVCam : NetworkBehaviour
{
   
    private CinemachineVirtualCamera vcam;
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        if (!IsOwner) return;
        vcam = GetComponent<CinemachineVirtualCamera>();
        vcam.enabled = true;

    }

}
