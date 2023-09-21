using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skill_left : MonoBehaviour
{
    //  �����̃{�^���������Ɏg���X�L���ۊǗp�ϐ�
    private static Skill.SkillKind selectedSkillKindLeft;
    public Text SkillName;      //  �X�L�����\���pUI
    public Text SkillCooltime;  //  �X�L���N�[���^�C���\���pUI
    private float cooltime;     //  �N�[���^�C���ۑ��p�ϐ�

    // Start is called before the first frame update
    void Start()
    {
        
        //  �{�^���̖��O��ύX
        Skill skillFac = new Skill();
        string skillname = skillFac.GetName(selectedSkillKindLeft);
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

    //  �����̃X�L���̃{�^�����������Ƃ��ɌĂяo���֐�
    public void ActSkill()
    {
        //  �X�L���Ďg�p�܂ł̎��Ԃ�0�̂Ƃ��̂ݏ������s��
        if (cooltime == 0.0f)
        {
            //  �X�L�����擾
            var skillFac = new Skill();
            //  �g�p����X�L�����w�肵�A�擾����
            var skill = skillFac.Create(selectedSkillKindLeft);
            //  �X�L�����g�p
            skill.Play();

            //  �X�L���Ďg�p�܂ł̎��Ԃ��w��
            cooltime = skill.fCoolTime;

            //Debug.Log("������͂ǂ�");
        }
    }

    //  �����̃X�L����ύX����
    //  SkillScene�ŁA�g�p����X�L����؂�ւ���ۂɎg�p
    public static void SetSkillLeft(Skill.SkillKind skillNum)
    {
        //  �����̃X�L���ɐݒ肷��X�L�����w��
        selectedSkillKindLeft = skillNum;

    }

}
