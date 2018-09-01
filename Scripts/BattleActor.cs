using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class BattleActor {

    private int id;
    private string name;
    private string info;

    private Texture2D characterTexture;
    private int characterIndex;

    private int level; //等级
    private BattleJob battleJob; //职业
    //基础属性值
    private int maxHp;
    private int maxMp;
    
    private int atk; //物理攻击
    private int def;
    private int mtk;
    private int mdf;
    private int speed;
    private int luck;
    private List<BattleSkill> battleSkills; //技能列表




    //附加数据
    private int hp; //当前生命值
    private int mp; //当前魔法值
    private List<BattleStatus> battleStatuses; //战斗状态列表

    public int MaxHp
    {
        get
        {
            return maxHp;
        }

        set
        {
            maxHp = value;
        }
    }

    public int MaxMp
    {
        get
        {
            return maxMp;
        }

        set
        {
            maxMp = value;
        }
    }

    public int Level
    {
        get
        {
            return level;
        }

        set
        {
            level = value;
        }
    }

    public int Atk
    {
        get
        {
            return atk;
        }

        set
        {
            atk = value;
        }
    }

    public int Def
    {
        get
        {
            return def;
        }

        set
        {
            def = value;
        }
    }

    public int Mtk
    {
        get
        {
            return mtk;
        }

        set
        {
            mtk = value;
        }
    }

    public int Mdf
    {
        get
        {
            return mdf;
        }

        set
        {
            mdf = value;
        }
    }

    public int Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }

    public int Luck
    {
        get
        {
            return luck;
        }

        set
        {
            luck = value;
        }
    }

    public int Hp
    {
        get
        {
            return hp;
        }

        set
        {
            hp = value;
        }
    }

    public int Mp
    {
        get
        {
            return mp;
        }

        set
        {
            mp = value;
        }
    }




    //注册角色列表
    private static List<BattleActor> battleActorsList;
    
    public static BattleActor GetBattleActor(int index)
    {
        return battleActorsList[index];
    }

    public static void InitializeBattleActorList()
    {
        battleActorsList = new List<BattleActor>();
        //                                   id  name    picture  pic_index level               job
        BattleActor Lizheng = new BattleActor(0, "李正", "Actor1.png", 0, 1, BattleJob.GetBattleJob(0));



        battleActorsList.Add(Lizheng);
    }



    public BattleActor(int id, string name, string filename, int index,int level, BattleJob battleJob)
    {
        this.id = id;
        this.name = name;
        SetCharacter(filename, index);
        this.level = level;
        this.battleJob = battleJob;
        // 利用等级和职业获取其他基本数据 8项
        maxHp = battleJob.GetMaxHp(level);
        maxMp = battleJob.GetMaxMp(level);
        atk = battleJob.GetAtk(level);
        def = battleJob.GetDef(level);
        mtk = battleJob.GetMtk(level);
        mdf = battleJob.GetMdf(level);
        speed = battleJob.GetSpeed(level);
        luck = battleJob.GetLuck(level);
        //初始化技能列表
        battleSkills = battleJob.GetUsableSkills(level); //危险
        //初始化消耗量
        Hp = maxHp;
        Mp = maxMp;
        battleStatuses = new List<BattleStatus>();



    }

    //设置角色行走图
    public void SetCharacter(string filename, int index)
    {
        characterTexture = Resources.Load<Texture2D>("Graphics/Characters/" + filename);
        characterIndex = index;
        
    }

    public override string ToString()
    {
        return "id: " + id + " name: " + name;
    }


}
