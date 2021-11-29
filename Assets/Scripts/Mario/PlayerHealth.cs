using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int _hp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_hp <= 0)
        {
            Debug.Log("Mario has Died");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Enemy")
        {
            _hp--;
            Debug.Log(_hp);
        }

        if(collision.collider.gameObject.tag == "DeathFloor")
        {
            _hp = 0;
        }
    }

    public int GetHp()
    {
        return _hp;
    }
}
