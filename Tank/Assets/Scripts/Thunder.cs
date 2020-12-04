using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
{
    public static int damage = 20;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Tank":
                collision.SendMessage("ThunderDie");
                Destroy(gameObject);
                break;
            case "Enemy":
                collision.SendMessage("ThunderDie");
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }

}
