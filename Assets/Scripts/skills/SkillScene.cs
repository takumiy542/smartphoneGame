using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkillScene : MonoBehaviour
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
    //  DeckScene(�X�e�[�^�X�������)�Ɉړ�
    public void BackDeck()
    {
        SceneManager.LoadScene("DeckScene");
    }
}
