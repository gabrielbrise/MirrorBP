using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    public Transform target;
    public Vector3 offsetPosition;

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offsetPosition;
    }
}
