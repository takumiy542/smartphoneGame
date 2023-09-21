using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nana : AbstractSkill
{
    private string sSkillname = "回復";   //  スキル名称

    private float fCooltime = 15.0f;    //  スキルを再使用できるまでの時間(秒)
    // スキル種別
    public override Skill.SkillKind SkillKind
    {
        get { return Skill.SkillKind.Nana; }
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

    // スキル「Nana」の実行
    // 即時回復を行うスキル
    public override void Play()
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();
        
        float hp = player.GetPlayerMAXHP();
        int def = player.GetPlayerDEF();
        
        //  最大HPの20%を回復
        //  回復時に使用する関数の仕様上、防御力の値分HPの値から減らす
        hp = hp / 5 - def;
        
        //  指定した量のダメージを与える
        //　回復なので、負の数を指定する
        player.SubPlayerHP((int)-hp);
    }
}
