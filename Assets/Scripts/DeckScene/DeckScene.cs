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
    
    //  �V�[���J��
    //  Title(�^�C�g�����)�ɑJ��
    public void BackTitle()
    {
        SceneManager.LoadScene("Title");
    }

    //  �V�[���J��
    //  SkillScene(�X�L���g�݊����V�[��)�ɑJ��
    public void GoSkill()
    {
        SceneManager.LoadScene("SkillScene");
    }
}
