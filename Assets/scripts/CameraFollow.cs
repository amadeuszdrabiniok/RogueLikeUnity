using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float verticalOffset;
    public float lowerLimit;
    public float speed;

    
    void Update()
    {
        if (target.position.y > lowerLimit)
        {
            //If the camera is above the lower limit this will move the camera from its current position to that of the target a small step at a time. This can be adjusted by changing the value of speed
            transform.localPosition = Vector3.Lerp(new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), new Vector3(target.position.x, target.position.y + verticalOffset, transform.localPosition.z), speed);
        }
        else
        {
            //Similar to the lerp above this will make sure that the camera is move toward the player position however it will not allow the camera to go below a certain amount, this can be changed to fit your games needs.
            transform.localPosition = Vector3.Lerp(new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), new Vector3(target.position.x, lowerLimit + verticalOffset, transform.localPosition.z), speed);
        }

    }
}