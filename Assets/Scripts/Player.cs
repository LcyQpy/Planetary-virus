using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    //声明部分
    public float horizontalinput;//水平参数
    public float Verticalinput;//垂直参数
    public float speed = 10.0f;//声明一个参数，没有规定
    public float maxHp = 100;
    public float hp = 0;
    public Scrollbar scrollbar;
    public Joystick joystick;

    //在update中书写
    void Update()
    {
     
        PlayerMove();
        Bar();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            hp--;
        }
    }

    private void Start()
    {
        EnemyManager.Instance.init();
    }

    private void PlayerMove()
    {
        horizontalinput = joystick.Horizontal;
        //AD方向控制
        Verticalinput = joystick.Vertical;
        //WS方向控制
        Vector3 direction = new Vector3(horizontalinput, Verticalinput, 0).normalized;
        //控制该物体向前后移动
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void Bar()
    {
        scrollbar.size = hp / maxHp;
    }

}
