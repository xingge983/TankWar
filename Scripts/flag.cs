using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class flag : MonoBehaviour {
    public static int flagnumber=0;
    public Text flagnum;
	
	void Start () {
      
	}
	
	void Update () {
        flagnum.text = Convert.ToString(flagnumber);
           
	}
}
