using System;
using UnityEngine;
using UnityEngine.UI;

public class HomeControler : MonoBehaviour
{

    private void Start()
    {
        GetComponent<Text>().text = "Meilleur Score : \n" + ((int) PlayerPrefs.GetInt("meilleurscore")).ToString();
    }

    private void Update()
    {
    }
}

