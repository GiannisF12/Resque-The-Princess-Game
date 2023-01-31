using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public float FollowSpeed=5;

    void LateUpdate()
    {
        transform.position = Vector3.Slerp(transform.position, new Vector3(Target.position.x, Target.position.y,-1), FollowSpeed * Time.fixedDeltaTime);
    }
}
