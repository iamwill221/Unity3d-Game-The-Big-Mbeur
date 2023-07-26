using UnityEngine;

public class GoPoz : MonoBehaviour
{
    public bool perdu;
    public bool commencer;
    private Rigidbody2D rb;
    public float JumpForce;
    public bool ok;
    public bool dedans;
    private GameControler gc;
    public bool monter;
    public bool descendre;
    private float x;
    public float dirX;
    private Vector2 dir = Vector2.zero;

    private void FixedUpdate()
    {
        if (this.commencer)
        {
            this.JumpForce = Mathf.Clamp(this.JumpForce, 0f, 25f);
            this.dir.x = Input.acceleration.x;
            if (this.descendre && (this.JumpForce >= 20f))
            {
                base.transform.Translate((Vector3) ((this.dir * 30f) * Time.deltaTime));
            }
        }
        if (this.rb.velocity.y < -0.1)
        {
            this.descendre = true;
            this.monter = false;
        }
        else
        {
            this.descendre = false;
            this.monter = true;
            if (this.JumpForce >= 20f)
            {
                base.gameObject.transform.position = (Vector3) new Vector2(Mathf.MoveTowards(base.transform.position.x, this.x, 0.01f), base.transform.position.y);
            }
        }
    }

    private void LateUpdate()
    {
        if (this.commencer && !this.perdu)
        {
            if (this.ok && this.dedans)
            {
                this.rb.velocity = Vector2.up * this.JumpForce;
            }
            base.transform.position = (Vector3) new Vector2(Mathf.Clamp(base.transform.position.x, -9f, 9f), base.transform.position.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            this.gc.PERDU();
            MonoBehaviour.print("il a perdu");
            this.perdu = true;
            if (Mathf.FloorToInt(this.gc.score_int) > PlayerPrefs.GetInt("meilleurscore"))
            {
                PlayerPrefs.SetInt("meilleurscore", Mathf.FloorToInt(this.gc.score_int));
            }
        }
    }

    public void Set_Poz_Random()
    {
        this.x = Random.Range(10, -10);
    }

    private void Start()
    {
        this.JumpForce = 5f;
        this.gc = GameObject.FindObjectOfType<GameControler>();
        this.rb = base.GetComponent<Rigidbody2D>();
        this.x = Random.Range(10, -10);
    }
}

