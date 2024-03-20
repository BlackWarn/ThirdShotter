using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningCast : MonoBehaviour
{
    public float damage = 50f;
    public float Range = 100f;
    public float timeStart = 5f;
    public float timeFix = 5f;

    public Camera Mcamera;
    public GameObject LigtningVisible;
    [SerializeField] private SoundManagerPlayer soundManagerPlayer;
    [SerializeField] private Animator animator;

    private void Update()
    {
        Timer();
        LightningShoot();
        //Debug.Log(damage);
    }
    private void Casting()
    {
        RaycastHit hit;
        if(Physics.Raycast(Mcamera.transform.position, Mcamera.transform.forward, out hit, Range))
        {
            if (hit.collider.gameObject.GetComponent<EnemyHealth>())
            {
                hit.collider.gameObject.GetComponent<EnemyHealth>().playerDamage();
            }
        }
    }
    private void Timer()
    {
        if (timeStart >= 0)
        {
            timeStart -= Time.deltaTime;
        }
    }
    private void LightningShoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (timeStart <= 0)
            {
                animator.SetTrigger("Attack");
                Invoke("LigtningYesVisible", 1.5f);
                timeStart = timeFix;
            }
        }
    }
    private void LigtningYesVisible()
    {
        LigtningVisible.SetActive(true);
        Casting();
        soundManagerPlayer.LightningShot();
        Invoke("LigtningNotVisible", 1f);
    }
    private void LigtningNotVisible()
    {
        animator.ResetTrigger("Attack");
        LigtningVisible.SetActive(false);
    }
}
