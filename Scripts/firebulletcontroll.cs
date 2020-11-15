using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firebulletcontroll : MonoBehaviour {
    public GameObject bulletPrefab;
    public float moveSpeed = 10;
    public GameObject explosionPrefab;
    private Vector3 bullectEulerAngles1;
    private Vector3 bullectEulerAngles2;
    private Vector3 bullectEulerAngles3;
    private Vector3 bullectEulerAngles4;
    public int breaknum = 1;
    public bool isPlayerBullect;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
     transform.Translate(transform.up * moveSpeed * Time.deltaTime, Space.World);

    }
    private void breakbullet()
    {
        bullectEulerAngles1 = new Vector3(0, 0, -180);
        bullectEulerAngles2 = new Vector3(0, 0, -90);
        bullectEulerAngles3 = new Vector3(0, 0, 0);
        bullectEulerAngles4 = new Vector3(0, 0, 90);
       
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + bullectEulerAngles1));
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + bullectEulerAngles2));
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + bullectEulerAngles3));
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + bullectEulerAngles4));
         
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Tank":
                if (!isPlayerBullect)
                {
                    collision.SendMessage("Die");
                    Instantiate(explosionPrefab, collision.transform.position, transform.rotation);
                    Destroy(gameObject);
                    breakbullet();

                }
                break;
            case "Heart":
                collision.SendMessage("Die");
                Instantiate(explosionPrefab, collision.transform.position, transform.rotation);
                Destroy(gameObject);
                breakbullet();

                break;
            case "Enemy":
                if (isPlayerBullect)
                {
                    collision.SendMessage("Die");
                    Instantiate(explosionPrefab, collision.transform.position, transform.rotation);
                    breakbullet();
                    Destroy(gameObject);
                  

                }

                break;
            case "Wall":




                collision.SendMessage("getbonus");
                Instantiate(explosionPrefab, collision.transform.position, transform.rotation);
                breakbullet();

                Destroy(gameObject);
             


                break;
            case "Barrier":

                if (isPlayerBullect)
                {
                    collision.SendMessage("PlayAudio");
                }
                Instantiate(explosionPrefab, collision.transform.position, transform.rotation);
           
                Destroy(collision.gameObject);
                breakbullet();
                Destroy(gameObject);
              
                break;
            case "bonus1":
                if (isPlayerBullect)
                {
                    if (petrolcontroll.petrolcurrent < 250)
                        petrolcontroll.petrolcurrent += 50;
                    else
                        petrolcontroll.petrolcurrent = 300;
                }
                Destroy(collision.gameObject);
                breakbullet();
                Destroy(gameObject);
              
                Instantiate(explosionPrefab, collision.transform.position, transform.rotation);

                break;


            case "bonus2":
                if (isPlayerBullect)
                {
                    
                        launch.timeval += 200;
                }
                Instantiate(explosionPrefab, collision.transform.position, transform.rotation);

                Destroy(collision.gameObject);
                breakbullet();
                Destroy(gameObject);
               
                break;
            case "bonus3":
                if (isPlayerBullect)
                    firebullet.firebulletnumber++;
                Destroy(collision.gameObject);
                breakbullet();
                Destroy(gameObject);
               
                break;

            case "bonus4":
                if (isPlayerBullect)
                {
                    Player.isDefended = true;
                    Player.defendTimeVal = 3;
                }
                Instantiate(explosionPrefab, collision.transform.position, transform.rotation);

                Destroy(collision.gameObject);
                breakbullet();
                Destroy(gameObject);
             
                break;
            case "bonus5":
                int range = UnityEngine.Random.Range(-1, 13);
                if (range > 6 && range <= 8)
                {
                    if (isPlayerBullect)
                        Player.isDefended = true;
                    Instantiate(explosionPrefab, collision.transform.position, transform.rotation);

                    Destroy(collision.gameObject);
                    breakbullet();
                    Destroy(gameObject);
                   
                    break;
                }
                if (range <= 6 && range > 4)
                {
                    if (isPlayerBullect)
                    { PlayerManager.addlife(); }
                    Instantiate(explosionPrefab, collision.transform.position, transform.rotation);

                    Destroy(collision.gameObject);
                    breakbullet();
                    Destroy(gameObject);
                  
                    break;
                }
                if (range <= 4)
                {
                    if (isPlayerBullect)
                        firebullet.firebulletnumber++;
                    Destroy(collision.gameObject);
                    breakbullet();
                    Destroy(gameObject);

                    break;
                }
               
                if (range > 8)
                {
                    if (isPlayerBullect)
                    {
                        if (petrolcontroll.petrolcurrent < 250)
                            petrolcontroll.petrolcurrent += 50;
                        else
                            petrolcontroll.petrolcurrent = 300;
                    }
                    Instantiate(explosionPrefab, collision.transform.position, transform.rotation);

                    Destroy(collision.gameObject);
                    breakbullet();
                    Destroy(gameObject);
              
                    break;
                }
              
                break;
            case "bonus6":
                if (isPlayerBullect)
                { PlayerManager.addlife(); }
               
                Instantiate(explosionPrefab, collision.transform.position, transform.rotation);

                Destroy(collision.gameObject);
                breakbullet();
                Destroy(gameObject);
              
                break;

            case "Flag":
                if (isPlayerBullect)
                {
                    flag.flagnumber++;
                    firebullet.firebulletnumber++;
                }
                Instantiate(explosionPrefab, collision.transform.position, transform.rotation);

                Destroy(collision.gameObject);
                breakbullet();
                Destroy(gameObject);
              
                break;
            case "airbarrier":

                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
}
