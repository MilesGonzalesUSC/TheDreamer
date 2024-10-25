using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cube : MonoBehaviour
{
    public float rotationSpeed;
	public float moveSpeed;
	public bool canPass;
	private void Awake( )
	{
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
			Debug.Log( "You Win!!!" );
			GameObject.FindGameObjectWithTag( "GameController" ).GetComponent<GameController>().gameWon = true;
			Destroy( gameObject );
			
		}
	}
}
