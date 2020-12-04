using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //坦克属性
    public float moveSpeed = 3;//移动速度
    public static int playerBlood = 100;//玩家血量
    private Vector3 bullectEulerAngles;
    private bool isDefended = true;
    private bool canMove = true;//坦克是否能够移动

    //计时器
    private float timeVal;//发射子弹冷却
    private float bombTimeVal;//炸弹技能冷却
    private float defendTimeVal = 3;//无敌屏障剩余时间
    private float moveTimeVal = 0;//雷击后禁止移动时间
    private float fireTimeVal = 0;//火焰天气下扣血频率


    private SpriteRenderer sr;
    public Sprite[] tankSprite;//上 右 下 左
    public GameObject bullectPrefab;
    public GameObject bombPrefab;
    public GameObject explosionPrefab;
    public GameObject defendEffectPrefab;



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
     
        if (playerBlood <= 0)
        {
            PlayerManager.Instance.isDead = true;
            //产生爆炸特效
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            //死亡
            Destroy(gameObject);
        }

        //检查坦克无敌时间
        if (isDefended)
        {
            defendEffectPrefab.SetActive(true);
            defendTimeVal -= Time.deltaTime;
            if (defendTimeVal <= 0)
            {
                isDefended = false;
                defendEffectPrefab.SetActive(false);
            }
        }
        //检查坦克行动是否被封锁
        if (!canMove&&moveTimeVal>=3f)
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
        if (PlayerManager.Instance.isDefeat)
        {
            return;
        }
      
        move();
       
        //检查坦克攻击冷却
        if (timeVal >= 0.4f)
        {
            Attack();
        }
        else
        {
            timeVal += Time.fixedDeltaTime;
        }
        //检查坦克炸弹冷却
        if (bombTimeVal >= 5f)
        {
            BombAttack();
        }
        else
        {
            bombTimeVal += Time.fixedDeltaTime;
        }

    }

    //坦克的攻击方法
    private void Attack()
    {
        //雪天气下无法发射子弹
        if (WeatherCreation.isSnow)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {

            //子弹产生的角度：当前坦克的角度+子弹应该旋转的角度。
            Instantiate(bullectPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + bullectEulerAngles));
            timeVal = 0;

        }
    }
    //坦克炸弹方法
    private void BombAttack()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {

            //炸弹产生位置为坦克位置，无旋转
            Instantiate(bombPrefab, transform.position, transform.rotation);
            bombTimeVal = 0;
        }
    }
    //坦克移动方法
    private void move()
    {
        if (!canMove)
        {
            return;
        }
        float v = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World);
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
        float h = Input.GetAxisRaw("Horizontal");

        transform.Translate(Vector3.right * h * moveSpeed * Time.fixedDeltaTime, Space.World);        

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

    //坦克的受伤方法(子弹，炸弹，天气)
    private void Die()
    {
        if (isDefended)
        {
            return;
        }

        playerBlood -= Bullect.damage;

    }

    private void BombDie()
    {
        if (isDefended)
        {
            return;
        }

        playerBlood -= BombExplode.bombDamage;

            defendTimeVal = 2;
            isDefended = true;
        
    }

    private void ThunderDie()
    {
        playerBlood -= Thunder.damage;//无视保护状态
        canMove = false;//进入麻痹状态，无法移动
        moveTimeVal = 0;
    }

    private void FireDie()
    {
        //扣血速率2/s
        if (WeatherCreation.isFire&&fireTimeVal>=1f)
        {
            playerBlood -= WeatherCreation.fireDamage;
            fireTimeVal = 0;
        }
        else if(fireTimeVal<2f)
        {
            fireTimeVal += Time.fixedDeltaTime;
        }
    }
}
