using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject playerObj;
    public Vector3 playerPos;
    public Vector3 playerNormalized;
    public float speed = 2f;
    public float maxhp = 10f;
    public float minhp = 10f;
    public Scrollbar bar;
    void Start()
    {
        playerObj = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Bar();
        if (minhp <= 0)
        {
            Debug.Log(this.name + " die : " +¡¡Time.fixedTime);
            Destroy(this.gameObject);
        }
        playerPos = playerObj.transform.position;
        playerNormalized = (playerPos - transform.position).normalized;
        this.transform.Translate(playerNormalized * speed * Time.deltaTime);
    }
    private void OnDestroy()
    {
        Debug.Log("Time:" +¡¡Time.timeAsDouble + "£º" +this.name);
        //EnemyManager.Instance.MoveEnemyInList(this.transform.gameObject);
    }

    private void Bar() { 
        bar.size = minhp / maxhp;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "player")
        {
            minhp--;
        }
    }
}
