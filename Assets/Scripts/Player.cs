using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    //��������
    public float horizontalinput;//ˮƽ����
    public float Verticalinput;//��ֱ����
    public float speed = 10.0f;//����һ��������û�й涨
    public float maxHp = 100;
    public float hp = 0;
    public Scrollbar scrollbar;
    public Joystick joystick;

    //��update����д
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
        //AD�������
        Verticalinput = joystick.Vertical;
        //WS�������
        Vector3 direction = new Vector3(horizontalinput, Verticalinput, 0).normalized;
        //���Ƹ�������ǰ���ƶ�
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void Bar()
    {
        scrollbar.size = hp / maxHp;
    }

}
