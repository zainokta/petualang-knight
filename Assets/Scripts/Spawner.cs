using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;
public class Spawner : MonoBehaviour {
    private float duration;
    private static float addHP;
    private GameObject enemy;
    
    private void Start()
    {
        enemy = Resources.Load("Enemy") as GameObject;
        StartCoroutine(SpawnEnemies());
    }
    private void Update()
    {
        if(GameManager.instance.fading == true)
        {
            StopAllCoroutines();
        }
    }
    IEnumerator SpawnEnemies()
    {
        duration = Random.Range(2, 10);
        Instantiate(enemy, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(duration);
        addHP += 3;
        enemy.GetComponent<EnemyScript>().enemyHp += (int)addHP;
        StartCoroutine(SpawnEnemies());
    }
}
