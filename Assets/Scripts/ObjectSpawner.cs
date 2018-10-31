using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class ObjectSpawner : MonoBehaviour {
    public GameObject[] myObj;
    GameObject go;
    int randomNumber;
    private void Start()
    {
        randomNumber = Random.Range(5, 15);
        InvokeRepeating("SpawnObject", randomNumber, randomNumber);
    }
    private void Update()
    {
        if(go != null)
            go.transform.Translate(new Vector3(-5 * Time.deltaTime, 0, 0));
    }
    private void SpawnObject()
    {
        randomNumber = Random.Range(5, 15);
        go = Instantiate(myObj[Random.Range(1, 6)],transform.position,Quaternion.identity);
    }
}
