using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Size of the spawner")]
    public Vector3 spawnerSize;
    public Color Color;

    [Header("Spawnning Rate")]
    public float spawnRate = 1f;

    [Header("Models to Spawn")]
    public GameObject[] Enemies;

    private float timerOfSpawn = 0;

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.currentGamestatus == GameManager.gameStates.playing)
        {
            //Allow timer to increase based on real time
            timerOfSpawn += Time.deltaTime;

            //If timer reach the spawnrate then excute the codes
            if (timerOfSpawn > spawnRate)
            {
                Debug.Log("Spawning");
                spawnEnemy();

                //Reset the timer back to 0
                timerOfSpawn = 0;
            }
        }
    }

    public void spawnEnemy()
    {
        //Pick a random position inside of the Gizmo for Enemy to spawn
        Vector3 spawnPoint = transform.position + new Vector3(Random.Range(-spawnerSize.x / 2, spawnerSize.x / 2), 
                                                              Random.Range(-spawnerSize.y / 2, spawnerSize.y / 2),
                                                              Random.Range(-spawnerSize.z / 2, spawnerSize.z / 2));

        GameObject enemy = Instantiate(Enemies[Random.Range(0, Enemies.Length)], spawnPoint, transform.rotation);

        //put all enemies inside of the spawner 
        enemy.transform.SetParent(this.transform);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color;
        Gizmos.DrawCube(transform.position, spawnerSize);
    }
}
