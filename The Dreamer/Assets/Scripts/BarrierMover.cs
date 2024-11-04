using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierMover : MonoBehaviour
{
	public bool move;
	private float startPosY;

	private void Awake( ) {
		startPosY = transform.position.y;
	}

	void Update( ) {
		if(move) {
			Vector3 pos = transform.position;

			pos.y = Mathf.MoveTowards( pos.y, startPosY - 8,Time.deltaTime * 3 );

			transform.position = pos;
		}
	}
}
