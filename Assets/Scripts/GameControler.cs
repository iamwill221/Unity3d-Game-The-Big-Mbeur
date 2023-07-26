using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControler : MonoBehaviour
{
    public GoPoz Gp;
    public int Perfect_nbr;
    public int Lancer_Reussi_nbr;
    public float Score;
    public GameObject perdu_panel;
    public GameObject personnage;
    public GameObject LePoids;
    public GameObject milieu;
    public GameObject ReposePoids;
    private bool wait;
    public bool appuyer;
    public bool dedans;
    public float dis;
    public float stock;
    public Text dis_TXT;
    public Text perfect;
    public bool perdu;
    public bool commencer;
    public float score_int;

    public void Appui()
    {
        this.Gp.Set_Poz_Random();
        if (!this.commencer)
        {
            this.COMMENCER_JEU();
        }
        if (!this.wait)
        {
            this.ReposePoids.SetActive(false);
            this.personnage.transform.GetChild(0).gameObject.SetActive(false);
            this.personnage.transform.GetChild(1).gameObject.SetActive(true);
            this.wait = true;
            this.appuyer = true;
            GameObject.FindObjectOfType<GoPoz>().ok = true;
            base.Invoke("Dewait", 1f);
            this.Check();
        }
    }

    private void Check()
    {
        GameObject.FindObjectOfType<GoPoz>().ok = true;
        MonoBehaviour.print("ressi !");
        GoPoz component = this.LePoids.GetComponent<GoPoz>();
        component.JumpForce += 2f;
        this.Lancer_Reussi_nbr++;
    }

    private void COMMENCER_JEU()
    {
        this.commencer = true;
        GameObject.FindObjectOfType<GoPoz>().commencer = true;
        GameObject.FindObjectOfType<PoidsManager>().commencer = true;
    }

    private void Dewait()
    {
        this.personnage.transform.GetChild(0).gameObject.SetActive(true);
        this.personnage.transform.GetChild(1).gameObject.SetActive(false);
        this.wait = false;
        this.appuyer = true;
        GameObject.FindObjectOfType<GoPoz>().ok = false;
    }

    public void PERDU()
    {
        this.perdu = true;
        this.perdu_panel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Quitter()
    {
        Application.Quit();
    }

    public void Rejouer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void rtn_p_txt()
    {
    }

    public void showperfect_text()
    {
        this.Perfect_nbr++;
        MonoBehaviour.print("PERFECT !");
        this.perfect.text = "Perfect : " + ((int) this.Perfect_nbr).ToString();
    }

    private void Start()
    {
        this.Gp = GameObject.FindObjectOfType<GoPoz>();
        Time.timeScale = 1f;
        this.personnage.transform.GetChild(1).gameObject.SetActive(false);
        Application.targetFrameRate = 120;
        Screen.sleepTimeout = -1;
    }

    private void Update()
    {
        if (this.commencer && !this.perdu)
        {
            this.dis = Vector2.Distance(this.milieu.transform.position, this.LePoids.transform.position);
            if ((Mathf.FloorToInt(this.dis) * this.Lancer_Reussi_nbr) > this.score_int)
            {
                int num = Mathf.FloorToInt(this.dis) * this.Lancer_Reussi_nbr;
                this.dis_TXT.text = ((int) num).ToString() ?? "";
                this.score_int = Mathf.FloorToInt(this.dis) * this.Lancer_Reussi_nbr;
            }
            if (this.dis > this.stock)
            {
                this.stock = this.dis;
            }
        }
    }
}

