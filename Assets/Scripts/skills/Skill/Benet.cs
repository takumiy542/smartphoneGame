using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Benet : AbstractSkill
{
    private string sSkillname = "攻撃上昇";   //  スキル名称
    private float fCooltime = 15.0f;        //  スキルを再使用できるまでの時間(秒)
    private int nAddAtk;                    //  加算する攻撃力
    private float fContinueTime = 5.0f;     //  攻撃力を加算した状態を続ける時間(秒)

    // スキル種別
    public override Skill.SkillKind SkillKind
    {
        get { return Skill.SkillKind.Benet; }
        
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

    // スキル「Benet」の実行
    // 一定時間の間、攻撃力を上昇
    public override void Play()
    {
        //  上乗せする攻撃力の値を設定
        //  攻撃力を1.1倍する
        nAddAtk = player_State.player_ATK / 10;

        //  弾で与えるダメージを大きくする
        Shot.shotATK += nAddAtk;

        //  指定時間後、攻撃力を元に戻す
        Invoke("Normal", fContinueTime);
    }
    
    //  攻撃力を元に戻す関数
    private void Normal()
    {
        //  足した攻撃力を引く
        Shot.shotATK -= nAddAtk;
    }
}
