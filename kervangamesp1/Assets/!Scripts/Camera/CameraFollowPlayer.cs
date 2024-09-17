using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _code;
    [SerializeField] private GameObject _blade;

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

    private void FollowPlayer(GameObject player)
    {
        virtualCamera.Follow = player.transform;
    }
}
