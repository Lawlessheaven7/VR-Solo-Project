using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public static EnemyMovement instance;

    [Header("Speed Control")]
    public float maxSpeed;
    public float minSpeed;

    public Vector3 movementDirection;
    public float enemySpeed;
    public bool isMoving = true;

    private void Awake()
    {
        instance= this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //Get a random Speed so enemies speed differs
        enemySpeed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            transform.Translate(movementDirection * Time.deltaTime * enemySpeed, Space.World);
        }
    }
}
