using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ending : MonoBehaviour
{

	public Image dot;
    public void EndGame( ) {
		Application.Quit();
	}

	public void OnCollisionEnter(Collision other) {
		Debug.Log( "Collide" );

		if(other.gameObject.CompareTag("Player")) {
			Debug.Log( "Collide Collide With Player" );
			this.gameObject.GetComponent<Animator>().enabled = true;
			dot.gameObject.SetActive( false );
		}
	}
}
