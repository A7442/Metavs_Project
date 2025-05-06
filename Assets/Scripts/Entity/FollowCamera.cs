using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FollowCamera : MonoBehaviour
{
    public Transform target;

    private Vector3 offset;

    private float smoothSpeed = 6.0f;

    public Tilemap tilemap;

    private Vector2 minBound;

    private Vector2 maxBound;
    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
        {
            return;
        }
        offset = transform.position - target.position;

        Bounds bounds = tilemap.localBounds;
        minBound = new Vector2(bounds.min.x + 10.9f, bounds.min.y + 5.8f);
        maxBound = new Vector2(bounds.max.x - 9.9f, bounds.max.y - 5.8f);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target == null)
        {
            return;
        }
        Vector3 desiredPosition = target.position + offset;

        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minBound.x, maxBound.x);
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, minBound.y, maxBound.y);

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
    }
}
