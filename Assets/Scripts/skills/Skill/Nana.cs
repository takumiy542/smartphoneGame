using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nana : AbstractSkill
{
    private string sSkillname = "��";   //  �X�L������

    private float fCooltime = 15.0f;    //  �X�L�����Ďg�p�ł���܂ł̎���(�b)
    // �X�L�����
    public override Skill.SkillKind SkillKind
    {
        get { return Skill.SkillKind.Nana; }
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

    // �X�L���uNana�v�̎��s
    // �����񕜂��s���X�L��
    public override void Play()
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();
        
        float hp = player.GetPlayerMAXHP();
        int def = player.GetPlayerDEF();
        
        //  �ő�HP��20%����
        //  �񕜎��Ɏg�p����֐��̎d�l��A�h��͂̒l��HP�̒l���猸�炷
        hp = hp / 5 - def;
        
        //  �w�肵���ʂ̃_���[�W��^����
        //�@�񕜂Ȃ̂ŁA���̐����w�肷��
        player.SubPlayerHP((int)-hp);
    }
}
