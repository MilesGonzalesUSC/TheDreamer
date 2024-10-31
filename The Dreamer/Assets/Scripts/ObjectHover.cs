using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHover : MonoBehaviour
{
    public float hoverHeight;
	private float hoverMax;
	private float hoverMin;
	public float speed;
    private bool goingUp;
	
    // Start is called before the first frame update
    void Start()
    {
		hoverMax = transform.position.y + hoverHeight;
		hoverMin = transform.position.y - hoverHeight;
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 pos = transform.position;

		if(goingUp)
		{
			pos.y = Mathf.MoveTowards( pos.y, hoverMax, Time.deltaTime * speed );

		}
		if(!goingUp)
		{
			pos.y = Mathf.MoveTowards( pos.y, hoverMin, Time.deltaTime * speed );

		}

		transform.position = pos;

		if(transform.position.y == hoverMax)
			goingUp = false;

		else if(transform.position.y == hoverMin)
			goingUp = true;
	}
}
