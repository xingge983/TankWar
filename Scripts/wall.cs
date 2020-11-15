using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour {
    public SpriteRenderer sp;
    public Sprite[] bonus;
    public GameObject bonus1;
    public GameObject bonus2;
    public GameObject bonus3;
    public GameObject bonus4;
    public GameObject bonus5;
    public GameObject bonus6;
    public void Awake()
      
    {
        sp = GetComponent<SpriteRenderer>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void getbonus()
    {
        int num = Random.Range(0, 42);
        if (num > 0&&num<5)
        {
            Instantiate(bonus1, transform.position, transform.rotation);
            Destroy(gameObject);

        }
        else if (num >4&&num<7)
        {

            Instantiate(bonus2, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        else if (num > 6 && num <9)
        {

            Instantiate(bonus3, transform.position, transform.rotation);
            Destroy(gameObject);

        }
        else if (num > 8&& num <= 10)
        {

            Instantiate(bonus4, transform.position, transform.rotation);
            Destroy(gameObject);

        }
        else if (num > 10 && num <= 14)
        {

            Instantiate(bonus5, transform.position, transform.rotation);
            Destroy(gameObject);

        }
        else if (num > 14 && num <= 16)
        {

            Instantiate(bonus6, transform.position, transform.rotation);
            Destroy(gameObject);

        }
        else if (num > 16 )
        {

            
            Destroy(gameObject);

        }




    }
}
