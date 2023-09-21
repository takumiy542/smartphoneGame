using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skill_right : MonoBehaviour
{
    //  スキル保管用
    private static Skill.SkillKind selectedSkillKindRight;
    public Text SkillName;      //  スキル名表示用UI
    public Text SkillCooltime;  //  スキルクールタイム表示用UI
    private float cooltime;     //  クールタイム保存用変数

    // Start is called before the first frame update
    void Start()
    {
        //  ボタンの名前を変更
        Skill skillFac = new Skill();
        //  名前を取得
        string skillname = skillFac.GetName(selectedSkillKindRight);
        //  スキル名表示UIのテキストを、スキル名に変更する
        SkillName.text = skillname;
    }

    // Update is called once per frame
    void Update()
    {
        //  スキル再使用までの時間を減らす
        //  cooltime … ActSkill()で0f以上の値(秒数)を指定される
        //              0f以上であればcooltimeをTime.deltaTimeの値分減らす
        if (cooltime > 0.0f)
        {
            //  再使用までの時間を減らす
            cooltime -= Time.deltaTime;

            //  再使用までの時間をUI表示
            //  少数第一位まで表示
            SkillCooltime.text = string.Format("{0:0.0}", cooltime);
        }        
        //  スキル再使用までの時間が0のとき、時間を初期化する
        else
        {
            //  再使用までの時間を初期化
            cooltime = 0.0f;

            //  再使用までの時間をUI表示
            //  少数第一位まで表示
            SkillCooltime.text = string.Format("{0:0.0}", cooltime);
        }
    }

    //  右側のスキルのボタンを押したときに呼び出す関数
    public void ActSkill()
    {
        //  スキル再使用までの時間が0のときのみ処理を行う
        if (cooltime == 0.0f)
        {
            //  スキルを取得
            var skillFac = new Skill();
            //  使用するスキルを指定し、取得する
            var skill = skillFac.Create(selectedSkillKindRight);
            
            //  スキルを使用
            skill.Play();

            //  スキル再使用までの時間を指定
            cooltime = skill.fCoolTime;

            //Debug.Log("すきるはつどう");
        }
    }

    //  右側のスキルを変更する
    //  SkillSceneで、使用するスキルを切り替える際に使用
    public static void SetSkillRight(Skill.SkillKind skillNum)
    {
        //  右側のスキルに設定するスキルを指定
        selectedSkillKindRight = skillNum;

    }
}
