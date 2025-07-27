using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    [SerializeField] private bool setX = false;
    [SerializeField] private bool setY = false;
    public bool cameraClamp = false;
    
    float offSetX;
    float offSetY;

    public float minX = 0f;
    public float maxX = 0f;
    public float minY = 0f;
    public float maxY = 0f;

    private void Start()
    {
        if (target == null)
        {
            Debug.LogError("Target Not Found.");
            return;
        }

        offSetX = transform.position.x - target.position.x;
        offSetY = transform.position.y - target.position.y;
    }

    private void Update()
    {
        if(target == null) return;

        Vector3 pos = transform.position;
        if (setX)
            pos.x = target.position.x + offSetX;
        if (setY)
            pos.y = target.position.y + offSetY;
        if (cameraClamp)
        {
            pos.x = Mathf.Clamp(pos.x, minX, maxX);
            pos.y = Mathf.Clamp(pos.y, minY, maxY);
        }

        transform.position = pos;
    }
}
