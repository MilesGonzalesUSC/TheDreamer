using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushMove : MonoBehaviour
{
	private bool canHover;
	private GameController gameController;
	private float startPosY;
	private float endPosY;
	public float speed;
	public float maxY;
	private bool goingToEnd;
	public void Start( )
	{
		goingToEnd = true;
		SetEndPos();
		startPosY = transform.position.y;
		gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}

	public void Update( )
	{
		canHover = gameController.bushHover;

		if(canHover)
		{
			OnHover();
		}
	}

	public void OnHover( ) {
		Vector3 pos = transform.position;

		if(goingToEnd)
		{
			pos.y = Mathf.MoveTowards(pos.y,endPosY,Time.deltaTime * speed);

		}
		if(!goingToEnd) {
			pos.y = Mathf.MoveTowards( pos.y,startPosY,Time.deltaTime * speed );

		}

		transform.position = pos;

		if(transform.position.y == endPosY)
			goingToEnd = false;

			else if(transform.position.y == startPosY) 
			goingToEnd=true;
	}

	public void SetEndPos( )
	{
		endPosY = Random.Range( 0.005f, maxY );
	}
}
