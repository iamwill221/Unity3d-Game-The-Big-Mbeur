using System;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public Camera La_Camera;
    public RectTransform Le_Poids;
    public float Le_Poids_max_Y;
    public Vector3 Le_Poids_minimum_size;
    public float La_Camera_max_Y;
    public float La_Camera_Fview;
    private float initial_y;
    private float initial_Fvieuw;
    private float initial_Poids_Y;
    private Vector3 initial_Poids_size;
    public bool zoom;
    public float speed;

    private void Start()
    {
        this.initial_y = base.transform.position.y;
        this.initial_Fvieuw = this.La_Camera.orthographicSize;
        this.initial_Poids_size = this.Le_Poids.localScale;
        this.initial_Poids_Y = this.Le_Poids.localPosition.y;
    }

    private void Update()
    {
        if (this.zoom)
        {
            base.transform.position = (Vector3) Vector2.MoveTowards(base.transform.position, new Vector2(base.transform.position.x, this.La_Camera_max_Y), this.speed * Time.deltaTime);
            this.La_Camera.orthographicSize = Mathf.MoveTowards(this.La_Camera.orthographicSize, this.La_Camera_Fview, this.speed * Time.deltaTime);
            this.Le_Poids.localScale = Vector3.MoveTowards(this.Le_Poids.localScale, this.Le_Poids_minimum_size, this.speed * Time.deltaTime);
            this.Le_Poids.localPosition = Vector3.MoveTowards(this.Le_Poids.localPosition, new Vector3(this.Le_Poids.localPosition.x, this.Le_Poids_max_Y, this.Le_Poids.localPosition.z), this.speed * Time.deltaTime);
        }
        else
        {
            base.transform.position = (Vector3) Vector2.MoveTowards(base.transform.position, new Vector2(base.transform.position.x, this.initial_y), this.speed * Time.deltaTime);
            this.La_Camera.orthographicSize = Mathf.MoveTowards(this.La_Camera.orthographicSize, this.initial_Fvieuw, this.speed * Time.deltaTime);
            this.Le_Poids.localPosition = Vector3.MoveTowards(this.Le_Poids.localPosition, new Vector3(this.Le_Poids.localPosition.x, this.initial_Poids_Y, this.Le_Poids.localPosition.z), this.speed * Time.deltaTime);
            this.Le_Poids.localScale = Vector3.MoveTowards(this.Le_Poids.localScale, this.initial_Poids_size, this.speed * Time.deltaTime);
        }
    }
}

