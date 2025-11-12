using UnityEngine;

public class Boom : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
    }

    void Update()
    {
        float moveX = (GameManager.Instance.wordSpeed * PlayerController.Instance.boost) * Time.deltaTime;
        transform.position += new Vector3(-moveX, 0f, 0f);
        if (transform.position.x < -11f)
        {
            Destroy(gameObject);
        }
    }
}
