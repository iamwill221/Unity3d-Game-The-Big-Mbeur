using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScore : MonoBehaviour
{
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = "Loooooseeeeer!\r\n\r\nTon score : " + score + "\r\n Meilleur score : " + PlayerPrefs.GetInt("bestscore");
    }

    // Update is called once per frame
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
