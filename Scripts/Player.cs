using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Pun.Demo.PunBasics;

public class Player : MonoBehaviourPun
{

    //属性值
    public static float moveSpeed = 4;
    private Vector3 bullectEulerAngles;
    public float timeVal;
    public Text time;
    public  int timeval = 1000;
    public static float defendTimeVal=3;
    public static bool isDefended=true;



    //引用
    private SpriteRenderer sr;
    public Sprite[] tankSprite;//上 右 下 左
    public GameObject bullectPrefab;
    public GameObject firebulletPrefab;
    public GameObject explosionPrefab;
    public  GameObject defendEffectPrefab;
   
    public AudioSource moveAudio;
    public AudioClip[] tankAudio;

    private Transform player;
 

    
  
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Tank").transform;
    }

    // Use this for initialization
    void Start () {
        CameraWork _cameraWork = GetComponent<CameraWork>();

        if (_cameraWork != null && photonView.IsMine)
        {
            _cameraWork.OnStartFollowing();
        }
        defendEffectPrefab.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
    
        
        if (isDefended)
        {
            defendEffectPrefab.SetActive(true);
            defendTimeVal -= Time.deltaTime;
            if (defendTimeVal<=0)
            {
                isDefended = false;
                defendEffectPrefab.SetActive(false);
            }
        }
        if (photonView.IsMine && PhotonNetwork.IsConnected)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
                petrolcontroll.petrolcurrent-=5;

        }



    }

    private void FixedUpdate()
    {
        
        
            if (PlayerManager.Instance.isDefeat)
            {
                return;
            }
            if (petrolcontroll.petrolcurrent > 0)
            {
            if (photonView.IsMine && PhotonNetwork.IsConnected)
                Move();
           

            }
            //攻击的CD
            if (timeVal >= 0.4f)
        {
            if (photonView.IsMine && PhotonNetwork.IsConnected)
            {
                Attack();
                firebulletAttack();
            }
           
        }
            else
            {
                timeVal += Time.fixedDeltaTime;
            }
        
        
    }

    //坦克的攻击方法
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            //子弹产生的角度：当前坦克的角度+子弹应该旋转的角度。
            Instantiate(bullectPrefab, transform.position,Quaternion.Euler(transform.eulerAngles));
            timeVal = 0;
           
        }
      
    }
    private void firebulletAttack()
    {
        
         if (Input.GetKeyDown(KeyCode.F) && firebullet.firebulletnumber > 0)
        {

            //子弹产生的角度：当前坦克的角度+子弹应该旋转的角度。
            Instantiate(firebulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles));
            timeVal = 0;
            firebullet.firebulletnumber--;
           
        }
    }



    //坦克的移动方法
    private void Move()
    {
        float v = Input.GetAxisRaw("Vertical");


        transform.Translate(Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World);
       

        if (v < 0)
        {

            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180f));
            bullectEulerAngles = new Vector3(0, 0, -180);
        }

        else if (v > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            bullectEulerAngles = new Vector3(0, 0, 0);
        }

        if (Mathf.Abs(v)>0.05f)
        {
            moveAudio.clip = tankAudio[1];
            
            if (!moveAudio.isPlaying)
            {
                moveAudio.Play();
            }
           

        }

        if (v != 0)
        {
            return;
        }
        
        float h = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * h * moveSpeed * Time.fixedDeltaTime, Space.World);
        
        if (h < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90f));
            bullectEulerAngles = new Vector3(0, 0, 90);
           
        }

        else if (h > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90f));
            bullectEulerAngles = new Vector3(0, 0, -90);
        }

        if (Mathf.Abs(h) > 0.05f)
        {
            moveAudio.clip = tankAudio[1];

            if (!moveAudio.isPlaying)
            {
                moveAudio.Play();
            }
            

        }
        else
        {
            moveAudio.clip = tankAudio[0];

            if (!moveAudio.isPlaying)
            {
                moveAudio.Play();
            }
        }
       
    }

    //坦克的死亡方法
    private void Die()
    {
        if (isDefended)
        {
            return;
        }
        if (health.Healthcurrent != 0)
        {
            health.Healthcurrent--;
            return;
        }
        if (health.Healthcurrent > 3)
            moveSpeed = 4;
        if (health.Healthcurrent ==3)
            moveSpeed = 3;
        if (health.Healthcurrent < 3)
            moveSpeed = 2;

        else if (health.Healthcurrent == 0)
        {
            PlayerManager.Instance.isDead = true;

            //产生爆炸特效
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            //死亡
            Destroy(gameObject);
            health.Healthcurrent = 5;
        }
    }


   
}
