using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTextureScaling : MonoBehaviour
{
    public float maxRandX;
    public float maxRandY;
    public Material mat;
    public Vector2 randomScale;
    public Vector2 currentScale;
    public float scaleSpeed;
    void Start()
    {
        currentScale = mat.mainTextureScale;
        SetRandom();
        mat = this.gameObject.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movingScale = Vector2.Lerp( currentScale, randomScale, scaleSpeed * Time.deltaTime );
        mat.mainTextureScale = movingScale;
    }

    public void SetRandom( ) {
        randomScale = new Vector2(Random.Range(-maxRandX,maxRandX),Random.Range(-maxRandY, maxRandY));

	}
}
