using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningScript : MonoBehaviour
{
    public GameObject[] cubes;
    public int cubeCounter = 1;
    public Transform[] spawnpoints;
    private float[] rotation = { 0f, 90f, 180f, 270f };
    private float[] spawninterval = { 1f, .5f, 1.7f, 1.4f, 5f, 3f, 2.2f };
    public string difficulty;

    private void Start()
    {
        StartCoroutine(CubeSpawner());
    }

    
    // Update is called once per frame
    void Update()
    {
        /* Just for Testing
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopAllCoroutines();
        }*/
    }

    private void SpawnCube()
    {
        GameObject newCube = Instantiate(cubes[Random.Range(0, cubes.Length)], spawnpoints[Random.Range(0, spawnpoints.Length)].position, Quaternion.identity);
        newCube.transform.Rotate(Vector3.forward, rotation[Random.Range(0, rotation.Length)]);
        newCube.name = ("Cube " + cubeCounter);
        cubeCounter++;
    }

    IEnumerator CubeSpawner()
    {
        while (true == true)
        {
            SpawnCube();
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator CubeSpawnerWithInterval()
    {
        foreach(float i in spawninterval)
        {
            SpawnCube();
            yield return new WaitForSeconds(i);
        }
    }
}
