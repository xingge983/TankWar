using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameControler : MonoBehaviour
{
    //引用
    public GameObject begin;     //开始图片
    public GameObject[] WavesOfEnemiesJPG;//第n波敌人图片
    public GameObject isdefeatUI;//失败图片
    public GameObject iswinUI;   //胜利图片
    public GameObject[] MapItme;  //地图物件
    //0.草 1.河流 2.空气墙
    public GameObject[] Tank_turn1;
    public GameObject[] Tank_turn2;
    public GameObject[] Tank_turn3;//敌方的坦克
    public GameObject[] Lifes;
    public int life;
    public Text EnemyNum;
    public GameObject[] Tank;
    public int enemyTank; //目前敌方坦克数量
    public int enemyTankMax; //该关卡最大坦克数量
    public int myTank = 0;
    public int DefeatTanks = 0;
    public int Money;       //金币数
    public Text MoneyText;  //金币文本
    public Text lostEnemy;  //剩余敌人数
    public Text TurnsText; //第n波
    public Text DefeatNum; //击败的敌人数
    public bool isEndLess;


    public int WavesOfEnemies;  //0.开始图片 1.第一波敌人图片 2.进入第一波 3.第二波敌人图片 4.进入第二波 5.第三波敌人图片 6.进入第三波
    //计时器
    private float timeVal;
    private float timeVal_def;
    private int r = 1;
    private int s = 1;
    private int turns = 1;


    private static GameControler instance;

    public static GameControler Instance { get => instance; set => instance = value; }

    private void Awake()
    {

        Instance = this;
    }

    private void AddEnemy(GameObject Tank, float i)
    {
        Instantiate(Tank, new Vector3(i, 30, 0), Quaternion.identity);
        enemyTank++;
        enemyTankMax--;

    }
    void Update()
    {
        if (life == -1)//切换为失败状态
        {
            life--;
            isdefeatUI.SetActive(true);
            timeVal_def = 0;
        }
            if (life == -2)//失败计时
        {
            
            if (timeVal_def >= 3)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                timeVal_def += Time.deltaTime;

            }
        }
        MoneyText.text = "金币：" + Money;


        if (!isEndLess)
        {
            lostEnemy.text = "剩余" + enemyTank + "个敌人";
            if (WavesOfEnemies == 0)   //开始图片出现
            {
                if (timeVal >= 3)
                {
                    WavesOfEnemiesJPG[0].SetActive(false);
                    WavesOfEnemies++;
                    enemyTankMax = 10;
                    timeVal = 0;
                    TurnsText.text = "第" + turns + "波";
                }
                else
                {
                    timeVal += Time.deltaTime;
                    WavesOfEnemiesJPG[0].SetActive(true);
                }
            }

            if (WavesOfEnemies == 1 && enemyTankMax != 0) //第一波敌人
            {
                if (timeVal >= 1)
                {
                    r = (int)UnityEngine.Random.Range(0f, 100f);
                    r = r % 4;
                    if (r == 0)
                    {
                        AddEnemy(Tank[0], 5f);
                    }
                    if (r == 1)
                    {
                        AddEnemy(Tank[0], 8.4f);
                    }
                    if (r == 2)
                    {
                        AddEnemy(Tank[0], 11.8f);
                    }
                    if (r == 3)
                    {
                        AddEnemy(Tank[0], 15.2f);
                    }
                    timeVal = 0;
                }
                else
                {
                    timeVal += Time.deltaTime;
                }
            }
            if (WavesOfEnemies == 1 && enemyTank == 0 && enemyTankMax == 0) //转到第二波
            {
                WavesOfEnemies++;
                enemyTankMax = -1;
                timeVal = 0;
            }
            if (WavesOfEnemies == 2 && enemyTankMax == -1)   //第二波图片
            {
                if (timeVal >= 3)
                {
                    WavesOfEnemiesJPG[1].SetActive(false);
                    WavesOfEnemies++;
                    enemyTankMax = 10;
                    turns++;
                    timeVal = 0;
                    TurnsText.text = "第" + turns + "波";
                }
                else
                {
                    timeVal += Time.deltaTime;
                    WavesOfEnemiesJPG[1].SetActive(true);
                }
            }
            if (WavesOfEnemies == 3 && enemyTankMax != 0)//第二波敌人
            {
                if (timeVal >= 1)
                {
                    r = (int)UnityEngine.Random.Range(0f, 100f);
                    r = r % 4;
                    s = (int)UnityEngine.Random.Range(0f, 100f);
                    s = s % 4;
                    int i = 0;
                    if (s == 0) i = 1; //随即出场hard坦克

                    if (r == 0)
                    {
                        AddEnemy(Tank[i], 5f);
                    }
                    if (r == 1)
                    {
                        AddEnemy(Tank[i], 8.4f);
                    }
                    if (r == 2)
                    {
                        AddEnemy(Tank[i], 11.8f);
                    }
                    if (r == 3)
                    {
                        AddEnemy(Tank[i], 15.2f);
                    }
                    timeVal = 0;
                }
                else
                {
                    timeVal += Time.deltaTime;
                }
            }
            if (WavesOfEnemies == 3 && enemyTank == 0 && enemyTankMax == 0) //转到第三波
            {
                WavesOfEnemies++;
                enemyTankMax = -1;
                timeVal = 0;
            }

            if (WavesOfEnemies == 4 && enemyTankMax == -1)   //第三波图片
            {
                if (timeVal >= 3)
                {
                    WavesOfEnemiesJPG[2].SetActive(false);
                    WavesOfEnemies++;
                    enemyTankMax = 5;
                    turns++;
                    timeVal = 0;
                    TurnsText.text = "第" + turns + "波";
                }
                else
                {
                    timeVal += Time.deltaTime;
                    WavesOfEnemiesJPG[2].SetActive(true);
                }
            }
            if (WavesOfEnemies == 5 && enemyTankMax != 0)//第三波敌人
            {
                if (timeVal >= 1)
                {
                    r = (int)UnityEngine.Random.Range(0f, 100f);
                    r = r % 4;

                    if (r == 0)
                    {
                        AddEnemy(Tank[1], 5f);
                    }
                    if (r == 1)
                    {
                        AddEnemy(Tank[1], 8.4f);
                    }
                    if (r == 2)
                    {
                        AddEnemy(Tank[1], 11.8f);
                    }
                    if (r == 3)
                    {
                        AddEnemy(Tank[1], 15.2f);
                    }
                    timeVal = 0;
                }
                else
                {
                    timeVal += Time.deltaTime;
                }
            }
            if (WavesOfEnemies == 5 && enemyTank == 0 && enemyTankMax == 0) //胜利
            {
                iswinUI.SetActive(true);
                if (timeVal >= 3)
                {
                    SceneManager.LoadScene(0);
                }
                else
                {
                    timeVal += Time.deltaTime;

                }
            }
        }
        else //无尽模式下敌人出场方法
        {
            DefeatNum.text = "已经击败了" + DefeatTanks + "个坦克";
            if (timeVal >= 2)
            {
                r = (int)UnityEngine.Random.Range(0f, 100f);
                r = r % 4;
                s = (int)UnityEngine.Random.Range(0f, 100f);
                s = s % 4;
                int i = 0;
                if (s == 0) i = 1; //随即出场hard坦克

                if (r == 0)
                {
                    AddEnemy(Tank[i], 5f);
                }
                if (r == 1)
                {
                    AddEnemy(Tank[i], 8.4f);
                }
                if (r == 2)
                {
                    AddEnemy(Tank[i], 11.8f);
                }
                if (r == 3)
                {
                    AddEnemy(Tank[i], 15.2f);
                }
                timeVal = 0;
            }
            else
            {
                timeVal += Time.deltaTime;
            }
        }
        }
   

    }

