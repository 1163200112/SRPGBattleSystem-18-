using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleParty {

    private List<BattleActor> friendMemebers; //我方队伍
    private List<BattleActor> enemyMembers; //敌方队伍

    public List<BattleActor> FriendMembers
    {
        get
        {
            return friendMemebers;
        }

        set
        {
            friendMemebers = value;
        }
    }

    public List<BattleActor> EnemyMembers
    {
        get
        {
            return enemyMembers;
        }

        set
        {
            enemyMembers = value;
        }
    }


    public static void initializeBattleParty()
    {
        //friendMemebers = new List<BattleActor>();
        //手动设置我方参战者
       // BattleActor lz = BattleActor.battleActorsList[0];

        //friendMemebers.Add(lz);

        //手动设置敌方参战者
        //enemyMembers = new List<BattleActor>();
        //BattleActor lz2 = BattleActor.battleActorsList[0];
        //enemyMembers.Add(lz2);
    }



    public bool IsLost()
    {
        bool lost = true;
        foreach (BattleActor ba in friendMemebers)
        {
            if ( ba.Hp > 0)
            {
                lost = false;
            }
        }
        return lost;
    }
    
    //敌方全灭式的绝对胜利
    public bool IsWin()
    {
        bool win = true;
        foreach(BattleActor ba in EnemyMembers)
        {
            if (ba.Hp > 0)
            {
                win = true;
            }
        }
        return win;
    }
}
