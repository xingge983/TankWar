using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreatTanks : MonoBehaviour
{
   
    public float positionx;
    public float positiony;
    public GameObject[] floor;
    public GameObject tanks;

    //public int No;
    public void onClick()
    {
        CreateRandomPosition();
    }
    private void CreateRandomPosition()
    {

        if (GameControler.Instance.Money >= 100)
        {
            Vector3 createPosition = new Vector3(positionx, positiony, 0);
            Instantiate(tanks, createPosition, Quaternion.identity);
            GameControler.Instance.Money -= 100;
        }
        floor[0].SetActive(false);
        floor[1].SetActive(false);
        //TankControler.Instance.No[No] = true;

    }

}
