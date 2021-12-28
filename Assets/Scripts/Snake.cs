using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    public float speed = 3f;
    public float rotationSpeed = 250f;
    public string inputAxis = "Horizontal";
    private float horizontal = 0f;

    void Update()
    {
        horizontal = Input.GetAxisRaw(inputAxis) * -1;
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed * Time.fixedDeltaTime, Space.Self);
        transform.Rotate(Vector3.forward, rotationSpeed * horizontal * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Trail")
        {
            //GetComponent<GameManager>().EndGame();
            speed = 0f;
            rotationSpeed = 0f;
            EndGame();
        }
    }

    public void EndGame()
    {
        StartCoroutine(PlayEndGameAnimation());
        StopCoroutine(PlayEndGameAnimation());
    }

    IEnumerator PlayEndGameAnimation()
    {
        yield return new WaitForSeconds(1f);        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
