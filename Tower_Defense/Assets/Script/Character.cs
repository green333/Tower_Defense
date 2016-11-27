﻿using UnityEngine;
using System.Collections;


[System.Serializable]
class Status
{
    public int hp = 0;        //体力
    public int attack = 0;    //攻撃
    public int defense = 0;   //防御
    public float spd = 0.0f;     //速度
}



public class Character : MonoBehaviour {

    //-----------------------
    //  プレイヤーの状態
    //-----------------------
    protected enum P_State
    {
        MOVE = 0,                 //操作する
        ATTACK,                   //攻撃する
        DAMAGE,                   //ダメージ
        DEAD,                     //死亡
    }

    [SerializeField]
    private P_State p_state;

    [SerializeField]
    Status info;      //ステータス情報

    [SerializeField]
    private new Rigidbody rigidbody;     //Rigidbody2D

    [SerializeField]
    protected Animator animator;          //アニメーション


    //------------------------------------------

    //  初期化

    //------------------------------------------
    void Start()
    {

    }

    //------------------------------------------

    //  更新

    //------------------------------------------
    void Update()
    {
        switch (p_state)
        {
            case P_State.MOVE:
                Move();
                break;

            case P_State.ATTACK:
                Attack();
                break;

            case P_State.DAMAGE:
                break;

            case P_State.DEAD:
                Dead();
                break;
        }

    }


    //------------------------------------------

    //  物理挙動がある時

    //------------------------------------------
    void FixedUpdate()
    {

    }



    //------------------------------------------

    //  移動

    //------------------------------------------
    public void Move()
    {

        rigidbody.velocity = new Vector2(info.spd, rigidbody.velocity.y);
    }

    //------------------------------------------

    //  攻撃

    //------------------------------------------
    void Attack()
    {
    }

    //------------------------------------------

    //  ダメージ

    //------------------------------------------
    void Damage()
    {

    }

    //------------------------------------------

    //  死亡

    //------------------------------------------
    void Dead()
    {

    }

    //------------------------------------------

    //  範囲内に入れば動かない

    //------------------------------------------
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            p_state = P_State.ATTACK;
        }
    }


    //------------------------------------------

    //  範囲外に行けば動く

    //------------------------------------------
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            p_state = P_State.MOVE;
        }
    }




}
