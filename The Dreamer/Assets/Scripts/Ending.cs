using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ending : MonoBehaviour
{

	[SerializeField] private AudioSource mainLoop = null;
	[SerializeField] private AudioSource heavenMusic = null;

	public Image dot;
    public void EndGame( ) {
		Application.Quit();
	}

	public void OnCollisionEnter(Collision other) {
		Debug.Log( "Collide" );

		StartCoroutine(FadeTrack());

		if(other.gameObject.CompareTag("Player")) {
			Debug.Log( "Collide Collide With Player" );
			this.gameObject.GetComponent<Animator>().enabled = true;
			dot.gameObject.SetActive( false );
		}
	}

	private IEnumerator FadeTrack()
    {
		float timeToFade = 1f;
		float timeElapsed = 0;

		heavenMusic.Play();

		while (timeElapsed < timeToFade)
        {
			heavenMusic.volume = Mathf.Lerp(0, 1, timeElapsed / timeToFade);
			mainLoop.volume = Mathf.Lerp(1, 0, timeElapsed / timeToFade);
			timeElapsed += Time.deltaTime;
			yield return null;
        }
		mainLoop.Stop();
	}
}
