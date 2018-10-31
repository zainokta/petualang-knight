using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour {
    private float xSpeed = 0.3f;
    public Material mat;
    Vector2 offset = Vector2.zero;
	// Use this for initialization
	void Start () {
        mat = GetComponent<MeshRenderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
        offset.x += xSpeed * Time.deltaTime;
        if (offset.x > 1f)
            offset.x -= 1f;
        else if (offset.x < -1f)
            offset.x += 1f;
        mat.mainTextureOffset = offset;
	}
}
