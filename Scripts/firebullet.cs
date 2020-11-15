using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class firebullet : MonoBehaviour {
    public Text firebulletnum;
    public static int firebulletnumber = 1;

    public int breaknum = 1;
    // Use this for initialization
    void Start () {
        firebulletnumber = 1;
	}
	
	// Update is called once per frame
	void Update () {
        firebulletnum.text = Convert.ToString(firebulletnumber);
		
	}
   
}
