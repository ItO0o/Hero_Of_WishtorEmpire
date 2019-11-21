using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHero : MonoBehaviour
{
    //インスペクターで速度を設定する
    public float speed;
    //Rigidbody2Dを格納するプライベート変数
    private Rigidbody2D rb = null;

    //Heroに追従するカメラオブジェクト
    public GameObject mainCamera;
    //z軸を調整。正の数ならプレイヤーの前に、負の数ならプレイヤーの後ろに配置する
    public int zAdjust = -10;

    //ジャンプ力
    float jumpForce = 390.0f;       // ジャンプ時に加える力
    //ジャンプ時地面接触判定用
    bool jump = false;


    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody2Dを格納する
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ////カメラを追従させるスクリプト
        //カメラはプレイヤーと同じ位置にする
        mainCamera.transform.position = new Vector3(transform.position.x, 4, transform.position.z + zAdjust);

        ////Heroを動かすスクリプト
        //horizontalKeyに，-1か1を格納する．左=-1，右=1
        float horizontalKey = Input.GetAxis("Horizontal");
        //最終的なスピード
        float xSpeed = 0.0f;
        if (horizontalKey > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            xSpeed = speed;
        }
        else if (horizontalKey < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            xSpeed = -speed;
        }
        else
        {
            xSpeed = 0.0f;
        }
        //速度を加えて動かす
        rb.velocity = new Vector2(xSpeed, rb.velocity.y);

        //ジャンプ制御用
        if (Input.GetKeyDown("space") && !jump)
        {
            rb.AddForce(Vector2.up * this.jumpForce);
            jump = true;//ジャンプを消費
        }

    }

    //接触時判定
    void OnCollisionEnter2D(Collision2D other)
    {
        //接触したらジャンプを回復
        jump = false;
    }
}
