using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialAnimScript : MonoBehaviour
{
    private Animator anim;

    public GameObject barrier;
    // Start is called before the first frame update
    void Start()
    {
        anim = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void MoveBarrier( ) {
        barrier.GetComponent<BarrierMover>().move = true;
	}
}
