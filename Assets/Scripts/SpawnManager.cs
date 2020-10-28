using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    private IEnumerator coroutinePlatforms;
    private IEnumerator coroutineCollectables;
    private IEnumerator coroutineObstacles;
    public GameObject[] platformArray;
    public GameObject[] collectableArray;
    public GameObject[] obstacleArray;
    public Transform obstacleSpawnPos;
    public Transform platformSpawnPos;
    public Transform collectableSpawnPos;

    [SerializeField] private float spawnTimePlatforms;
    //[SerializeField] private float spawnTimeCollectables;
    //[SerializeField] private float spawnTimeObstacles;

    void Start()
    {
        coroutinePlatforms = SpawnPlatform(spawnTimePlatforms);
        StartCoroutine(coroutinePlatforms);

        float rdnTime = Random.Range(1.0f, 3.0f);
        coroutineCollectables = SpawnCollectables(rdnTime);
        StartCoroutine(coroutineCollectables);

        float rdnTime2 = Random.Range(5.0f, 10.0f);
        coroutineObstacles = SpawnObstacles(rdnTime2);
        StartCoroutine(coroutineObstacles);
    }

    private IEnumerator SpawnPlatform(float waitTime){
        while(true){
            // wait for seconds
            yield return new WaitForSeconds(waitTime);
            // instantiate platform
            int rdn = Random.Range(0, platformArray.Length);
            Instantiate(platformArray[rdn], platformSpawnPos);
        }
    }

    private IEnumerator SpawnCollectables(float waitTime)
    {
        while (true)
        {
            // wait for seconds
            yield return new WaitForSeconds(waitTime);
            // instantiate platform
            int rdnIndex = Random.Range(0, collectableArray.Length);
            int rdnAmount = Random.Range(1, 5);
            switch (rdnAmount)
            {
                case 1:
                    //Instantiate 1 collectable
                    Instantiate(collectableArray[rdnIndex], collectableSpawnPos.position, Quaternion.identity);
                    break;
                case 2:
                    //Instantiate 2 collectable
                    Instantiate(collectableArray[rdnIndex], collectableSpawnPos.position, Quaternion.identity);
                    Instantiate(collectableArray[rdnIndex], collectableSpawnPos.position + new Vector3(1.5f,0f,0f), Quaternion.identity);
                    break;
                case 3:
                    //Instantiate 3 collectable
                    Instantiate(collectableArray[rdnIndex], collectableSpawnPos.position, Quaternion.identity);
                    Instantiate(collectableArray[rdnIndex], collectableSpawnPos.position + new Vector3(1.5f, 0f, 0f), Quaternion.identity);
                    Instantiate(collectableArray[rdnIndex], collectableSpawnPos.position + new Vector3(3.0f, 0f, 0f), Quaternion.identity);
                    break;
                case 4:
                    //Instantiate 4 collectable
                    Instantiate(collectableArray[rdnIndex], collectableSpawnPos.position, Quaternion.identity);
                    Instantiate(collectableArray[rdnIndex], collectableSpawnPos.position + new Vector3(1.5f, 0f, 0f), Quaternion.identity);
                    Instantiate(collectableArray[rdnIndex], collectableSpawnPos.position + new Vector3(3.0f, 0f, 0f), Quaternion.identity);
                    Instantiate(collectableArray[rdnIndex], collectableSpawnPos.position + new Vector3(4.5f, 0f, 0f), Quaternion.identity);
                    break;
            } 
        }
    }

    private IEnumerator SpawnObstacles(float waitTime)
    {
        while (true)
        {
            // wait for seconds
            yield return new WaitForSeconds(waitTime);
            // instantiate obstacle
            int rdn = Random.Range(0, obstacleArray.Length);
            Instantiate(obstacleArray[rdn], obstacleSpawnPos);
        }
    }
}
