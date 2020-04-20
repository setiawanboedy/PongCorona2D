using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallControllers : MonoBehaviour
{
    //gerakan adalah force * arah
    public int force;
    Rigidbody2D rigid;
    int score1;
    int score2;
    Text scoreTxt1;
    Text scoreTxt2;
    GameObject panelSelesai;
    Text txtPemenang;
    AudioSource sound;
    public AudioClip hitSound;
    public StickControllers stick;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2 (2,0).normalized;
        rigid.AddForce (arah*force);
        score1 = 0;
        score2 = 0;
        scoreTxt1 = GameObject.Find("Score1").GetComponent<Text>();
        scoreTxt2 = GameObject.Find("Score2").GetComponent<Text>();
        panelSelesai = GameObject.Find("PanelSelesai");
        panelSelesai.SetActive(false);
        sound = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //kalu nyentuh batas kiri dan kana maka akan reset
    //fungsi
    private void OnCollisionEnter2D (Collision2D coll){
        sound.PlayOneShot(hitSound);
        if (coll.gameObject.name == "BatasKanan")
        {
            score1 += 1;
            TampilkanScore();
            NextLevel(score1,score2);
            if(score1 == 10)
            {
                panelSelesai.SetActive(true);
                txtPemenang = GameObject.Find("Pemenang").GetComponent<Text>();
                txtPemenang.text = "Player Biru Menang!";
                Destroy(gameObject);
                return;
            }

            ResetBall ();
            Vector2 arah = new Vector2 (2,0).normalized;
            rigid.AddForce(arah*force);
        }
        if(coll.gameObject.name == "BatasKiri")
        {
            score2 += 1;
            TampilkanScore();
            NextLevel(score1, score2);
            if(score2 == 10)
            {
                panelSelesai.SetActive(true);
                txtPemenang = GameObject.Find("Pemenang").GetComponent<Text>();
                txtPemenang.text = "Player Merah Menang!";
                Destroy(gameObject);
                return;
            }

            ResetBall();
            Vector2 arah = new Vector2(-2,0).normalized;
            rigid.AddForce(arah*force);
        }
        if(coll.gameObject.name == "Player1" || coll.gameObject.name == "Player2"){
            float sudut = (transform.position.y - coll.transform.position.y) * 5f;
            Vector2 arah = new Vector2(rigid.velocity.x, sudut).normalized;
            rigid.velocity = new Vector2(0,0);
            rigid.AddForce(arah*force*2);
        }
    }
    void ResetBall(){
        transform.localPosition = new Vector2(0,0);
        rigid.velocity = new Vector2(0,0);
    }
    void TampilkanScore(){
        Debug.Log("Score1: "+score1 + " Score2: "+score2);
        scoreTxt1.text = score1 + "";
        scoreTxt2.text = score2 + "";
    }
    void NextLevel(int score1, int score2)
    {
        if(score1 == 5 || score2 == 5)
        {
            force += 20;
            stick.kecepatan += 2;

        }
        if(score1 == 8 || score2 == 8)
        {
            force += 10;
            stick.kecepatan += 1;
        }
    }
}
