using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public int _hp;
    [SerializeField] public GameObject deathScreen;

    Vector2 temp;
    bool isMafia;

    // Update is called once per frame
    void Update()
    {
        if (_hp >= 2)
        {
            _hp = 2;
        }

        if (_hp <= 0)
        {
            Debug.Log("Mario has Died");
            deathScreen.SetActive(true);
        }
        else
        {
            deathScreen.SetActive(false);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Enemy")
        {
            isMafia = GetComponent<Player_Controller>().GetMafia();

            Debug.Log(isMafia);
            if (_hp == 2 && !isMafia)
            {
                temp = transform.localScale;
                temp.x -= 0.2f;
                temp.y -= 0.75f;
                transform.localScale = temp;
            }
            else
            {
                isMafia = false;
            }
            _hp--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "DeathFloor")
        {
            _hp = 0;
        }
    }

    public int GetHp()
    {
        return _hp;
    }

    public void SetHp(int added)
    {
        Debug.Log("Health increase");
        _hp += added;
    }

    public bool GetIsMafia()
    {
        return isMafia;
    }
}
