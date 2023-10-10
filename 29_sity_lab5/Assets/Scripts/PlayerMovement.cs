using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody PlayerRigidbody;

    public float score;
    public Text ScoreText;


    // Start is called before the first frame update
    void Start()
    {
        if(score == 4)
        {
            SceneManager.LoadScene("GameWinScene");
        }
    }

    // Update is called once per frame
    void Update()
    {
 
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        PlayerRigidbody.AddForce(movement * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Hazard")
        {
            SceneManager.LoadScene("GameLoseScene");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);

            score++;
            ScoreText.text = "Score: " + score;
        }

    }
}
