using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleJob {

    //基本数据
    private int id;
    private string name;

    //职业技能列表 技能序号=>需求等级
    public Dictionary<int, int> jobSkillsList;

    //计算公式： 
    //修正参数
    private float paramHp_a = 1f;
    private float paramHp_b = 1f;

    private float paramMp_a = 1f;
    private float paramMp_b = 1f;

    private float paramAtk_a = 1f;
    private float paramAtk_b = 1f;

    private float paramDef_a = 1f;
    private float paramDef_b = 1f;

    private float paramMtk_a = 1f;
    private float paramMtk_b = 1f;

    private float paramMef_a = 1f;
    private float paramMef_b = 1f;

    private float paramSpeed_a = 1f;
    private float paramSpeed_b = 1f;

    private float paramLuck_a = 1f;
    private float paramLuck_b = 1f;
    // 
   

    //注册战斗职业列表
    private static List<BattleJob> battleJobsList;

    public static void InitializeBattleJobList()
    {
        battleJobsList = new List<BattleJob>();

        //添加新职业
        BattleJob people = new BattleJob(0, "平民");
        people.jobSkillsList.Add(0, 0); //0 攻击技能； 0 0级即可使用
        battleJobsList.Add(people);
    }

    public static BattleJob GetBattleJob(int index)
    {
        return battleJobsList[index];
    }
	
    // 构造器
    private BattleJob(int id, string name)
    {
        this.id = id;
        this.name = name;
        this.jobSkillsList = new Dictionary<int, int>();
    }

    //曲线修正函数
    private void SetHpCurve(float a, float b)
    {
        paramHp_a = a;
        paramHp_b = b;
    }
    private void SetMpCurve(float a, float b)
    {
        paramMp_a = a;
        paramMp_b = b;
    }


    // y = a*100 + lv^(3/2) *10*b
    public int GetMaxHp(int level)
    {
        return (int)(paramHp_a * 100 + Mathf.Pow(1.5f, level) * 10 * paramHp_b);
    }

    // y = a*20 + lv^(3/2) *2*b
    public int GetMaxMp(int level)
    {
        return (int)(paramMp_a * 20 + Mathf.Pow(1.5f, level) * 2 * paramMp_b);
    }
    //未编码
    public int GetAtk(int level)
    {
        return 20;
    }

    public int GetDef(int level)
    {
        return 2;
    }

    public int GetMtk(int level)
    {
        return 15;
    }

    public int GetMdf(int level)
    {
        return 2;
    }

    public int GetSpeed(int level)
    {
        return 3;
    }

    public int GetLuck(int level)
    {
        return 5;
    }

    //获取可用技能 这个函数必须在技能列表初始化之后调用否则会出现空指针
    public List<BattleSkill> GetUsableSkills(int level)
    {
        List<BattleSkill> result = new List<BattleSkill>();
        foreach (int skillId in jobSkillsList.Keys)
        {
            if (jobSkillsList[skillId] <= level)
            {
                result.Add(BattleSkill.GetBattleSkill(skillId));
            }
        }
        return result;
    }
   
}
