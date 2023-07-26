using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LetsJump : MonoBehaviour
{
    public Text gameplayScoreTxt;
    public float jumpSpeed = 3f;
    public float jumpDelay = 2f;
    int score;
    private bool canjump;
    private bool isjumping;
    private Rigidbody rb;
    private float countDown;

    public GameObject GameOverPanel;
    public GameOverScore afficheurGameOver;

    // Start is called before the first frame update
    void Start()
    {
       gameplayScoreTxt.gameObject.SetActive(true);
        canjump = true;
        rb = GetComponent<Rigidbody>();
        countDown = jumpDelay;
    }

    // Update is called once per frame
    void Update()
    {
        float altitude = transform.position.y;
        if (altitude > score)
        {
            score = (int)altitude;
            gameplayScoreTxt.text = "Score : " + score;
        }
        if (this.transform.position.y < -6)
        {
            if(PlayerPrefs.GetInt("bestscore") < score)
            {
                PlayerPrefs.SetInt("bestscore", score);
            }
            afficheurGameOver.score = score;
            GameOverPanel.SetActive(true);
            this.gameObject.SetActive(false);
        }
        /*if (isjumping && countDown > 0)
            countDown -= Time.deltaTime;
        else
        {
            canjump = true;
            isjumping = false;
            countDown = jumpDelay;
        }*/

    }

    public void StartLetsJump()
    {
        if (canjump)
        {
            canjump = false;
            isjumping = true;
            rb.AddForce(0, jumpSpeed, 0, ForceMode.Impulse);
            //jumpSpeed += 0.1f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ZoneLancement")
        {
            canjump = true;
        }
    }

    private void OnTriggerStay (Collider other)
    {
        if (other.name == "ZoneLancement")
        {
            canjump = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canjump = false;
    }

}