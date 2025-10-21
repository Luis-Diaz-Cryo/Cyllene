using UnityEngine;

public class Shapeshift : MonoBehaviour
{

    [SerializeField] Sprite[] formSprites;
    private Sprite currentSprite;
    public int formNumber = 0;

    // Update is called once per frame
    void Update()
    {
        if (formNumber == 0 && Input.GetKeyDown(KeyCode.E))
        {
            float bottomBefore = GetBottomY();
            currentSprite = formSprites[1];
            gameObject.GetComponent<SpriteRenderer>().sprite = currentSprite;
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(2, 1, 1);
            }
            else if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(-2, 1, 1);
            }
            transform.position = new Vector2(transform.position.x, transform.position.y);
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2((float)1.626012, 1);
            formNumber = 1;
            float bottomAfter = GetBottomY();
            float diff = bottomBefore - bottomAfter;
            transform.position += new Vector3(0, diff, 0);
        }
        else if (formNumber == 1 && Input.GetKeyDown(KeyCode.E))
        {
            float bottomBefore = GetBottomY();
            currentSprite = formSprites[0];
            gameObject.GetComponent<SpriteRenderer>().sprite = currentSprite;
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(1, (float)1.7, 1);
            }
            else if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(-1, (float)1.7, 1);
            }
            transform.position = new Vector2(transform.position.x, transform.position.y);
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1, 1);
            formNumber = 0;
            float bottomAfter = GetBottomY();
            float diff = bottomBefore - bottomAfter;
            transform.position += new Vector3(0, diff, 0);
        }

    }
    
    private float GetBottomY()
    {
        
        Bounds bounds = GetComponent<BoxCollider2D>().bounds;
        return bounds.min.y;
    }
    

}
