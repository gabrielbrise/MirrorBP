using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerCamera : NetworkBehaviour
{

    public Transform target;
    public Vector3 offsetPosition;

    // Update is called once per frame

    void Start()
    {
        if (isLocalPlayer)
        {
            AudioListener audio = GetComponent(typeof(AudioListener)) as AudioListener;
            audio.enabled = true;
        }
    }

    void Update()
    {
        if (transform && target)
        {
            transform.position = target.position + offsetPosition;
        }
    }
}
