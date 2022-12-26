using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class baduk : MonoBehaviour
{
    public ParticleSystem part;
    public ParticleSystem part2;
    public ParticleSystem shooting;
    public GameObject dol1;
    public GameObject dol2;
    public GameObject dol4;
    public GameObject dol5;

    void OnMouseDown() {
        StartCoroutine(destroybaduk());
    }

    IEnumerator destroybaduk() {
        var partsys = Instantiate(part,transform.position,part.transform.rotation);
        var partsys1 = Instantiate(part2, dol1.transform.position, dol1.transform.rotation);
        var partsys2 = Instantiate(part2, dol2.transform.position, dol2.transform.rotation);
        var partsys4 = Instantiate(part2, dol4.transform.position, dol4.transform.rotation);
        var partsys5 = Instantiate(part2, dol5.transform.position, dol5.transform.rotation);
        yield return null;
        dolmove();
        Invoke("shoot", 1f);
        Invoke("kill", 10f);
    }

    void dolmove() {
        dol1.transform.DOMove(this.transform.position,0.75f);
        dol2.transform.DOMove(this.transform.position,0.75f);
        dol4.transform.DOMove(this.transform.position,0.75f);
        dol5.transform.DOMove(this.transform.position,0.75f);
        this.transform.DOScale(new Vector3(0,0,0),3f);
        dol1.transform.DOScale(new Vector3(0,0,0),3f);
        dol2.transform.DOScale(new Vector3(0,0,0),3f);
        dol4.transform.DOScale(new Vector3(0,0,0),3f);
        dol5.transform.DOScale(new Vector3(0,0,0),3f);
        this.transform.GetComponent<SpriteRenderer>().DOFade(0, 2f).SetEase(Ease.InQuad);
        dol1.transform.GetComponent<SpriteRenderer>().DOFade(0, 2f).SetEase(Ease.InQuad);
        dol2.transform.GetComponent<SpriteRenderer>().DOFade(0, 2f).SetEase(Ease.InQuad);
        dol4.transform.GetComponent<SpriteRenderer>().DOFade(0, 2f).SetEase(Ease.InQuad);
        dol5.transform.GetComponent<SpriteRenderer>().DOFade(0, 2f).SetEase(Ease.InQuad);
    }

    void shoot() {
        var partsys = Instantiate(shooting,transform.position,part.transform.rotation);
    }

    void kill() {
        Destroy(gameObject);
        Destroy(dol1);
        Destroy(dol2);
        Destroy(dol4);
        Destroy(dol5);
    }
}
