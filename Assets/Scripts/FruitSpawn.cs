using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawn : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoint;
    [SerializeField] GameObject[] fruitPrefab;
    [SerializeField] Rigidbody[] fruitRb;
    

    public float speed;
    public float time;
    int rand;
    int randSpawnPoint;
    float randTime;

    private void Start()
    {
        StartCoroutine(Launch());
    }

    IEnumerator Launch()
    {
        rand = Random.Range(0, fruitPrefab.Length);
        randSpawnPoint = Random.Range(0, spawnPoint.Length);
        randTime = Random.Range(1, time);
        var _obj = Instantiate(fruitPrefab[rand], spawnPoint[randSpawnPoint].position, Quaternion.identity);

        yield return new WaitForSeconds(randTime);
        StartCoroutine(Launch());
    }
}
