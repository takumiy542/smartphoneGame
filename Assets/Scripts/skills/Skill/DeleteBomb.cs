using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBomb : AbstractSkill
{
    private string sSkillname = "�e����";   //  �X�L������

    private float fCooltime = 15.0f;    //  �X�L�����Ďg�p�ł���܂ł̎���(�b)
    // �X�L�����
    public override Skill.SkillKind SkillKind
    {
        get { return Skill.SkillKind.DeleteBomb; }
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

    // �X�L���uDeleteBomb�v�̎��s
    // �t�B�[���h�ɂ��邷�ׂẴ{��������
    public override void Play()
    {
        //�@�t�B�[���h�S�̂ɍL�����Ă���l�p�I�u�W�F�N�g��I��
        DeleteShot square = GameObject.Find("Square (1)").GetComponent<DeleteShot>();

        //  �Ԃ����Ă���e�̏�������
        square.TriggerTrue();
    }
}
