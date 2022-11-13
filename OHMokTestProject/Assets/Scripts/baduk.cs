using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class baduk : MonoBehaviour
{
    public ParticleSystem part;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown() {
        this.gameObject.SetActive(false);
        part.gameObject.SetActive(true);
    }
}
