using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class petrolcontroll : MonoBehaviour {
    public static int petrolcurrent;
    public int petrolmax=200;
    public Text petrolnum;
    public Image petrol;
	// Use this for initialization
	void Start () {
       
        petrol = GetComponent<Image>();
        petrolcurrent = petrolmax;
	}
	
	// Update is called once per frame
	void Update () {
        petrol.fillAmount =(float) petrolcurrent /(float) petrolmax;
        petrolnum.text = Convert.ToString(petrolcurrent) + "/" + Convert.ToString(petrolmax);
		
	}
}
