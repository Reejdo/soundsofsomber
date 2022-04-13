using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    public Animator camAnim;
    public GameObject flash;

    public void Shake(){
    	camAnim.SetTrigger("shake");
    	StartCoroutine(screenFlash());
    }

    public IEnumerator screenFlash(){
        flash.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        flash.SetActive(false);
    }
}
