using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickControllers : MonoBehaviour
{
    //global
    public float kecepatan;
    public string axis;
    //atur batas gerak
    public float batasAtas;
    public float batasBawah;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float gerak = Input.GetAxis(axis)*kecepatan*Time.deltaTime;
        //logikanya
        float posisi = transform.position.y + gerak;
        if (posisi > batasAtas)
        {
            gerak = 0;
        }
        if (posisi < batasBawah)
        {
            gerak = 0;
        }
        transform.Translate(0, gerak, 0);
        
    }
}
