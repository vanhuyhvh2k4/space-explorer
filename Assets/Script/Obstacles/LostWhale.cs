using UnityEngine;
using UnityEngine.SceneManagement;

public class LostWhale : MonoBehaviour
{
    void Update()
    {
        float moveX = (GameManager.Instance.wordSpeed * PlayerController.Instance.boost) * Time.deltaTime;
        transform.position += new Vector3(-moveX, 0f, 0f);
        if (transform.position.x < -11f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Level 1 Complete");
        }
    }
}
