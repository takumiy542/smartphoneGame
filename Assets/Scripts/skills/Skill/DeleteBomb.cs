using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBomb : AbstractSkill
{
    private string sSkillname = "弾消去";   //  スキル名称

    private float fCooltime = 15.0f;    //  スキルを再使用できるまでの時間(秒)
    // スキル種別
    public override Skill.SkillKind SkillKind
    {
        get { return Skill.SkillKind.DeleteBomb; }
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

    // スキル「DeleteBomb」の実行
    // フィールドにあるすべてのボムを消去
    public override void Play()
    {
        //　フィールド全体に広がっている四角オブジェクトを選択
        DeleteShot square = GameObject.Find("Square (1)").GetComponent<DeleteShot>();

        //  ぶつかっている弾の消去処理
        square.TriggerTrue();
    }
}
