using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class button : MonoBehaviour {
    public InputField input;
    private GameObject buttonObj;
    public Text number;
    public string[] playername;

    public string[] flagnumber;
    // Use this for initialization
    void Start () {
        number.text = "你的夺旗数为： "+Convert.ToString(flag.flagnumber);
        buttonObj = GameObject.Find("Button");
        buttonObj.GetComponent<Button>().onClick.AddListener(setscore);
    }

   void setscore()
    {
        List<string> name = playername.ToList();
        List<string> number = flagnumber.ToList();
        int b = 0;
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
        name.Add(Convert.ToString(input.text));
        number.Add(Convert.ToString(flag.flagnumber));
        playername = name.ToArray();
        flagnumber = number.ToArray();
      
        SceneManager.LoadScene(2);
        
   
        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(@"score.txt", false))
       
        {
          for ( int i = 0;i < name.Count;i++)
            sw.WriteLine(Convert.ToString(playername[i]) + " " + Convert.ToString(flagnumber[i]));



        }
    }


    // Update is called once per frame
    void Update()
    {
    }
}
