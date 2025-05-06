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
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();//FindObjectsOfType�� ���� ���� ��� ������Ʈ���� Obstacle�� ã�´�
        obstacleLastPosition = obstacles[0].transform.position;
        ObstacleCount = obstacles.Length;

        for(int i = 0; i < ObstacleCount; i++)
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition,ObstacleCount);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)//trigger�浹�� �浹�� ���� ������ ���ְ�, �浹ü�� ���� ������ �ش�
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
