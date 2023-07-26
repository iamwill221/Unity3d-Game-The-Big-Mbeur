using System;
using UnityEngine;

public class ZoneDetect : MonoBehaviour
{
    public bool dedans;

    public void LANCER_POIDS(float d)
    {
        base.GetComponent<Rigidbody2D>().AddForce(Vector2.up * d, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Zone")
        {
            this.dedans = true;
            GameObject.FindObjectOfType<GameControler>().dedans = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Zone")
        {
            this.dedans = false;
            GameObject.FindObjectOfType<GameControler>().dedans = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
    }

    private void Start()
    {
        base.GetComponent<Rigidbody2D>().MovePosition(new Vector2(base.transform.position.x, base.transform.position.y + 15f));
    }
}

