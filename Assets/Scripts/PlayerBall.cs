using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBall : MonoBehaviour
{
    Rigidbody rigid;
    public float JumpPower = 10;
    bool isJump;
    public int itemCount = 0;
    AudioSource audio;
    public GameManagerLogic manager;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        isJump = false;
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            rigid.AddForce(new Vector3(0, JumpPower, 0), ForceMode.Impulse);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
            isJump = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            itemCount++;
            audio.Play();
            other.gameObject.SetActive(false); //없어진다. gameObject == 자기 자신
            manager.GetItem(itemCount); //UI에 표시하기 위해 넘김.
        }

        else if (other.tag == "Finish")
        {
            if (itemCount == manager.totalItemCount)
            {
                //game clear
                SceneManager.LoadScene(manager.stage + 1);
            }
            else
            {
                //restart
                SceneManager.LoadScene(manager.stage);
            }
        }
    }
}
