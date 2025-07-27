using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float highY = 1f;
    public float lowY = -1f;

    public float holeSizeMin = 1f;
    public float holeSizeMax = 3f;

    public float padding = 4f;

    public Transform top;
    public Transform bottom;

    FlappyManager flappyManager;

    public void Start()
    {
         flappyManager = FlappyManager.Instance;
    }

    public Vector3 SetObstacle(Vector3 position)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float middle = holeSize / 2;

        top.localPosition = new Vector3(0, middle);
        bottom.localPosition = new Vector3(0, -middle);

        Vector3 rPosition = position + new Vector3(padding, 0, 0);
        rPosition.y = Random.Range(lowY, highY);

        transform.position = rPosition;

        return rPosition;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        FlappyController player = collision.GetComponent<FlappyController>();
        if (player != null)
        {
            flappyManager.AddScore(1);
        }
    }

}
