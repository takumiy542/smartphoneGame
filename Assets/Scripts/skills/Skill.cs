using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Linq;
using UnityEngine.UI;

public class Skill
{
    // スキル一覧
    static readonly AbstractSkill[] skills = {
        new Benet(),
        new Nana(),
        new Goro(),
        new DeleteBomb()
    };

    // スキルのenum
    public enum SkillKind
    {
        Benet,
        Nana,
        Goro,
        DeleteBomb
    }

    // SkillKindを引数に、それに応じたスキルを返す
    public AbstractSkill Create(SkillKind skillKind)
    {
        return skills.SingleOrDefault(skill => skill.SkillKind == skillKind);
    }

    //  SkillKindを引数に、それに応じたスキルの名前を返す
    //  同じ処理が複数行われ冗長になったので追加
    public string GetName(SkillKind skillKind)
    {
        //  テキストUIの名前を変更する
        var skillFac = new Skill();
        var skill = skillFac.Create(skillKind);
        
        //  スキルの名前を返却する
        return skill.fName;
    }
}
