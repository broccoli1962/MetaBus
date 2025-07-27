using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaicleControl : MonoBehaviour
{
    Vector3 obstacleLastPosition = Vector3.zero;
    float backGroundCount = 5;

    private void Start()
    {
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();
        obstacleLastPosition = obstacles[0].transform.position;
        
        for(int i = 0; i< obstacles.Length; i++)
        {
            obstacleLastPosition = obstacles[i].SetObstacle(obstacleLastPosition);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BackGround"))
        {
            float backGroundwidth = ((BoxCollider2D)collision).size.x;
            Vector3 backPos = collision.transform.position;

            backPos.x += backGroundwidth * backGroundCount;
            collision.transform.position = backPos;
            return;
        }

        Obstacle obstacle = collision.GetComponent<Obstacle>();
        if (obstacle != null) {
            obstacleLastPosition = obstacle.SetObstacle(obstacleLastPosition);
        }
    }
}
