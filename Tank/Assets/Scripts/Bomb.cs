using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{


    public GameObject BombExplosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Exploded", 3f);
        Destroy(gameObject, 3f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Exploded()
    {
        for (int i = -2; i < 3; i++)
        {
            Instantiate(BombExplosionPrefab, transform.position + new Vector3(i, 0, 0), Quaternion.identity);
        }
        for (int j = -2; j < 0; j++)
        {
            Instantiate(BombExplosionPrefab, transform.position + new Vector3(0, j, 0), Quaternion.identity);
        }
        for (int j = 1; j < 3; j++)
        {
            Instantiate(BombExplosionPrefab, transform.position + new Vector3(0, j, 0), Quaternion.identity);
        }

    }
}
