using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum SkillAim { myself, onlyEnemy, onlyFriend, onlyEnemies, onlyFriends, AOE, envAOE }


public class BattleSkill {

    private int id;
    private string name;
    private Texture2D icon;

    private SkillAim skillAim; //攻击类型
    private int mpCost; //魔力消耗
    private int sustain; //持续回合 0代表瞬发技能
    private List<BattleStatus> battleStatuses; //附加状态列表, 为null时代表没有附加任何状态

    private static List<BattleSkill> battleSkillsList; //注册战斗技能列表

    //按序号获取战斗技能
    public static BattleSkill GetBattleSkill(int index)
    {
        return battleSkillsList[index];
    }

    public static void InitializeBattleSkills()
    {
        battleSkillsList = new List<BattleSkill>();

        // 0 攻击 
        BattleSkill attack = new BattleSkill(0, "攻击", new Texture2D(32, 32));
        attack.Setup(SkillAim.onlyEnemy, 0, 0, null);
        battleSkillsList.Add(attack);
    }
       

    // 构造器
    public BattleSkill(int id, string name, Texture2D icon)
    {
        this.id = id;
        this.name = name;
        this.icon = icon;
    }
    // 赋值函数
    void Setup(SkillAim skillAim, int mpCost, int sustain, List<BattleStatus> battleStatuses)
    {
        this.skillAim = skillAim;
        this.mpCost = mpCost;
        this.sustain = sustain;
        this.battleStatuses = battleStatuses;
    }
}
