using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int joemama = 0;
    float spawnDistance = 12f;

    float enemyRate = 10;
    float nextEnemy = 1;

    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        nextEnemy -= Time.deltaTime;

        if (nextEnemy <= 0)
        {
            nextEnemy = enemyRate;
            enemyRate *= 0.95f;


            Vector3 offset = Random.onUnitSphere;

            offset.z = 0;

            offset = offset.normalized * spawnDistance;

            Instantiate(enemyPrefab, transform.position + offset, Quaternion.identity);
        }
    }
    public void bob()
    {
        joemama += 1;
        if (joemama >= 1000)
        {
            SceneManager.LoadScene("Win");
        }
    }
}
