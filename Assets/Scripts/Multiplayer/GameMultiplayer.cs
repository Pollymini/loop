using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class GameMultiplayer : NetworkBehaviour
{
    public static GameMultiplayer Instance;

    private void Awake()
    {
         Instance = this;
    }
}
