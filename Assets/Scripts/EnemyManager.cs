using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Search;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private static EnemyManager instance;
    public static EnemyManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("EnemyManager");
                instance = go.AddComponent<EnemyManager>();
                DontDestroyOnLoad(go);
            }
            return instance;
        }
    }
    private Vector3 playerPos;
    private GameObject enemyObj;
    private GameObject player;
    private List<GameObject> enemyList = new List<GameObject>();
    [SerializeField]
    private float _delayTime = 0;
    public void init()
    {
        Debug.Log("EnemyManager管理器启动");
    }
    private void Start()
    {
        player = GameObject.Find("Player");
    }
    private void Update()
    {
        foreach (GameObject go in enemyList)
        {
            if (go == null)
            {
                enemyList.Remove(go);
            } 
        }
        playerPos = player.transform.position;
        _delayTime += Time.deltaTime;
        if (enemyList.Count <= 10 && _delayTime >= 5)
        {
            enemyObj = Resources.Load<GameObject>("Prefabs/Enemy/Enemy");
            enemyObj.name = enemyList.Count.ToString();
            enemyObj.transform.position = EnemyPos();
            Instantiate(enemyObj);
            enemyList.Add(enemyObj);
            _delayTime = 0;
        }
    }

    private Vector3 EnemyPos()
    {
        float x = UnityEngine.Random.Range(0, 40) - 20;
        float y = Mathf.Sqrt(400 - x * x); // 圆心 10 10
        return new Vector3(playerPos.x + x, playerPos.y -20 + y, 0);
    }
}
