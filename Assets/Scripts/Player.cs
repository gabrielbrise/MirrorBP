using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : NetworkBehaviour
{
    public Camera playerCamera;
    private Camera followPlayerCamera;

    void Start()
    {
        if (isLocalPlayer)
        {
            followPlayerCamera = Instantiate(playerCamera);
            PlayerCamera cameraScript = followPlayerCamera.GetComponent(typeof(PlayerCamera)) as PlayerCamera;

            if (cameraScript)
            {
                cameraScript.target = transform;
            }
        }
    }

    void HandleMovement()
    {
        if (isLocalPlayer)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal * 0.1f, 0, moveVertical * 0.1f);
            transform.position = transform.position + movement;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 1);
        }
    }

    void Update()
    {
        HandleMovement();
    }

    void OnDestroy()
    {
        Destroy(followPlayerCamera);
    }
}
