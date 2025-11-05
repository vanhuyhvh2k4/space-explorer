using System;
using UnityEngine;

public class MenuParallax : MonoBehaviour
{
   [SerializeField] private float moveSpeed;
    float backgroundWidth;
    void Start()
    {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        backgroundWidth = sprite.texture.width / sprite.pixelsPerUnit;
    }

    void Update()
    {
        float moveX = moveSpeed * Time.deltaTime;
        transform.position += new Vector3(moveX, 0);
        if (Math.Abs(transform.position.x) - backgroundWidth > 0)
        {
            transform.position = new Vector3(0f, transform.position.y);
        }
    } 
}
