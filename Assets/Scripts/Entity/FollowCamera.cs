using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        if(target == null)
        {
            return;
        }
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        transform.position = target.position + offset;
    }
}
