using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    Transform target;
    [SerializeField] float minX = 1;
    [SerializeField] float maxX = 1;
    [SerializeField] float minY = 1;
    [SerializeField] float maxY = 1;
    Transform t;

    private void Awake()
    {
        target = GetComponentInParent<Transform>();
        t = transform;
    }

    void LateUpdate()
    {
        float x = Mathf.Clamp(target.position.x, minX, maxX);
        float y = Mathf.Clamp(target.position.y, minY, maxY);
        t.position = new Vector3(x, y, transform.position.z);
    }
}
