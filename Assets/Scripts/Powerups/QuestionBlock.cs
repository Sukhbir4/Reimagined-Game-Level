using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlock : MonoBehaviour
{
    [SerializeField] float bounceHeight = 0.5f;
    [SerializeField] float bounceSpeed = 4f;

    [SerializeField] Sprite emptyBlockSprite;
    [SerializeField] GameObject mushroomPrefab;
    [SerializeField] GameObject mafiaPrefab;
    [SerializeField] Transform powerupSpawn;

    SpriteRenderer spriteRenderer;

    private Vector2 originalPos;

    private bool canBounce = true;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void QuestionBlockBounce()
    {
        if (canBounce)
        {
            canBounce = false;

            StartCoroutine(Bounce());
        }
    }

    IEnumerator Bounce()
    {
        while (true)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + bounceSpeed * Time.deltaTime);

            if (transform.position.y >= originalPos.y + bounceHeight)
            {
                break;
            }

            yield return null;
        }

        while (true)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - bounceSpeed * Time.deltaTime);

            if (transform.position.y <= originalPos.y)
            {
                transform.position = originalPos;

                //Change Sprite
                spriteRenderer.sprite = emptyBlockSprite;

                //Spawn Powerups
                if (gameObject.tag == "MushroomBlock")
                {
                    var mushroom = Instantiate(mushroomPrefab, powerupSpawn.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                }

                if (gameObject.tag == "MafiaBlock")
                {
                    var mafia = Instantiate(mafiaPrefab, powerupSpawn.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                }

                break;
            }

            yield return null;
        }
    }
}
