using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Transform objectToTrack;
    public Vector3 delta;


    void FixedUpdate()
    {
        transform.LookAt(objectToTrack);

        var trackedRigidbody = objectToTrack.GetComponent<Rigidbody>();
        var speed = trackedRigidbody.velocity.magnitude;

        var targetPosition = objectToTrack.position + delta * (speed + 1f);

        transform.position = Vector3.Lerp(
            transform.position, 
            targetPosition, 
            Time.smoothDeltaTime*2f);
    }
}
