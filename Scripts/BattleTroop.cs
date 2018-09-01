using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTroop : MonoBehaviour {

    private List<BattleEnemy> members;

    public List<BattleEnemy> Members
    {
        get
        {
            return members;
        }

        set
        {
            members = value;
        }
    }


    // Use this for initialization
    void Start () {
        members = new List<BattleEnemy>();
        //手动添加敌人
        BattleEnemy be1 = new BattleEnemy();
        be1.Setup(120, 12, 3);
        be1.SetBattleTex("Assassin.png");

        members.Add(be1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

  
}
