using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullect : MonoBehaviour {

    public float moveSpeed = 10;

    public  bool isPlayerBullect;
    public static float timeval;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(transform.up * moveSpeed * Time.deltaTime, Space.World);
  

    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Tank":
                if (!isPlayerBullect)
                {
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                    
                }
                break;
            case "Heart":
                if (isPlayerBullect)
                { collision.SendMessage("Die"); }
                Destroy(gameObject);
                break;
            case "Enemy":
                if (isPlayerBullect)
                {
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                }
                
                break;
            case "Wall":

               
               
           
                collision.SendMessage("getbonus");
                Destroy(gameObject);


                break;
            case "Barrier":
             
                if (isPlayerBullect)
                {
                    collision.SendMessage("PlayAudio");
                }
                
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
                Destroy(gameObject);
                break;


            case "bonus2":
                if(isPlayerBullect)
                launch.timeval += 200;
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
            case "bonus3":
                if (isPlayerBullect)
                    firebullet.firebulletnumber++;
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
                
            case "bonus4":
                if (isPlayerBullect)
                {
                    Player.isDefended = true;
                    Player.defendTimeVal = 3;
                }
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
            case "bonus5":
                int range = Random.Range(-1, 13);
                if (range > 6&&range<=8)
                {
                    if (isPlayerBullect)
                    {
                        Player.isDefended = true;
                        Player.defendTimeVal = 3;
                    }
                    Destroy(collision.gameObject);
                    Destroy(gameObject);
                    break;
                }
                if (range <= 6 && range > 4)
                {
                    if (isPlayerBullect)
                    { PlayerManager.addlife(); }

                    Destroy(collision.gameObject);
                    Destroy(gameObject);
                    break;
                }
                if (range <= 4 )
                {
                    if (isPlayerBullect)
                        firebullet.firebulletnumber++;
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
                    Destroy(collision.gameObject);
                    Destroy(gameObject);
                    break;
                }
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
            case "bonus6":
                if (isPlayerBullect)
                {
                    PlayerManager.addlife();
                    Player.isDefended = true;
                    Player.defendTimeVal = 3;
                }
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;

            case "Flag":
                if (isPlayerBullect)
                {
                    flag.flagnumber++;

                    firebullet.firebulletnumber++;
                }

                Destroy(collision.gameObject);
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
