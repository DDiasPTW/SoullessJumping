using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FollowPlayer : MonoBehaviour
{
    private CinemachineVirtualCamera vcam;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        vcam = GetComponent<CinemachineVirtualCamera>();
        vcam.LookAt = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        vcam.LookAt = player.transform;
    }
}
