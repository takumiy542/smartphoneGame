using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Benet : AbstractSkill
{
    private string sSkillname = "�U���㏸";   //  �X�L������
    private float fCooltime = 15.0f;        //  �X�L�����Ďg�p�ł���܂ł̎���(�b)
    private int nAddAtk;                    //  ���Z����U����
    private float fContinueTime = 5.0f;     //  �U���͂����Z������Ԃ𑱂��鎞��(�b)

    // �X�L�����
    public override Skill.SkillKind SkillKind
    {
        get { return Skill.SkillKind.Benet; }
        
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

    // �X�L���uBenet�v�̎��s
    // ��莞�Ԃ̊ԁA�U���͂��㏸
    public override void Play()
    {
        //  ��悹����U���͂̒l��ݒ�
        //  �U���͂�1.1�{����
        nAddAtk = player_State.player_ATK / 10;

        //  �e�ŗ^����_���[�W��傫������
        Shot.shotATK += nAddAtk;

        //  �w�莞�Ԍ�A�U���͂����ɖ߂�
        Invoke("Normal", fContinueTime);
    }
    
    //  �U���͂����ɖ߂��֐�
    private void Normal()
    {
        //  �������U���͂�����
        Shot.shotATK -= nAddAtk;
    }
}
