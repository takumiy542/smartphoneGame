using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public GameObject ShotPrefab;   // �e�̃v���n�u�p
    public float PlayerSpeed;       //  �v���C���[�̈ړ����x
    public float SpeedFront = 4.0f; //  �v���C���[�̐��ʈړ����̈ړ����x
    public float SpeedSide = 1.0f;  //  �v���C���[�̌�ގ��̈ړ����x
    public float PlayerMaxPosX;     //  �v���C���[���ړ��ł���͈͂̍ő�(�E�[)��x���W
    public float PlayerMaxPosY;     //  �v���C���[���ړ��ł���͈͂̍ő�(��[)��y���W
    public float PlayerMinPosY;     //  �v���C���[���ړ��ł���͈͂̍ŏ�(���[)��x���W

    //==========================================================
    //  �v���C���[�X�e�[�^�X
    //  �ő�HP
    [SerializeField] private int playerMAXHP;
    //  ����HP
    private float playerHP;
    private GameObject HPbar;
    //  �U����
    [SerializeField] private int playerAtk;
    //  �h���
    [SerializeField] private int playerDef;
    //==========================================================


    //=====static�ϐ�=====================================================
    //  ����R�C������
    //  �Q�[���I�[�o�[���ɕ\�������邽�߂�static�ɂ���
    public static int nCoins;
    
    //  �o�ߎ��ԕۑ��p
    //  �Q�[���I�[�o�[���ɕ\�������邽�߂�static�ɂ���
    public static float WorldTime;
    //====================================================================

    //======���֘A====================================================
    public AudioSource asBGM;
    public AudioSource asSE;
    public AudioClip acShot;
    public AudioClip acCoin;
    public AudioClip acExplosoion;
    //================================================================


    //  �v���C���[���|���ꂽ�Ƃ��̔����G�t�F�N�g�p
    public GameObject MyExplosionPrefab;


    //=====private�ϐ�=====================================================
    //  �ړ����Ɏg�p����W���C�X�e�B�b�N
    [SerializeField] private Joystick joystick;

    //  �e���ˊԊu�̎��ԊǗ��p�p
    private float shotTime;
    
    //  ���݂̃R�C�������\���pUI
    private Text coin_text;

    //  �v���C���[�ۑ��p
    private Player player;
    //==========================================================

    // Start is called before the first frame update
    void Start()
    {
        //  HP�o�[������
        HPbar = GameObject.Find("HPBar");

        //  �擾�����R�C���\��
        coin_text = GameObject.Find("coins").GetComponent<Text>();

        //  �v���C���[�X�e�[�^�X������
        playerMAXHP = player_State.player_HP;
        playerAtk = player_State.player_ATK;
        playerDef = player_State.player_DEF;

        //  HP���ő�l�܂Ŗ߂�
        playerHP = playerMAXHP;

        //  ���ԃ��Z�b�g
        WorldTime = 0.0f;
        shotTime = 0.2f;

        //  �������Z�b�g
        nCoins = 0;

        //  BGM
        asBGM.Play();
    }
    
    // Update is called once per frame
    void Update()
    {
        
        //  ���Ԃ����Z
        WorldTime += Time.deltaTime;
    }
    public void SubPlayerHP(int damage)
    {
        //  �_���[�W���󂯂�
        playerHP -= (damage - playerDef);

        if(playerHP > playerMAXHP)
        {
            playerHP = playerMAXHP;
        }

        //  HP�o�[�����炷
        HPbar.GetComponent<Image>().fillAmount = playerHP / playerMAXHP;

        if (playerHP <= 0)
        {
            //  �����A�j���p�Q�[���I�u�W�F�N�g����
            GameObject explo = Instantiate(MyExplosionPrefab);
            //  �����̈ʒu��G�ɍ��킹��
            explo.transform.position = transform.position;

            //  �}�l�[�W���[�����t���O��ON�ɂ���
            MyShipManager.MyShipMissFlg = true;

            //  �v���C���[������
            Destroy(this.gameObject);
        }
    }
    private void FixedUpdate()
    {
        // �ϐ�����
        // �����ړ��ʂ��擾
        float inputX;
        // �����ړ��ʂ��擾
        float inputY;

        Vector2 direction;
        //  �ړ�����
        if (joystick)
        {
            inputX = joystick.Horizontal;
            inputY = joystick.Vertical;
            direction = joystick.Direction;
            Debug.Log("joyOn");


            // �ړ�����
            // �w������Ɉړ�
            Vector3 pos = transform.position;
            pos += transform.forward * inputY * (inputY > 0 ? SpeedFront : SpeedFront / 4.0f) * Time.deltaTime;
            pos += transform.right * inputX * SpeedSide * Time.deltaTime;

            transform.position = pos;

            transform.Translate(joystick.Direction * PlayerSpeed);

            // transform�̓Q�[���I�u�W�F�N�g�̊�{�I�ȏ��B
            // �����o�ł���Translate�̓I�u�W�F�N�g�ɗ^������ړ��ʁB
            // �R���g���[�����Ȃǂ����̂܂ܗ^����Ƒ�������̂ŁA
            // �W������Z���ēK���Ȓl�ɗ}������K�v������B
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

        // �e�̔���
        // �v���n�u�ݒ肪�����
        if (ShotPrefab != null)
        {
            if (shotTime < 0.0f)
            {
                // �V���ɒe�̃Q�[���I�u�W�F�N�g�𐶐�������
                GameObject shot = Instantiate(ShotPrefab);

                //  SE�Đ�
                asSE.clip = acShot;
                asSE.volume = 0.2f;
                asSE.Play();
                
                // �e�̏������W�����@�Ɠ����ɂ���
                shot.transform.position = transform.position + new Vector3(0.0f, 0.8f, 0.0f);

                //  shottime������
                shotTime = 0.2f;
            }
            else
            {
                shotTime -= Time.deltaTime;
            }
        }

    }
    // �G�Ƃ̓����蔻��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ������������̃^�O�����ēG��������
        if (collision.gameObject.tag == "Enemy")
        {
            //  HP����
            SubPlayerHP(50);

            // �Q�[���I�[�o�[�V�[����ǂݍ���ŃV�[���ύX
            //SceneManager.LoadScene("GameOver");

            asSE.clip = acExplosoion;
            asSE.Play();

            //  �G��j��
            Destroy(collision.gameObject);
        }
        //  ������������̃^�O�����ēG�̒e��������
        if (collision.gameObject.tag == "EnemyShot")
        {
            //  HP����
            //  ���Ԍo�߂Ń_���[�W��������
            SubPlayerHP(30 + (int)(WorldTime/5));

            // �Q�[���I�[�o�[�V�[����ǂݍ���ŃV�[���ύX
            //SceneManager.LoadScene("GameOver");

            //  ���N���X������public�ȕϐ��ւ̃A�N�Z�X�́A
            //  �N���X��.�ϐ����ŉ\�ɂȂ�

            asSE.clip = acExplosoion;
            asSE.Play();

            //  �e����
            Destroy(collision.gameObject);
        }
        //  ������������̃^�O�����ăR�C����������
        if (collision.gameObject.tag == "Coin")
        {
            nCoins += 100;
            player_State.player_Coins += 100;

            coin_text.GetComponent<Text>().text = "Coins�F$" + string.Format("{0}", nCoins);

            asSE.clip = acCoin;
            asSE.Play();

            Destroy(collision.gameObject);
        }
    }

    //  �U���͂�Ԃ�
    public int GetPlayerATK()
    {
        return playerAtk;
    }
    //  �U���͑���
    public void AddPlayerATK(int num)
    {
        playerAtk += num;
    }
    //  �h��͂�Ԃ�
    public int GetPlayerDEF()
    {
        return playerDef;
    }
    //  �h��͑���
    public void AddPlayerDEF(int num)
    {
        playerDef += num;
    }
    //  �̗͂�Ԃ�
    public float GetPlayerHP()
    {
        return playerHP;
    }
    //  �ő�̗͂�Ԃ�
    public float GetPlayerMAXHP()
    {
        return playerMAXHP;
    }
}
