using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropArea : MonoBehaviour
{
    public bool isLeft;     //  このスクリプトが左側にあるエリアかどうかをインスペクタで指定
    private Text text;      //  テキストUI　「"左(右)側のスキル" ＋ スキル名」を表示

    // Start is called before the first frame update
    void Start()
    {
        //  テキストコンポーネントを取得
        text = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //  スキルを指定するオブジェクトが範囲内に入った時に呼び出す関数
    //  行うこと
    //  ・ゲーム画面で使用するスキルの変更
    //  ・UIのテキストに変更後のスキル名を表示
    public void SetName(Skill.SkillKind skillKind)
    {
        //  このエリアが左側のスキルをセットする場所であれば、左側のスキルをセットする
        if(isLeft)
        {
            //  指定のスキルをセットする
            skill_left.SetSkillLeft(skillKind);

            //  テキストUIの名前を変更する
            Skill skillFac = new Skill();
            //  スキルの名前取得
            string skillname = skillFac.GetName(skillKind);

            //  テキストUIに反映
            text.text = "左側のスキル\n" + skillname;
        }
        else
        {
            //  指定のスキルをセットする
            skill_right.SetSkillRight(skillKind);

            //  テキストUIの名前を変更する
            Skill skillFac = new Skill();
            //  スキルの名前取得
            string skillname = skillFac.GetName(skillKind);

            //  テキストUIに反映
            text.text = "右側のスキル\n" + skillname;

        }
    }
}
