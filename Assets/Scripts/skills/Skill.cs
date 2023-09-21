using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Linq;
using UnityEngine.UI;

public class Skill
{
    // �X�L���ꗗ
    static readonly AbstractSkill[] skills = {
        new Benet(),
        new Nana(),
        new Goro(),
        new DeleteBomb()
    };

    // �X�L����enum
    public enum SkillKind
    {
        Benet,
        Nana,
        Goro,
        DeleteBomb
    }

    // SkillKind�������ɁA����ɉ������X�L����Ԃ�
    public AbstractSkill Create(SkillKind skillKind)
    {
        return skills.SingleOrDefault(skill => skill.SkillKind == skillKind);
    }

    //  SkillKind�������ɁA����ɉ������X�L���̖��O��Ԃ�
    //  ���������������s���璷�ɂȂ����̂Œǉ�
    public string GetName(SkillKind skillKind)
    {
        //  �e�L�X�gUI�̖��O��ύX����
        var skillFac = new Skill();
        var skill = skillFac.Create(skillKind);
        
        //  �X�L���̖��O��ԋp����
        return skill.fName;
    }
}
