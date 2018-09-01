using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {



    private BattleParty battleParty;
    //private BattleTroop battleTroop;

    private List<BattleActor> battleOrderList;

    enum BattleState {
        startBattle, startTurn, inTurn, finishTurn, finishBattle
    }
    BattleState battleState; //战斗状态

    //初始化战斗管理器
    public BattleManager()
    {
        //初始化数据库
        initializeBattleObjects();
    }


    // Use this for initialization
    void Start () {
        

        battleParty = new BattleParty(); //产生战斗集团

        battleState = BattleState.startBattle; //初始化战斗状态
	}
	
	// Update is called once per frame
	void Update () {
        switch (battleState)
        {
            case BattleState.startBattle:

                battleState = BattleState.startTurn;
                break;
            case BattleState.startTurn:
                battleOrderList = makeBattleOrder(); //生成战斗顺序
                Debug.Log(battleOrderList); //显示顺序
                battleState = BattleState.inTurn;
                break;
            case BattleState.inTurn:
                foreach (BattleActor ba in battleOrderList)
                {
                    //ProcessAction(ba); //处理角色的行动
                    //IsAnyoneDead(); //判定是否死亡
                    IsBattleEnd(); //判定战斗是否结束
                }
                battleState = BattleState.finishTurn;
                break;
            case BattleState.finishTurn:
                //updateStatus(); //更新状态列表（延时技能）
                battleState = BattleState.startTurn;
                break;
            case BattleState.finishBattle:
                //endBattle(); //结束战斗
                break;

        } 
		
        
	}

    //观察战斗结果
    private void IsBattleEnd()
    {
        if (battleParty.IsLost()) //我方失败
        {
            Debug.Log("You are lost!");
            battleState = BattleState.finishBattle;
        }
        else if (battleParty.IsWin()) //我方胜利
        {
            Debug.Log("You are win!");
            battleState = BattleState.finishBattle;
        }
    }

    /* 
     * 生成战斗列表
     */

    List<BattleActor>  makeBattleOrder()
    {
        List<BattleActor> battlers = new List<BattleActor>();
        //添加友军
        foreach(BattleActor ba in battleParty.FriendMembers)
        {
            battlers.Add(ba);
        }
        //添加敌军
        foreach (BattleActor ba in battleParty.EnemyMembers)
        {
            battlers.Add(ba);
        }
        battlers.Sort(new SpeedComparer());
        return battlers;
    }

    // 初始化战斗数据库
    private void initializeBattleObjects()
    {
        BattleSkill.InitializeBattleSkills();
        BattleStatus.InitializeBattleStatusList();
        
        BattleJob.InitializeBattleJobList();
        BattleActor.InitializeBattleActorList();
    }
}

class SpeedComparer : IComparer<BattleActor>
{

    public int Compare(BattleActor x, BattleActor y)
    {
        System.Random rd = new System.Random();
        int xSpeed = x.Level + x.Speed * 4 + rd.Next(x.Speed); //未完成：要减去负重
        int ySpeed = y.Level + y.Speed * 4 + rd.Next(y.Speed);
        return xSpeed.CompareTo(ySpeed);
    }
}
