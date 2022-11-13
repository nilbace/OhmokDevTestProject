using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class baduk : MonoBehaviour
{
    public ParticleSystem part;
    

    void OnMouseDown() {
        StartCoroutine(destroyBadukDole());
    }

    

    IEnumerator destroyBadukDole()
    {
        var particleObject = Instantiate(part);
        Color spritecolor = gameObject.GetComponent<SpriteRenderer>().color;
        spritecolor.a = 0f;
        gameObject.GetComponent<SpriteRenderer>().color = spritecolor;

        yield return new WaitForSeconds(2f);
        
        Destroy(particleObject);
        Destroy(gameObject);
        
    }

    
}
