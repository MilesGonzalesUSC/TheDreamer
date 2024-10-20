using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject spawnLocation;
    [HideInInspector] public GameObject spawnedObject;
    [HideInInspector] public bool gameWon;
    void Start()
    {
        SpawnObject();    
    }

    // Update is called once per frame
    void Update()
    {
		gameWon = GameObject.FindGameObjectWithTag( "GameController" ).GetComponent<GameController>().gameWon;

		if(spawnedObject == null && !gameWon)
        {
            SpawnObject();
        }
    }

    public void SpawnObject( )
    {
       spawnedObject =  Instantiate( objectToSpawn, spawnLocation.transform );

    }
}
