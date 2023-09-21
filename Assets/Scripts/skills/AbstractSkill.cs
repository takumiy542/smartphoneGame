using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

abstract public class AbstractSkill : MonoBehaviour
{
    // スキル種別の抽象プロパティ
    public abstract Skill.SkillKind SkillKind { get; }

    // スキル実行の抽象メソッド
    public abstract void Play();

    // スキルクールタイムの抽象プロパティ
    public abstract float fCoolTime { get; }

    // スキル名の抽象プロパティ
    public abstract string fName { get; }
}
