using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamageHandler : MonoBehaviour
{

    public float damageFlashTime;
    public float missileDamageAmt;
    Image fader;
    Image hfader;
    Color hColor;

    void Awake()
    {
        fader = GameObject.Find("Fader").GetComponent<Image>();
        hfader = GameObject.Find("hFader").GetComponent<Image>();
    }

    // Use this for initialization
    void Start()
    {
        hColor = hfader.color;
        hColor.a = 1;
        hfader.color = hColor;
        hfader.CrossFadeAlpha(0, 0, true);

        fader.CrossFadeAlpha(1, 1, true);
        fader.CrossFadeAlpha(0, 3, true);
        Color tmp = new Color(253.0f / 255.0f, 20.0f / 255.0f, 73.0f / 255.0f, 180.0f / 255.0f);
        fader.color = tmp;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GiraHand")
        {
            StartCoroutine(damageFlash());
            HealthBar.S.hp -= 10.0f;
        }

        if (other.tag == "missile")
        {
            StartCoroutine(damageFlash());
            HealthBar.S.hp -= missileDamageAmt;
        }

        if (other.tag == "faceBullet")
        {
            StartCoroutine(damageFlash());
            HealthBar.S.hp -= 5.0f;
        }

        if (other.tag == "healthPickUp")
        {
            Destroy(other.gameObject);
            StartCoroutine(healthFlash());
            HealthBar.S.hp += 5.0f;
        }
 
    }

    IEnumerator healthFlash()
    {
        hfader.CrossFadeAlpha(1, damageFlashTime, true);
        yield return new WaitForSeconds(damageFlashTime);
        hfader.CrossFadeAlpha(0, damageFlashTime, true);
    }

    IEnumerator damageFlash()
    {
        fader.CrossFadeAlpha(1, damageFlashTime, true);
        yield return new WaitForSeconds(damageFlashTime);
        fader.CrossFadeAlpha(0, damageFlashTime, true);
    }

}
