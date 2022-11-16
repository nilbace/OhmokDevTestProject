using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class baduk : MonoBehaviour
{
    public ParticleSystem part;

    void OnMouseDown() {
        StartCoroutine(destroybaduk());
    }

    IEnumerator destroybaduk() {
        var partsys = Instantiate(part,transform.position,part.transform.rotation);
        yield return null;
        Destroy(gameObject);
    }
}
