using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropArea : MonoBehaviour
{
    public bool isLeft;     //  ���̃X�N���v�g�������ɂ���G���A���ǂ������C���X�y�N�^�Ŏw��
    private Text text;      //  �e�L�X�gUI�@�u"��(�E)���̃X�L��" �{ �X�L�����v��\��

    // Start is called before the first frame update
    void Start()
    {
        //  �e�L�X�g�R���|�[�l���g���擾
        text = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //  �X�L�����w�肷��I�u�W�F�N�g���͈͓��ɓ��������ɌĂяo���֐�
    //  �s������
    //  �E�Q�[����ʂŎg�p����X�L���̕ύX
    //  �EUI�̃e�L�X�g�ɕύX��̃X�L������\��
    public void SetName(Skill.SkillKind skillKind)
    {
        //  ���̃G���A�������̃X�L�����Z�b�g����ꏊ�ł���΁A�����̃X�L�����Z�b�g����
        if(isLeft)
        {
            //  �w��̃X�L�����Z�b�g����
            skill_left.SetSkillLeft(skillKind);

            //  �e�L�X�gUI�̖��O��ύX����
            Skill skillFac = new Skill();
            //  �X�L���̖��O�擾
            string skillname = skillFac.GetName(skillKind);

            //  �e�L�X�gUI�ɔ��f
            text.text = "�����̃X�L��\n" + skillname;
        }
        else
        {
            //  �w��̃X�L�����Z�b�g����
            skill_right.SetSkillRight(skillKind);

            //  �e�L�X�gUI�̖��O��ύX����
            Skill skillFac = new Skill();
            //  �X�L���̖��O�擾
            string skillname = skillFac.GetName(skillKind);

            //  �e�L�X�gUI�ɔ��f
            text.text = "�E���̃X�L��\n" + skillname;

        }
    }
}
