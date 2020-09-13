using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadAnimate : MonoBehaviour
{

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("bgm");
    }

    // Update is called once per frame
    void Update()
    {
        Animate();
    }
    void Animate()
    {
        if(Input.GetAxisRaw("Vertical") > 0)
            animator.speed = 0.7f;
        else
            animator.speed = 0;
        // Hand off moveSpeed value to animator (for blend tree)

    }
}
