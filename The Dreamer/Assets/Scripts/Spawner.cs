using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    [Header( "Spawn Settings" )]
    public float spawnInterval;
    public GameObject objectToSpawn;
    public GameObject spawnLocation;
    [HideInInspector] public GameObject spawnedObject;
    [HideInInspector] public bool puzzleDone;
    public bool collideSpawner;

    void Start( ) {
        if(!collideSpawner)
        SpawnObject();
    }

    // Update is called once per frame
    void Update( ) {
        if(transform.name == "Spawner 1") {
            puzzleDone = GameObject.FindGameObjectWithTag( "GameController" ).GetComponent<GameController>().firstPuzzle;

        }
        else if(transform.name == "Spawner 2") {
            puzzleDone = GameObject.FindGameObjectWithTag( "GameController" ).GetComponent<GameController>().secondPuzzle;

        } else if(transform.name == "Spawner 3") {
            puzzleDone = GameObject.FindGameObjectWithTag( "GameController" ).GetComponent<GameController>().thirdPuzzle;

        } else if(transform.name == "Spawner 4") {
            puzzleDone = GameObject.FindGameObjectWithTag( "GameController" ).GetComponent<GameController>().fourthPuzzle;

        }

        if(spawnedObject == null && !puzzleDone && !collideSpawner) {
            SpawnObject();
        }
    }

    public void SpawnObject( ) {
        spawnedObject = Instantiate( objectToSpawn, spawnLocation.transform );

    }
}
