using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goro : AbstractSkill
{
    private string sSkillname = "防御上昇";   //  スキル名称

    private float fCooltime = 15.0f;    //  スキルを再使用できるまでの時間(秒)
    // スキル種別
    public override Skill.SkillKind SkillKind
    {
        get { return Skill.SkillKind.Goro; }
    }

    // スキルクールタイム
    public override float fCoolTime
    {
        get { return fCooltime; }
    }

    //  スキル名
    public override string fName
    {
        get { return sSkillname; }
    }

    // スキル「Goro」の実行
    // 防御力を上昇させるスキル
    public override void Play()
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();

        int atk = player.GetPlayerATK();
        float hp = player.GetPlayerHP();
        int def = player.GetPlayerDEF();

        atk = atk * 3 / 10;
        hp = hp / 10 * 3 + def;

        player.AddPlayerATK((int)atk);
        player.SubPlayerHP((int)hp);
    }
}
