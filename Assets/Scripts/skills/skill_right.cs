using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skill_right : MonoBehaviour
{
    //  �X�L���ۊǗp
    private static Skill.SkillKind selectedSkillKindRight;
    public Text SkillName;      //  �X�L�����\���pUI
    public Text SkillCooltime;  //  �X�L���N�[���^�C���\���pUI
    private float cooltime;     //  �N�[���^�C���ۑ��p�ϐ�

    // Start is called before the first frame update
    void Start()
    {
        //  �{�^���̖��O��ύX
        Skill skillFac = new Skill();
        //  ���O���擾
        string skillname = skillFac.GetName(selectedSkillKindRight);
        //  �X�L�����\��UI�̃e�L�X�g���A�X�L�����ɕύX����
        SkillName.text = skillname;
    }

    // Update is called once per frame
    void Update()
    {
        //  �X�L���Ďg�p�܂ł̎��Ԃ����炷
        //  cooltime �c ActSkill()��0f�ȏ�̒l(�b��)���w�肳���
        //              0f�ȏ�ł����cooltime��Time.deltaTime�̒l�����炷
        if (cooltime > 0.0f)
        {
            //  �Ďg�p�܂ł̎��Ԃ����炷
            cooltime -= Time.deltaTime;

            //  �Ďg�p�܂ł̎��Ԃ�UI�\��
            //  �������ʂ܂ŕ\��
            SkillCooltime.text = string.Format("{0:0.0}", cooltime);
        }        
        //  �X�L���Ďg�p�܂ł̎��Ԃ�0�̂Ƃ��A���Ԃ�����������
        else
        {
            //  �Ďg�p�܂ł̎��Ԃ�������
            cooltime = 0.0f;

            //  �Ďg�p�܂ł̎��Ԃ�UI�\��
            //  �������ʂ܂ŕ\��
            SkillCooltime.text = string.Format("{0:0.0}", cooltime);
        }
    }

    //  �E���̃X�L���̃{�^�����������Ƃ��ɌĂяo���֐�
    public void ActSkill()
    {
        //  �X�L���Ďg�p�܂ł̎��Ԃ�0�̂Ƃ��̂ݏ������s��
        if (cooltime == 0.0f)
        {
            //  �X�L�����擾
            var skillFac = new Skill();
            //  �g�p����X�L�����w�肵�A�擾����
            var skill = skillFac.Create(selectedSkillKindRight);
            
            //  �X�L�����g�p
            skill.Play();

            //  �X�L���Ďg�p�܂ł̎��Ԃ��w��
            cooltime = skill.fCoolTime;

            //Debug.Log("������͂ǂ�");
        }
    }

    //  �E���̃X�L����ύX����
    //  SkillScene�ŁA�g�p����X�L����؂�ւ���ۂɎg�p
    public static void SetSkillRight(Skill.SkillKind skillNum)
    {
        //  �E���̃X�L���ɐݒ肷��X�L�����w��
        selectedSkillKindRight = skillNum;

    }
}
