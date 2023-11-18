using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Networking.Transport.Relay;
using Unity.Services.Relay.Models;
using UnityEngine;
using UnityEngine.UI;

public class TestingLobbyUI : MonoBehaviour
{
    [SerializeField] private Button createGameBtn; 
    [SerializeField] private Button joinGameBtn;

    private void Awake()
    {
        createGameBtn.onClick.AddListener(() =>
        {
            ReleyScript.instance.CreateRelay();
        });


    }
}
