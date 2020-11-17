using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControler : MonoBehaviour
{
    public float moveSpeed = 3;
    public int attackSpeed = 3;
    private Vector3 bullectEulerAngles;
    private float v=-1;
    private float h;
    public float hp;
    public bool isplayer1;
    public bool isLife;
   // public bool[] No;
    
   

    //引用
    private SpriteRenderer sr;
    public GameObject bullectPrefab;
    public GameObject explosionPrefab;
    public GameObject[] item;

    //计时器
    private float timeVal;
    private float timeValChangeDirection;

    private static TankControler instance;

    public static TankControler Instance { get => instance; set => instance = value; }

    private void Awake()
    {
        instance = this;
        sr = GetComponent<SpriteRenderer>();
         if (isplayer1 == true)
        {
     
            bullectEulerAngles = new Vector3(0, 0, 0);
        }

        else if  (isplayer1 == false)
        {
          
            bullectEulerAngles = new Vector3(0, 0, -180);
        }
    }

 
    void Start()
    {

    }

  
    void Update()
    {

        if (!isLife)
        {   //攻击的时间间隔
            if (timeVal >= (6-attackSpeed))
            {
                Attack();
            }
            else
            {
                timeVal += Time.deltaTime;
            }

        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    //坦克的攻击方法
    private void Attack()
    {
        
       //子弹产生的角度：当前坦克的角度+子弹应该旋转的角度。
       Instantiate(bullectPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + bullectEulerAngles));
       timeVal = 0;
        
    }


    //坦克的移动方法
    private void Move()
    {
        transform.Translate(Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World);
    }

    //坦克的死亡方法
    private void Die()
    {
        hp -= 1;
        if (hp == 0)
        {
            //产生爆炸特效
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            //死亡
            Destroy(gameObject);
            if (isplayer1 == false && !isLife)
            {
                GameControler.Instance.enemyTank--;
                GameControler.Instance.DefeatTanks++;
                GameControler.Instance.Money += 40;
            }
            if (isLife)
            {
                GameControler.Instance.Lifes[GameControler.Instance.life].SetActive(false);
                GameControler.Instance.life--;
                GameControler.Instance.Money += 200;
            }    
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Enemy")
        {
            timeValChangeDirection = 4;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Tank" || collision.tag == "Enemy")
            for (int i = 0; i < 100; i++)
            {
                collision.SendMessage("Die");
            }
        //Destroy(gameObject);
              
               
        }




        }
