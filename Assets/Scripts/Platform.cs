using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    // init 1,2,3,4
    // float 1,6546 , 2,9654 , 3,546
    // bounds= sýnýrlar
    public Vector3 ReturnEndPoint()
    {
        Vector3 calculatedEndPoint;
        calculatedEndPoint.x= spriteRenderer.bounds.size.x + this.transform.position.x
            + Random.Range(0f,3f);
        calculatedEndPoint.y = Random.Range(0f,3f);
        calculatedEndPoint.z = 0;
        return calculatedEndPoint;
    }
}
