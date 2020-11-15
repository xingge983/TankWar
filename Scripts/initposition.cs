using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

public class initposition : MonoBehaviour {
    public GameObject[] item;
    public static List<Vector3> grassPositionList = new List<Vector3>();
    //已经有东西的位置列表
    private List<Vector3> itemPositionList = new List<Vector3>();
    // Use this for initialization

    private void Awake()
    {
        Initposition();

    }

    private void CreateItem(int i, Vector3 createPosition, Quaternion createRotation)
    {
        GameObject itemGo = Instantiate(item[i], createPosition, createRotation);
        itemGo.transform.SetParent(gameObject.transform);
        using (StreamWriter sw = new StreamWriter(@"C:\\Users\\。。。\\Desktop\\maps.txt", true))
        {
            sw.WriteLine(Convert.ToString(createPosition));


           
        }



    }
    private Vector3 CreateRandomPosition()
    {
        //不生成x=-10,10的两列，y=-8,8正两行的位置
        while (true)
        {
            Vector3 createPosition = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), 0);
            if (!HasThePosition(createPosition))
            {
                return createPosition;
            }

        }
    }

    private bool HasThePosition(Vector3 createPos)
    {
        for (int i = 0; i < itemPositionList.Count; i++)
        {
            if (createPos == itemPositionList[i])
            {
                return true;
            }
        }
        return false;
    }
    public void Initposition()
    {

        //实例化老家

        //用墙把老家围起来
        CreateItem(2, new Vector3(-1, -8, 0), Quaternion.identity);
        CreateItem(2, new Vector3(1, -8, 0), Quaternion.identity);
        for (int i = -1; i < 2; i++)
        {
            CreateItem(2, new Vector3(i, -7, 0), Quaternion.identity);
        }
        for (int i = -1; i < 2; i++)
        {
            CreateItem(2, new Vector3(i, -9, 0), Quaternion.identity);
        }
        //实例化外围墙
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
       
        itemPositionList.Add(new Vector3(0, -8, 0));

        itemPositionList.Add(bornposition);


        //产生敌人
        for (int i = 0; i < 50; i++)
        {
            CreateItem(3, CreateRandomPosition(), Quaternion.identity);
        }
        InvokeRepeating("CreateEnemy", 4, 5);


        //实例化地图
        for (int i = 0; i < 500; i++)
        {
            Vector3 center = CreateRandomPosition();


            CreateItem(7, center, Quaternion.identity);


            CreateItem(2, center + new Vector3(-1, 1, 0), Quaternion.identity);


            CreateItem(1, center + new Vector3(0, 1, 0), Quaternion.identity);


            CreateItem(2, center + new Vector3(1, 1, 0), Quaternion.identity);


            CreateItem(1, center + new Vector3(-1, 0, 0), Quaternion.identity);


            CreateItem(1, center + new Vector3(1, 0, 0), Quaternion.identity);


            CreateItem(2, center + new Vector3(-1, -1, 0), Quaternion.identity);


            CreateItem(1, center + new Vector3(0, -1, 0), Quaternion.identity);


            CreateItem(2, center + new Vector3(1, -1, 0), Quaternion.identity);



        }
        for (int i = 0; i < 4500; i++)
        {

            CreateItem(1, CreateRandomPosition(), Quaternion.identity);


        }
        for (int i = 0; i < 2500; i++)
        {

            CreateItem(2, CreateRandomPosition(), Quaternion.identity);


        }
        for (int i = 0; i < 1500; i++)
        {
            Vector3 center = CreateRandomPosition();

            int ran1 = UnityEngine.Random.Range(0, 3);
            int ran2 = UnityEngine.Random.Range(0, 3);
            int ran3 = Random.Range(0, 3);
            int ran4 = Random.Range(0, 3);
            int ran5 = Random.Range(0, 3);
            int ran6 = Random.Range(0, 3);
            int ran7 = Random.Range(0, 3);
            int ran8 = Random.Range(0, 3);
            int ran9 = Random.Range(0, 3);
            if (ran1 == 1)
            {
                CreateItem(4, center, Quaternion.identity);
            }
            if (ran2 == 1 && !itemPositionList.Contains(center + new Vector3(-1, 1, 0)))
            {
                CreateItem(4, center + new Vector3(-1, 1, 0), Quaternion.identity);
            }
            if (ran3 == 1 && !itemPositionList.Contains(center + new Vector3(-1, 1, 0)))
            {
                CreateItem(4, center + new Vector3(0, 1, 0), Quaternion.identity);
            }
            if (ran4 == 1 && !itemPositionList.Contains(center + new Vector3(1, 1, 0)))
            {
                CreateItem(4, center + new Vector3(1, 1, 0), Quaternion.identity);
            }
            if (ran5 == 1 && !itemPositionList.Contains(center + new Vector3(-1, 0, 0)))
            {
                CreateItem(4, center + new Vector3(-1, 0, 0), Quaternion.identity);
            }
            if (ran6 == 1 && !itemPositionList.Contains(center + new Vector3(1, 0, 0)))
            {
                CreateItem(4, center + new Vector3(1, 0, 0), Quaternion.identity);
            }
            if (ran7 == 1 && !itemPositionList.Contains(center + new Vector3(-1, -1, 0)))
            {
                CreateItem(4, center + new Vector3(-1, -1, 0), Quaternion.identity);
            }
            if (ran8 == 1 && !itemPositionList.Contains(center + new Vector3(0, -1, 0)))
            {
                CreateItem(4, center + new Vector3(0, -1, 0), Quaternion.identity);
            }
            if (ran9 == 1 && !itemPositionList.Contains(center + new Vector3(1, -1, 0)))
            {
                CreateItem(4, center + new Vector3(1, -1, 0), Quaternion.identity);
            }

        }

        for (int i = 0; i < 1500; i++)
        {
            Vector3 center = CreateRandomPosition();

            int ran1 = Random.Range(0, 3);
            int ran2 = Random.Range(0, 3);
            int ran3 = Random.Range(0, 3);
            int ran4 = Random.Range(0, 3);
            int ran5 = Random.Range(0, 3);
            int ran6 = Random.Range(0, 3);
            int ran7 = Random.Range(0, 3);
            int ran8 = Random.Range(0, 3);
            int ran9 = Random.Range(0, 3);
            if (ran1 == 1)
            {
                CreateItem(5, center, Quaternion.identity);
                grassPositionList.Add(center);
            }
            if (ran2 == 1 && !itemPositionList.Contains(center + new Vector3(-1, 1, 0)))
            {
                CreateItem(5, center + new Vector3(-1, 1, 0), Quaternion.identity);
                grassPositionList.Add(center + new Vector3(-1, 1, 0));
            }
            if (ran3 == 1 && !itemPositionList.Contains(center + new Vector3(0, 1, 0)))
            {
                CreateItem(5, center + new Vector3(0, 1, 0), Quaternion.identity);
                grassPositionList.Add(center + new Vector3(0, 1, 0));
            }
            if (ran4 == 1 && !itemPositionList.Contains(center + new Vector3(1, 1, 0)))
            {
                CreateItem(5, center + new Vector3(1, 1, 0), Quaternion.identity);
                grassPositionList.Add(center + new Vector3(1, 1, 0));
            }
            if (ran5 == 1 && !itemPositionList.Contains(center + new Vector3(-1, 0, 0)))
            {
                CreateItem(5, center + new Vector3(-1, 0, 0), Quaternion.identity);
                grassPositionList.Add(center + new Vector3(-1, 0, 0));
            }
            if (ran6 == 1 && !itemPositionList.Contains(center + new Vector3(1, 0, 0)))
            {
                CreateItem(5, center + new Vector3(1, 0, 0), Quaternion.identity);
                grassPositionList.Add(center + new Vector3(1, 0, 0));
            }
            if (ran7 == 1 && !itemPositionList.Contains(center + new Vector3(-1, -1, 0)))
            {
                CreateItem(5, center + new Vector3(-1, -1, 0), Quaternion.identity);
                grassPositionList.Add(center + new Vector3(-1, -1, 0));
            }
            if (ran8 == 1 && !itemPositionList.Contains(center + new Vector3(0, -1, 0)))
            {
                CreateItem(5, center + new Vector3(0, -1, 0), Quaternion.identity);
                grassPositionList.Add(center + new Vector3(0, -1, 0));
            }
            if (ran9 == 1 && !itemPositionList.Contains(center + new Vector3(1, -1, 0)))
            {
                CreateItem(5, center + new Vector3(1, -1, 0), Quaternion.identity);
                grassPositionList.Add(center + new Vector3(1, -1, 0));
            }



        }









    }
}
