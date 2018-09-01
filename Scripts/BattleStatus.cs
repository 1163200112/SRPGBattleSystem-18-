using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStatus {

    private int id;
    private string name;
    private Texture2D icon;
    private string info;

    //附加状态数据：
    private bool dead = false;
    private int hpAdd = 0;
    private int mpAdd = 0;
    private int atkAdd = 0;
    private int defAdd = 0;

    private static List<BattleStatus> battleStatusesList; //注册状态列表

    // 初始化数据库
    public static void InitializeBattleStatusList()
    {
        battleStatusesList = new List<BattleStatus>();
        //                                     id   name   texture2D              dead?  hpadd mpadd atkadd defadd
        battleStatusesList.Add(new BattleStatus(0, "阵亡", new Texture2D(32, 32), true, 0, 0, 0, 0));
    }

    //获取战斗状态（按序号）
    public static BattleStatus GetBattleStatus(int index)
    {
        return battleStatusesList[index];
    }

    private BattleStatus(int id, string name, Texture2D icon, bool dead)
    {
        this.id = id;
        this.name = name;
        this.icon = icon;
        this.dead = dead;
    }

    private BattleStatus(int id, string name, Texture2D icon, bool dead, int hpAdd, int mpAdd, int atkAdd, int defAdd)
    {
        this.id = id;
        this.name = name;
        this.icon = icon;
        this.dead = dead;
        this.hpAdd = hpAdd;
        this.mpAdd = mpAdd;
        this.atkAdd = atkAdd;
        this.defAdd = defAdd;
    }
}
