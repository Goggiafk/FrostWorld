using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotEnemy : MonoBehaviour
{
    public RectTransform healthBar;
    public GameObject player;
    public GameObject damage;
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
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 reserve;
        reserve = transform.localEulerAngles;
        
        Ray ray = new Ray(transform.position, (player.transform.position - transform.position));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.transform.tag == "Player")
            {
                transform.LookAt(player.transform.position);
                transform.localEulerAngles += new Vector3(0, 0, 0);
                transform.position += (transform.forward * 1) * Time.deltaTime;
            }
        }
        Ray pos = new Ray(transform.position, -transform.up);
        RaycastHit his;
        if (Physics.Raycast(pos, out his, 10))
        {
            if (his.transform.tag == "Ground")
            {
                transform.position = his.point + new Vector3(0, 2, 0);
            }
        }
        transform.localEulerAngles = new Vector3(reserve.x, transform.localEulerAngles.y, reserve.z);
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

