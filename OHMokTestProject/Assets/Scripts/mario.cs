using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mario : MonoBehaviour
{
    float speed=50.0f;
    bool jump=false;
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        this.rigid=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow)) {
            this.transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if(Input.GetKey(KeyCode.LeftArrow)) {
            this.transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if(Input.GetKey(KeyCode.UpArrow)&&jump==false) {
            this.rigid.AddForce(Vector3.up * 50, ForceMode2D.Impulse);
            jump=true;
        }
}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            this.gameObject.GetComponent<AudioSource>().Play();
        }
        if (collision.gameObject.tag == "floor")
        {
            jump = false;
        }
    }
}
