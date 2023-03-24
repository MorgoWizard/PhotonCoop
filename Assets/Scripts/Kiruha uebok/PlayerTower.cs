using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerTower : MonoBehaviourPunCallbacks
{
    private Camera mainCamera;
    private PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (view.IsMine)
        {
            Vector3 diff = mainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            diff.Normalize();

            float rotationZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg - 90f;
            
            transform.rotation = Quaternion.Euler(0f,0f,rotationZ);
        }
    }
}