using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    [Header( "Spwan Settings" )]
    public float spawnInterval;
    public GameObject objectToSpawn;
    public GameObject spawnLocation;
    [HideInInspector] public GameObject spawnedObject;
    [HideInInspector] public bool gameWon;
    public bool collideSpawner;

    void Start( ) {
        if(!collideSpawner)
        SpawnObject();
    }

    // Update is called once per frame
    void Update( ) {
        gameWon = GameObject.FindGameObjectWithTag( "GameController" ).GetComponent<GameController>().gameWon;

        if(spawnedObject == null && !gameWon && !collideSpawner) {
            SpawnObject();
        }
    }

    public void SpawnObject( ) {
        spawnedObject = Instantiate( objectToSpawn, spawnLocation.transform );

    }

	private void OnColliderEnter (Collision coll)
	{
		if(coll.gameObject.name == "Cube" && collideSpawner)
        {
            SpawnObject( );
        }
	}
}
