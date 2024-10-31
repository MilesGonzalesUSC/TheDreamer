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

		if(gameObject.gameObject.tag == "Passable") {
			IFrames();
		}
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

	IEnumerator IFrames() {
		gameObject.tag = "Passable";
		yield return new WaitForSeconds(1f);
		Rend.material = BaseMaterial;
		gameObject.tag = baseTag;
	}
}
