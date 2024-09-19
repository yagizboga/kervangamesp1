using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform _code;
    [SerializeField] private Transform _blade;

    CinemachineVirtualCamera virtualCamera;


    private void Awake() {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();   
    }

    private void Update() 
    {
        if (_code.transform.position.x > _blade.transform.position.x)
        {
            FollowPlayer(_code);
        }
        if (_code.transform.position.x < _blade.transform.position.x)
        {
            FollowPlayer(_blade);
        }
    }

    private void FollowPlayer(Transform player)
    {
        player.rotation = Quaternion.Euler(0, 0, 0);
        virtualCamera.Follow = player;
    }
}
