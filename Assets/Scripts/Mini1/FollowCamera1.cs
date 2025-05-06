using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera1 : MonoBehaviour
{
    public Transform target;
    float offsetX;
    void Start()
    {
        if(target == null)
            return;

        offsetX = transform.position.x - target.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
            return;

        Vector3 pos = transform.position;//transform.position에 변동을 줄때는 항상 변수에 한번 저장하고 변동주기
        pos.x = target.position.x + offsetX;
        transform.position = pos;
    }
}
