using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//script is use************
public class SpawnAsteroids : MonoBehaviour
{

    public GameObject Asteroid;
    public float spawnRate = 1000;
    public float timer = 0;
    public float heightOffset = 1;
    public float rngYPosition = 0.0f;
    public float lastNumber = 0.1f;
    public float minYChange;
    // Start is called before the first frame update
    void Start()
    {
        rngYPosition = -0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            SpawnRoid();
            timer = 0;
        }
    }

    void SpawnRoid() 
    {
        float LowestPoint = transform.position.y - heightOffset;
        float HighestPoint = transform.position.y + heightOffset;

        Instantiate(Asteroid, new Vector3(transform.position.x, Random.Range(LowestPoint, HighestPoint), 0), transform.rotation);
    }
}
