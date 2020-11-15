using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public float moveSpeed;
    public Transform target;
  

    // Use this for initialization
    void Start()
    {
       

    }

    

    // Update is called once per frame
    void Update()
    {
        
        if (PlayerManager.Instance.isDead)
            Camera.main.transform.localPosition = new Vector3(0, 0, -8);
        
    }
    private void FixedUpdate()
    {
       
            cameraMove();
       
    }
        private void cameraMove()
    {
        float v = Input.GetAxisRaw("Vertical");


        Camera.main.transform.Translate(Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World);



        if (v != 0)
        {
            return;
        }

        float h = Input.GetAxisRaw("Horizontal");
        Camera.main.transform.Translate(Vector3.right * h * moveSpeed * Time.fixedDeltaTime, Space.World);

    }
    public  void setspeed()
    {
        moveSpeed = 0.75f;
    }
    public  void resetspeed()
    {
        moveSpeed = 0.5f;
    }
}
