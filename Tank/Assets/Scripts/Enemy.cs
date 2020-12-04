using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //坦克属性
    public float moveSpeed = 2;//移动速度
    public int enemyBlood = 40;//敌人血量
    private Vector3 bullectEulerAngles;
    private float v = -1;
    private float h;
    private bool canMove = true;//坦克是否能够移动
    private float moveTimeVal = 0;//雷击后禁止移动时间
    private float fireTimeVal = 0;//火焰天气下扣血频率



    private SpriteRenderer sr;
    public Sprite[] tankSprite;//上 右 下 左
    public GameObject bullectPrefab;
    public GameObject explosionPrefab;

    private float timeVal;
    private float timeValChangeDirection = 0;


    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timeVal >= 4f)
        {
            Attack();
        }
        else
        {
            timeVal += Time.fixedDeltaTime;
        }

        //检查坦克行动是否被封锁
        if (!canMove && moveTimeVal >= 3f)
        {
            canMove = true;//解除雷击状态
        }
        else
        {
            moveTimeVal += Time.fixedDeltaTime;
        }

        FireDie();
    }

    private void FixedUpdate()
    {
        move();

    }

    //坦克的攻击方法
    private void Attack()
    {
        //雪天气下无法发射子弹
        if (WeatherCreation.isSnow)
        {
            return;
        }
        //子弹产生的角度：当前坦克的角度+子弹应该旋转的角度。
        Instantiate(bullectPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + bullectEulerAngles));
        timeVal = 0;
    }
    //坦克移动方法
    private void move()
    {
        if (!canMove)
        {
            return;
        }
        if (timeValChangeDirection >= 4)
        {
            int num = Random.Range(0, 8);
            if (num > 5)
            {
                v = -1;
                h = 0;
            }
            else if (num == 0)
            {
                v = 1;
                h = 0;
            }
            else if (num > 0 && num <= 2)
            {
                h = -1;
                v = 0;
            }
            else if (num > 2 && num <= 4)
            {
                h = 1;
                v = 0;
            }

            timeValChangeDirection = 0;
        }
        else
        {
            timeValChangeDirection += Time.fixedDeltaTime;
        }




        transform.Translate(Vector3.up * v * moveSpeed  * Time.fixedDeltaTime, Space.World);

        if (v < 0)
        {
            sr.sprite = tankSprite[2];
            bullectEulerAngles = new Vector3(0, 0, -180);
        }

        else if (v > 0)
        {
            sr.sprite = tankSprite[0];
            bullectEulerAngles = new Vector3(0, 0, 0);
        }

        if (v != 0)
        {
            return;
        }


        transform.Translate(Vector3.right * h * moveSpeed  * Time.fixedDeltaTime, Space.World);
        if (h < 0)
        {
            sr.sprite = tankSprite[3];
            bullectEulerAngles = new Vector3(0, 0, 90);
        }

        else if (h > 0)
        {
            sr.sprite = tankSprite[1];
            bullectEulerAngles = new Vector3(0, 0, -90);
        }

    }

    //坦克的受伤方法（因雷电,火焰天气死亡的坦克无法加分）
    private void Die()
    {

        enemyBlood -= Bullect.damage;

        if (enemyBlood <= 0)
        {
            PlayerManager.Instance.playerScore++;

            //产生爆炸特效
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            //死亡
            Destroy(gameObject);
        }
    }

    private void BombDie()
    {

        enemyBlood -= BombExplode.bombDamage;


        if (enemyBlood <= 0)
        {
            PlayerManager.Instance.playerScore++;

            //产生爆炸特效
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            //死亡
            Destroy(gameObject);
        }
    }

    private void ThunderDie()
    {
        enemyBlood -= Thunder.damage;
        canMove = false;//进入麻痹状态，无法移动
        moveTimeVal = 0;
        if (enemyBlood <= 0)
        {
            //产生爆炸特效
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            //死亡
            Destroy(gameObject);
        }
    }

    private void FireDie()
    {
        //扣血速率2/s
        if (WeatherCreation.isFire && fireTimeVal >= 1f)
        {
            enemyBlood -= WeatherCreation.fireDamage;
            fireTimeVal = 0;
        }
        else if (fireTimeVal < 2f)
        {
            fireTimeVal += Time.fixedDeltaTime;
        }

        if (enemyBlood <= 0)
        {
            //产生爆炸特效
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            //死亡
            Destroy(gameObject);
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            timeValChangeDirection = 4;
        }
    }

}
