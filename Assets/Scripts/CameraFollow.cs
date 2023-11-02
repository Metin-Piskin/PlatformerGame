using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    public Vector3 offset;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(
            Player.position.x + offset.x,
            Player.position.y + offset.y,
            -10);
    }
}
