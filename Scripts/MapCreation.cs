using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

public class MapCreation : MonoBehaviour {


    //用来装饰初始化地图所需物体的数组。
    //0.老家 1.墙 2.障碍 3.出生效果 4.河流 5.草 6.空气墙,7.旗帜
    public GameObject[] item;

    //已经有东西的位置列表
    private List<Vector3> itemPositionList = new List<Vector3>();
    public string[] itemindex=new string[18170];
    public static List<Vector3>grassPositionList = new List<Vector3>();
    public static Vector3 newborn;
 


    private void Awake()
    {
        InitMap();
    
       
    }
   
    public  Vector3 Parse(string str)
    {
        str = str.Replace("(", "").Replace(")", "").Replace(",",""); 

        string[] s = str.Split(' ');
        float x = float.Parse(s[0]);
        float y = float.Parse(s[1]);
        float z = float.Parse(s[2]);
        return new Vector3(x, y,z);
    }

    private void InitMap()
    {

        CreateItem(2, new Vector3(-1, -8, 0), Quaternion.identity);
        CreateItem(2, new Vector3(1, -8, 0), Quaternion.identity);
        for (int c = -1; c < 2; c++)
        {
            CreateItem(2, new Vector3(c, -7, 0), Quaternion.identity);
        }
        for (int d = -1; d < 2; d++)
        {
            CreateItem(2, new Vector3(d, -9, 0), Quaternion.identity);
        }
        CreateItem(6, new Vector3(-101, 101, 0), Quaternion.identity);
        for (int i = -100; i < 102; i++)
        { CreateItem(6, new Vector3(i, 101, 0), Quaternion.identity); }
        for (int i = -101; i < 102; i++)
        { CreateItem(6, new Vector3(i, -101, 0), Quaternion.identity); }
        for (int i = -100; i < 101; i++)
        { CreateItem(6, new Vector3(-101, i, 0), Quaternion.identity); }
        for (int i = -100; i < 101; i++)
        { CreateItem(6, new Vector3(101, i, 0), Quaternion.identity); }

        //初始化玩家
        Vector3 bornposition = new Vector3(-7, -7, 0);
        newborn = bornposition + new Vector3(2, 2, 0);
       
      
        int f = 0;
        using (StreamReader sr = new StreamReader(@"maps.txt",Encoding.UTF8))
        {
            string line;

            int index = 1;
            while ((line = sr.ReadLine()) != null)
            {


                itemPositionList.Add(Parse(line));

           if(f<3000)
          
                {
                    index = 4;
                    CreateItem(index, Parse(line), Quaternion.identity);
                }
              if(f>3000&&f<6000)

                {
                    index = 5;
                    CreateItem(index, Parse(line), Quaternion.identity);
                }
                if (f > 6000 && f < 9000)

                {
                    index = 2;
                    CreateItem(index, Parse(line), Quaternion.identity);
                }
                if (f > 9000 && f < 9100)

                {
                    index = 3;
                    CreateItem(index, Parse(line), Quaternion.identity);
                }
                if (f > 9100 && f < 12500)

                {
                    index = 1;
                    CreateItem(index, Parse(line), Quaternion.identity);
                }
                if (f > 12500 && f < 12600)

                {
                    index = 3;
                    CreateItem(index, Parse(line), Quaternion.identity);
                }
                if (f > 12600 && f < 13000)

                {
                    index = 7;
                    CreateItem(index, Parse(line), Quaternion.identity);
                }
                if (f > 13000&&f<16000)

                {
                    index = 1;
                    CreateItem(index, Parse(line), Quaternion.identity);
                }

                f = f + 1;



            }
        }
        
            
        



    }
    private void CreateItem(int i,Vector3 createPosition,Quaternion createRotation)
    {
        GameObject itemGo = Instantiate(item[i], createPosition, createRotation);
        itemGo.transform.SetParent(gameObject.transform);
       
       


    }


  



}
