using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfEnemy : MonoBehaviour
{
    public RectTransform healthBar;
    public GameObject player;
    public GameObject damage;
    Vector3 moving;
    bool movi;
    public Animation wolf;
    public AudioSource attack;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform == null)
            return;
        if (other.transform.tag == "Player")
        {
            Health.healthi -= 1;
            healthBar.sizeDelta = new Vector3(healthBar.parent.GetComponent<RectTransform>().sizeDelta.x * Health.healthi / 100, healthBar.sizeDelta.y, 0);
            StartCoroutine(Timer(0, () => { damage.SetActive(true); }));
            StartCoroutine(Timer(1, () => { damage.SetActive(false); }));
            if (!attack.isPlaying)
                attack.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 reserve;
        reserve = transform.localEulerAngles;
        moving = transform.position;
        Ray ray = new Ray(transform.position, (player.transform.position - transform.position));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 50))
        {
            if (hit.transform.tag == "Player")
            {
                transform.LookAt(player.transform.position);
                transform.localEulerAngles += new Vector3(90, 0, 0);
                transform.position += (transform.up * 10) * Time.deltaTime;
            }
        }
        Debug.DrawRay(ray.origin, ray.direction * 50, Color.red);
        Ray pos = new Ray(transform.position, transform.forward);
        RaycastHit his;
        if (Physics.Raycast(pos, out his, 10))
        {
            if (his.transform.tag == "Ground")
            {
                transform.position = his.point + new Vector3(0, 0, 0);
            }
        }
        transform.localEulerAngles = new Vector3(reserve.x, transform.localEulerAngles.y, transform.localEulerAngles.z);
        movi = moving != transform.position;

        if (movi)
        {
            if (!wolf.isPlaying)
                wolf.Play();
        }
        else
            wolf.Stop();
    }




    IEnumerator Timer(float time, System.Action action)
    {
        while (time > 0)
        {
            time -= Time.deltaTime;
            yield return null;
        }
        action();
    }
}


