using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehavior : MonoBehaviour {

    private const int IsometricRangePerYUnit = 100;

    void Update()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.sortingOrder = -(int)(transform.position.y * IsometricRangePerYUnit);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
