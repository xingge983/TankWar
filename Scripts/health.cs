using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class health : MonoBehaviour {
    public Text Health;
    public int Healthmax = 5;
    public static int Healthcurrent;
    private Image healthbar;
	// Use this for initialization
	void Start () {
        healthbar = GetComponent<Image>();
        Healthcurrent = Healthmax;
	}
	
	// Update is called once per frame
	void Update () {
        healthbar.fillAmount = (float)Healthcurrent / (float)Healthmax;
        Health.text = Convert.ToString(Healthcurrent) + "/" + Convert.ToString(Healthmax);
	}
}
