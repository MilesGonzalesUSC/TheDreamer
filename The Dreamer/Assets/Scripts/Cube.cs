using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cube : MonoBehaviour
{
	private Material BaseMaterial;
	public Material PassingMaterial;
	private Renderer Rend;
	private string baseTag;
	public float rotationSpeed;
	public float moveSpeed;
	public bool canPass;
	private void Awake( )
	{
		baseTag = gameObject.tag;
		BaseMaterial = gameObject.GetComponent<Renderer>().material;
		canPass = false;
	}
	void Update()
    {
        transform.Rotate( rotationSpeed * Time.deltaTime, rotationSpeed * Time.deltaTime, rotationSpeed * Time.deltaTime);
		Vector3 moveDirection = new Vector3(0,0,moveSpeed * Time.deltaTime);
		transform.localPosition += moveDirection;
    }


	private void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == "BadWall" && this.tag != "Passable")
		{
		Destroy( gameObject );
		}
		if(other.transform.tag == "GoodWall")
		{
			if(other.name == "PuzzleEnd1") {
				GameObject.FindGameObjectWithTag( "GameController" ).GetComponent<GameController>().firstPuzzle = true;
				GameObject.FindGameObjectWithTag( "GameController" ).GetComponent<GameController>().FairyToTower(0);

			} else if(other.name == "PuzzleEnd2") {
				GameObject.FindGameObjectWithTag( "GameController" ).GetComponent<GameController>().secondPuzzle = true;
				GameObject.FindGameObjectWithTag( "GameController" ).GetComponent<GameController>().FairyToTower( 1 );


			} else if(other.name == "PuzzleEnd3") {
				GameObject.FindGameObjectWithTag( "GameController" ).GetComponent<GameController>().thirdPuzzle = true;
				GameObject.FindGameObjectWithTag( "GameController" ).GetComponent<GameController>().FairyToTower( 2 );


			} else if(other.name == "PuzzleEnd4") {
				GameObject.FindGameObjectWithTag( "GameController" ).GetComponent<GameController>().fourthPuzzle = true;
				GameObject.FindGameObjectWithTag( "GameController" ).GetComponent<GameController>().FairyToTower( 3 );


			}
			Destroy( gameObject );
			
		}
	}
}
