using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeckScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    //  シーン遷移
    //  Title(タイトル画面)に遷移
    public void BackTitle()
    {
        SceneManager.LoadScene("Title");
    }

    //  シーン遷移
    //  SkillScene(スキル組み換えシーン)に遷移
    public void GoSkill()
    {
        SceneManager.LoadScene("SkillScene");
    }
}
