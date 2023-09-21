using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goro : AbstractSkill
{
    private string sSkillname = "�h��㏸";   //  �X�L������

    private float fCooltime = 15.0f;    //  �X�L�����Ďg�p�ł���܂ł̎���(�b)
    // �X�L�����
    public override Skill.SkillKind SkillKind
    {
        get { return Skill.SkillKind.Goro; }
    }

    // �X�L���N�[���^�C��
    public override float fCoolTime
    {
        get { return fCooltime; }
    }

    //  �X�L����
    public override string fName
    {
        get { return sSkillname; }
    }

    // �X�L���uGoro�v�̎��s
    // �h��͂��㏸������X�L��
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
