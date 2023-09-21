using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// シーンに変更に必要
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public AudioSource asSelect;    //  決定時SE
    public AudioSource asBGM;       //  タイトル画面BGM

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(asSelect);
        asBGM.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.Escape))
        //{
        //    Application.Quit();
        //}
    }
    public void ChangeGame()
    {
        //  ゲームシーンへ遷移
        SceneManager.LoadScene("Stage1");
        //  SE再生
        asSelect.Play();
    }
    public void ChangeDeck()
    {
        //  ステータス強化画面へ遷移
        SceneManager.LoadScene("DeckScene");
        //  SE再生
        asSelect.Play();
    }
}
