using System;
using System.Collections.Generic;
using UnityEngine;

public class FollowTwoObject : MonoBehaviour
{
    public List<Transform> targets;
    public Vector3 offset;
    public float smoothTime = 0.5f;
    public float speed = 1f;
    public float maxZoom = 40f;
    public float minZoom = 10f;
    public float zoomLimiter = 50f;
    private Vector3 velocity;
    private Camera cam;

    private Vector3 GetCenterPoint()
    {
        if (this.targets.Count == 1)
        {
            return this.targets[0].position;
        }
        Bounds bounds = new Bounds(this.targets[0].position, Vector3.zero);
        for (int i = 0; i < this.targets.Count; i++)
        {
            bounds.Encapsulate(this.targets[i].position);
        }
        return bounds.center;
    }

    private float GetGreatestDistance()
    {
        Bounds bounds = new Bounds(this.targets[0].position, Vector3.zero);
        for (int i = 0; i < this.targets.Count; i++)
        {
            bounds.Encapsulate(this.targets[i].position);
        }
        return bounds.size.y;
    }

    private void LateUpdate()
    {
        if (this.targets.Count != 0)
        {
            this.Move();
            this.Zoom();
        }
    }

    private void Move()
    {
        Vector3 target = this.GetCenterPoint() + this.offset;
        base.transform.position = Vector3.SmoothDamp(base.transform.position, target, ref this.velocity, this.smoothTime * this.speed);
    }

    private void Start()
    {
        this.cam = base.GetComponent<Camera>();
    }

    private void Zoom()
    {
        float b = Mathf.Lerp(this.minZoom, this.maxZoom, this.GetGreatestDistance() / this.zoomLimiter);
        this.cam.orthographicSize = Mathf.Lerp(this.cam.orthographicSize, b, Time.deltaTime);
    }
}

