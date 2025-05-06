using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int numBgCount = 5;
    public int ObstacleCount = 0;
    public Vector3 obstacleLastPosition = Vector3.zero;
    void Start()
    {
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();//FindObjectsOfType은 게임 내에 모든 오브젝트에서 Obstacle를 찾는다
        obstacleLastPosition = obstacles[0].transform.position;
        ObstacleCount = obstacles.Length;

        for(int i = 0; i < ObstacleCount; i++)
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition,ObstacleCount);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)//trigger충돌은 충돌에 대한 정보는 못주고, 충돌체에 대한 정보만 준다
    {
        if (collision.CompareTag("BackGround"))
        {
            float widthOFBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            pos.x += widthOFBgObject * numBgCount;
            collision.transform.position = pos;
            return;
        }
        Obstacle obstacle = collision.GetComponent<Obstacle>();
        if (obstacle)
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, ObstacleCount);
        }
    }
}
