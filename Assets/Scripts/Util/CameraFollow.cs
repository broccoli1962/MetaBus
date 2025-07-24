using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float maxX = 0f;
    public float maxY = 0f;

    private void Start()
    {
        if (target == null)
        {
            Debug.LogError("Target Not Found.");
            return;
        }
    }

    private void Update()
    {
        if(target == null) return;

        Vector3 pos = transform.position;
        pos.x = target.position.x;
        pos.y = target.position.y;
        transform.position = pos;
    }
}
