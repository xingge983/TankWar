using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class rank : MonoBehaviour
{
    public  string[] playername ;
  
    public string[] flagnumber ;

    public Text player1;
    public Text player2;
    public Text player3;

    // Use this for initialization
    void Start()
    {
        List<string> name = playername.ToList();
        List<string> number = flagnumber.ToList();
        using (StreamReader sr = new StreamReader(@"score.txt", true))
        {
            string line;
            int i = 0;
            string c;
            string d;


            while ((line = sr.ReadLine()) != null)
            {
                c = line.Trim().Split(' ')[0];

                d = line.Trim().Split(' ')[line.Trim().Split(' ').Length - 1];
                name.Add(c);
                number.Add(d);


                i = i + 1;
            }
        }
        playername = name.ToArray();
        flagnumber = number.ToArray();

        var len = number.Count;
        for (var i = 0; i < len - 1; i++)
        {
            for (var j = 0; j < len - 1 - i; j++)
            {
                if (Convert.ToInt32(flagnumber[j]) < Convert.ToInt32(flagnumber[j + 1]))
                {     
                    var temp = flagnumber[j + 1];
                    var tem = playername[j + 1];       
                    flagnumber[j + 1] = flagnumber[j];
                    playername[j + 1] = playername[j];
                    flagnumber[j] = temp;
                    playername[j] = tem;
                }
            }
        }
        player1.text = playername[0] + " " + flagnumber[0];
        player2.text = playername[1] + " " + flagnumber[1];
        player3.text = playername[2] + " " + flagnumber[2];


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
