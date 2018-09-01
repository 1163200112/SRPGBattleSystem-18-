using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 战斗者的共通类，为BattleActor 和 BattleEnemy 的父类
 * 
 */
public class BattleBase : MonoBehaviour {

    private int maxHp;
    private int maxMp;
    private int patk;
    private int pdef;

    private int agi;
    private int luk;

    private int hp;
 

    public int Agi
    {
        get
        {
            return agi;
        }

        set
        {
            agi = value;
        }
    }

    

    // Use this for initialization
    void Start () {
		
	}

	
	// Update is called once per frame
	void Update () {
		
	}

    //赋予生命值和攻击力
    public void Setup(int maxHp, int patk, int agi)
    {
        this.maxHp = maxHp;
        this.patk = patk;
        this.Agi = agi;
    }
    

    //战斗者是否死亡
    public bool IsDeath()
    {
        return (hp <= 0);
    }

}
