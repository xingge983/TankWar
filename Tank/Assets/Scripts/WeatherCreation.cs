using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherCreation : MonoBehaviour
{

    private float weatherTimeVal = 30f;//每次天气持续30s后切换
    private int weatherMode = 0;//用于记录当前天气，避免随机相同模式。0:无天气；1：雷；2：火；3：雪

    public static int fireDamage = 2;//火焰天气伤害/s

    //对应天气的开关
    public static bool isThunder = false;
    public static bool isFire = false;
    public static bool isSnow = false;

    public GameObject thunderPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("ChangeWeather", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        weatherTimeVal -= Time.deltaTime;
        if (weatherTimeVal <= 0)
        {
            ChangeWeather();
        }

    }

    private void ChangeWeather()
    {
        int num = Random.Range(1, 4);
        weatherMode += num;//Mode随机加1-3，不会重复当前天气；
        if(weatherMode > 3)
        {
            weatherMode -= 4;
        }
        switch (weatherMode)
        {
            case 0:
                NoWeather();
                break;
            case 1:
                ThunderWeather();
                break;
            case 2:
                FireWeather();
                break;
            case 3:
                SnowWeather();
                break;
            default:
                break;
        }
        weatherTimeVal = 30f;
    }

    private void NoWeather()
    {
        isFire = false;
        isSnow = false;
        isThunder = false;

    }
    //雷电天气，在地图内产生雷电格子，造成伤害及限制移动

    private void ThunderWeather()
    {
        isFire = false;
        isSnow = false;
        isThunder = true;
        for(int i =0; i < 20; i++)
        {
            CreateItem(thunderPrefab, CreateRandomPosition(), Quaternion.identity);
        }
    }

    //火焰天气，所有坦克持续减少血量

    private void FireWeather()
    {
        isSnow = false;
        isThunder = false;
        isFire = true;
    }

    //冰雪天气，坦克无法发射子弹，仍可使用炸弹（建议多玩家模式使用）

    private void SnowWeather()
    {
        isThunder = false;
        isFire = false;
        isSnow = true;
    }



    private void CreateItem(GameObject createCameObject, Vector3 createPosition, Quaternion createRotation)
    {
        GameObject itemGo = Instantiate(createCameObject, createPosition, createRotation);
        itemGo.transform.SetParent(gameObject.transform);

    }



    //产生随机位置的方法

    private Vector3 CreateRandomPosition()
    {
        while (true)
        {
            Vector3 createPosition = new Vector3(Random.Range(-10, 11), Random.Range(-8, 9), 0);
            if (!HasThePosition(createPosition))
            {
                return createPosition;
            }

        }
    }

    //用来判断位置列表中是否有这个位置

    private bool HasThePosition(Vector3 createPos)
    {
        for (int i = 0; i < MapCreation.itemPositionList2.Count; i++)
        {
            if (createPos == MapCreation.itemPositionList2[i])
            {
                return true;
            }
        }
        return false;
    }

}
