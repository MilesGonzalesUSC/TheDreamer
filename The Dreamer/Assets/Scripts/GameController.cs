using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public bool bushHover;
	[Header("Puzzle Bools")]
	public bool firstPuzzle;
	public bool secondPuzzle;
	public bool thirdPuzzle;
	public bool fourthPuzzle;
	public bool goToHeaven;

	public GameObject[] Fairies;

	public void Start( )
	{

	}


	public void FairyToTower(int fairyNumber) {
		GameObject Fairy = Fairies[fairyNumber];
		Fairy.GetComponent<Animator>().enabled = true;
	}

	public void Update( ) {
		if(firstPuzzle && secondPuzzle && thirdPuzzle && fourthPuzzle && !goToHeaven) {
			goToHeaven = true;
			for(int i = 0; i < Fairies.Length; i++) {
				GameObject currFairy = Fairies[i];
				Animator currAnim = currFairy.GetComponent<Animator>();
				currAnim.SetBool( "Go", true );
			}
		}
	}
}
