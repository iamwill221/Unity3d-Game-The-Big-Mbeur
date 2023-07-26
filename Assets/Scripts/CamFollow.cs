using System;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 cameraOffset;
    public float cameraSpeed = 0.1f;

    private void LateUpdate()
    {
        Vector3 b = this.player.position + this.cameraOffset;
        Vector3 vector2 = Vector3.Lerp(base.transform.position, b, this.cameraSpeed);
        base.transform.position = vector2;
    }

    private void Start()
    {
        base.transform.position = this.player.position + this.cameraOffset;
    }
}

