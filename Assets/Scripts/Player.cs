using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public GameObject ShotPrefab;   // 弾のプレハブ用
    public float PlayerSpeed;       //  プレイヤーの移動速度
    public float SpeedFront = 4.0f; //  プレイヤーの正面移動時の移動速度
    public float SpeedSide = 1.0f;  //  プレイヤーの後退時の移動速度
    public float PlayerMaxPosX;     //  プレイヤーが移動できる範囲の最大(右端)のx座標
    public float PlayerMaxPosY;     //  プレイヤーが移動できる範囲の最大(上端)のy座標
    public float PlayerMinPosY;     //  プレイヤーが移動できる範囲の最小(左端)のx座標

    //==========================================================
    //  プレイヤーステータス
    //  最大HP
    [SerializeField] private int playerMAXHP;
    //  現在HP
    private float playerHP;
    private GameObject HPbar;
    //  攻撃力
    [SerializeField] private int playerAtk;
    //  防御力
    [SerializeField] private int playerDef;
    //==========================================================


    //=====static変数=====================================================
    //  入手コイン枚数
    //  ゲームオーバー時に表示させるためにstaticにする
    public static int nCoins;
    
    //  経過時間保存用
    //  ゲームオーバー時に表示させるためにstaticにする
    public static float WorldTime;
    //====================================================================

    //======音関連====================================================
    public AudioSource asBGM;
    public AudioSource asSE;
    public AudioClip acShot;
    public AudioClip acCoin;
    public AudioClip acExplosoion;
    //================================================================


    //  プレイヤーが倒されたときの爆発エフェクト用
    public GameObject MyExplosionPrefab;


    //=====private変数=====================================================
    //  移動時に使用するジョイスティック
    [SerializeField] private Joystick joystick;

    //  弾発射間隔の時間管理用用
    private float shotTime;
    
    //  現在のコイン枚数表示用UI
    private Text coin_text;

    //  プレイヤー保存用
    private Player player;
    //==========================================================

    // Start is called before the first frame update
    void Start()
    {
        //  HPバー初期化
        HPbar = GameObject.Find("HPBar");

        //  取得したコイン表示
        coin_text = GameObject.Find("coins").GetComponent<Text>();

        //  プレイヤーステータス初期化
        playerMAXHP = player_State.player_HP;
        playerAtk = player_State.player_ATK;
        playerDef = player_State.player_DEF;

        //  HPを最大値まで戻す
        playerHP = playerMAXHP;

        //  時間リセット
        WorldTime = 0.0f;
        shotTime = 0.2f;

        //  お金リセット
        nCoins = 0;

        //  BGM
        asBGM.Play();
    }
    
    // Update is called once per frame
    void Update()
    {
        
        //  時間を加算
        WorldTime += Time.deltaTime;
    }
    public void SubPlayerHP(int damage)
    {
        //  ダメージを受ける
        playerHP -= (damage - playerDef);

        if(playerHP > playerMAXHP)
        {
            playerHP = playerMAXHP;
        }

        //  HPバーを減らす
        HPbar.GetComponent<Image>().fillAmount = playerHP / playerMAXHP;

        if (playerHP <= 0)
        {
            //  爆発アニメ用ゲームオブジェクト生成
            GameObject explo = Instantiate(MyExplosionPrefab);
            //  爆発の位置を敵に合わせる
            explo.transform.position = transform.position;

            //  マネージャーが持つフラグをONにする
            MyShipManager.MyShipMissFlg = true;

            //  プレイヤーを消去
            Destroy(this.gameObject);
        }
    }
    private void FixedUpdate()
    {
        // 変数準備
        // 水平移動量を取得
        float inputX;
        // 垂直移動量を取得
        float inputY;

        Vector2 direction;
        //  移動処理
        if (joystick)
        {
            inputX = joystick.Horizontal;
            inputY = joystick.Vertical;
            direction = joystick.Direction;
            Debug.Log("joyOn");


            // 移動処理
            // 指定向きに移動
            Vector3 pos = transform.position;
            pos += transform.forward * inputY * (inputY > 0 ? SpeedFront : SpeedFront / 4.0f) * Time.deltaTime;
            pos += transform.right * inputX * SpeedSide * Time.deltaTime;

            transform.position = pos;

            transform.Translate(joystick.Direction * PlayerSpeed);

            // transformはゲームオブジェクトの基本的な情報。
            // メンバであるTranslateはオブジェクトに与えられる移動量。
            // コントローラ情報などをそのまま与えると速すぎるので、
            // 係数を乗算して適当な値に抑えられる必要がある。
            if (transform.position.x >= PlayerMaxPosX)
            {
                transform.position = new Vector3(PlayerMaxPosX, transform.position.y, transform.position.z);
            }
            if (transform.position.y >= PlayerMaxPosY)
            {
                transform.position = new Vector3(transform.position.x, PlayerMaxPosY, transform.position.z);
            }
            if (transform.position.x <= -PlayerMaxPosX)
            {
                transform.position = new Vector3(-PlayerMaxPosX, transform.position.y, transform.position.z);
            }
            if (transform.position.y <= PlayerMinPosY)
            {
                transform.position = new Vector3(transform.position.x, PlayerMinPosY, transform.position.z);
            }
        }

        // 弾の発射
        // プレハブ設定があれば
        if (ShotPrefab != null)
        {
            if (shotTime < 0.0f)
            {
                // 新たに弾のゲームオブジェクトを生成させる
                GameObject shot = Instantiate(ShotPrefab);

                //  SE再生
                asSE.clip = acShot;
                asSE.volume = 0.2f;
                asSE.Play();
                
                // 弾の初期座標を自機と同じにする
                shot.transform.position = transform.position + new Vector3(0.0f, 0.8f, 0.0f);

                //  shottime初期化
                shotTime = 0.2f;
            }
            else
            {
                shotTime -= Time.deltaTime;
            }
        }

    }
    // 敵との当たり判定
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 当たった相手のタグを見て敵だったら
        if (collision.gameObject.tag == "Enemy")
        {
            //  HP減少
            SubPlayerHP(50);

            // ゲームオーバーシーンを読み込んでシーン変更
            //SceneManager.LoadScene("GameOver");

            asSE.clip = acExplosoion;
            asSE.Play();

            //  敵を破壊
            Destroy(collision.gameObject);
        }
        //  当たった相手のタグを見て敵の弾だったら
        if (collision.gameObject.tag == "EnemyShot")
        {
            //  HP減少
            //  時間経過でダメージが増える
            SubPlayerHP(30 + (int)(WorldTime/5));

            // ゲームオーバーシーンを読み込んでシーン変更
            //SceneManager.LoadScene("GameOver");

            //  他クラスが持つpublicな変数へのアクセスは、
            //  クラス名.変数名で可能になる

            asSE.clip = acExplosoion;
            asSE.Play();

            //  弾消滅
            Destroy(collision.gameObject);
        }
        //  当たった相手のタグを見てコインだったら
        if (collision.gameObject.tag == "Coin")
        {
            nCoins += 100;
            player_State.player_Coins += 100;

            coin_text.GetComponent<Text>().text = "Coins：$" + string.Format("{0}", nCoins);

            asSE.clip = acCoin;
            asSE.Play();

            Destroy(collision.gameObject);
        }
    }

    //  攻撃力を返す
    public int GetPlayerATK()
    {
        return playerAtk;
    }
    //  攻撃力増加
    public void AddPlayerATK(int num)
    {
        playerAtk += num;
    }
    //  防御力を返す
    public int GetPlayerDEF()
    {
        return playerDef;
    }
    //  防御力増加
    public void AddPlayerDEF(int num)
    {
        playerDef += num;
    }
    //  体力を返す
    public float GetPlayerHP()
    {
        return playerHP;
    }
    //  最大体力を返す
    public float GetPlayerMAXHP()
    {
        return playerMAXHP;
    }
}
