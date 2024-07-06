using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playercontroller : MonoBehaviour
{
    public float movespeed;
    float xInput;
    float yInput;

    Rigidbody rb;
    int coinsCollected;

    public GameObject winText;
    void Start()
    {
        rb= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput= Input.GetAxis("Horizontal");
        yInput= Input.GetAxis("Vertical");
        if(transform.position.y<=-5f)
        {
            SceneManager.LoadScene(0);
        }
        

    }
    private void FixedUpdate()
    {
        rb.AddForce(xInput * movespeed, 0, yInput * movespeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if ( other.tag == "coin" )
        {
            coinsCollected++;
            other.gameObject.SetActive(false);
        }
        if(coinsCollected >=7)
        {
            //Win
            winText.SetActive(true);
        }
    }

}
