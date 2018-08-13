using UnityEngine;
using System.Collections;

public class MoveBall : MonoBehaviour {
    public float speed = 30;
    public GameObject score;
    Vector3 orginalPosition;

    void Start() {
		orginalPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        score = GameObject.FindGameObjectWithTag("Score");
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }
    void Update (){
        speed += Time.deltaTime/4;
    }

	float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight) {
        return (ballPos.y - racketPos.y) / racketHeight;
    }

	 void OnCollisionEnter2D(Collision2D col) {

        if (col.gameObject.name == "p1") {
            float y = hitFactor(transform.position,col.transform.position,col.collider.bounds.size.y);

            Vector2 dir = new Vector2(1, y).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        if (col.gameObject.name == "p2") {
            float y = hitFactor(transform.position,col.transform.position,col.collider.bounds.size.y);

            Vector2 dir = new Vector2(-1, y).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        if (col.gameObject.name == "p2score"){
            score.GetComponent<KeepScore>().score1++;
            gameObject.transform.position = orginalPosition;
            StartCoroutine(wait());
        }
        if (col.gameObject.name == "p1score"){
            score.GetComponent<KeepScore>().score2++;
            gameObject.transform.position = orginalPosition;
            StartCoroutine(wait());
        }
    }
    IEnumerator wait()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * 0;
        yield return new WaitForSeconds(2);
        speed = 10;
        if (score.GetComponent<KeepScore>().score2 > score.GetComponent<KeepScore>().score2)
            GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
        else{
            GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        }
        
    }
    
}