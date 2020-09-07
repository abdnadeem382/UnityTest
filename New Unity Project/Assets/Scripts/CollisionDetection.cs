using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private LevelManager lm;
    public int CoinValue;

    // Start is called before the first frame update
    void Start()
    {
        lm = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col) {
        Debug.Log(col.gameObject.name + " Collided with " + gameObject.name);
        if (col.CompareTag("Player")) { 
        lm.AddCoins(CoinValue);
        Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        Debug.Log(gameObject.name + " destroyed");
    }
}
