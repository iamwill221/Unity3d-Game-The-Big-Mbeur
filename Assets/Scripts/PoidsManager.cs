using System;
using UnityEngine;

public class PoidsManager : MonoBehaviour
{
    private GameControler gc;
    public bool ok;
    public bool commencer;
    private GoPoz Gp;
    private bool perfect;

    private void Awake()
    {
        this.gc = GameObject.FindObjectOfType<GameControler>();
        this.Gp = base.GetComponent<GoPoz>();
    }

    private void LateUpdate()
    {
        if (this.commencer)
        {
            if (((base.transform.position.y >= -4.7f) && (base.transform.position.y <= -2.4f)) && ((base.transform.position.x >= -0.75f) && (base.transform.position.x <= 0.75f)))
            {
                this.ok = true;
                if ((((base.transform.position.y >= -4.7f) && (base.transform.position.y <= -2.4f)) && ((base.transform.position.x >= -0.15f) && (base.transform.position.x <= 0.15f))) && (!this.perfect && this.gc.commencer))
                {
                    base.Invoke("showPerfect", 0.5f);
                    MonoBehaviour.print("perfect");
                    this.perfect = true;
                }
            }
            else
            {
                this.ok = false;
            }
            this.Gp.dedans = this.ok;
        }
    }

    private void showPerfect()
    {
        this.perfect = false;
        GameObject.FindObjectOfType<GameControler>().showperfect_text();
    }

    private void Update()
    {
    }
}

