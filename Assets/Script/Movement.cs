using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float speed = 150f;
    public Rigidbody rb;
    public float jump1 = 6, jump2 = 4;
    public bool doubleJump = false, grounded = false, tapped = false, stop = false, jumping = false, gameOver = false, finish = false, wait = true, start = false, tutor = false, done = false, sliding = false;
    public Button jump, slide, pause;
    public Image jumps, slides;
    public AudioClip up, doubleUp, down, plus, minus, clear, dead, click; 
    public Animator animator;
    public CapsuleCollider colChar;
    public GameManager manager;
    public CameraMovement kamera;
    public Menu menu;

    private void Awake()
    {
        kamera.stop = true;
        jump.gameObject.SetActive(false);
        slide.gameObject.SetActive(false);
        jumps.gameObject.SetActive(false);
        slides.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!start)
        {
            if (!done)
            {
                StartCoroutine(idle());
            }
            if (wait && done)
            {
                animator.SetInteger("Animation", 1);
                StartCoroutine(delay());
                if (!menu.pause)
                {
                    jump.gameObject.SetActive(true);
                    slide.gameObject.SetActive(true);
                }
                else if (menu.pause)
                {
                    jump.gameObject.SetActive(false);
                    slide.gameObject.SetActive(false);
                }
                if (tutor)
                {
                    manager.gray.gameObject.SetActive(true);
                    manager.tutorial.gameObject.SetActive(true);
                    manager.tutorial.text = "Sentuh disini untuk memulai Permainan!";
                    jumps.gameObject.SetActive(true);
                    slides.gameObject.SetActive(true);
                }
            }
            else if (!wait)
            {
                animator.SetInteger("Animation", 2);
                kamera.stop = false;
                if (tutor)
                {
                    manager.gray.gameObject.SetActive(false);
                    manager.tutorial.gameObject.SetActive(false);
                    jumps.gameObject.SetActive(false);
                    slides.gameObject.SetActive(false);
                    jump.gameObject.SetActive(false);
                    slide.gameObject.SetActive(false);
                    tapped = false;
                }
                start = true;
            }
        }

        if (start)
        {
            RaycastHit hit;
            Vector3 physicCenter = this.transform.position + colChar.center;

            if (menu.pause)
            {
                jump.gameObject.SetActive(false);
                slide.gameObject.SetActive(false);
            }
            else if (!menu.pause)
            {
                if (Physics.Raycast(physicCenter, Vector3.down, out hit, 0.5f))
                {
                    if (hit.transform.gameObject.tag == "ground")
                    {
                        if (grounded && !jumping && !gameOver)
                        {
                            if (animator.GetInteger("Animation") == 3)
                            {
                                animator.SetInteger("Animation", 4);
                            }
                            else if (animator.GetInteger("Animation") == 5 || animator.GetInteger("Animation") == 7)
                            {
                                animator.SetInteger("Animation", 6);
                            }
                        }
                        grounded = true;
                        doubleJump = true;
                        jumping = false;
                        if (tutor && done)
                        {
                            if (manager.tutor6 && !finish && !gameOver && !sliding)
                            {
                                jump.gameObject.SetActive(true);
                                slide.gameObject.SetActive(true);
                            }
                        }
                        else if (!finish && !gameOver && done && !sliding)
                        {
                            jump.gameObject.SetActive(true);
                            slide.gameObject.SetActive(true);
                        }
                    }
                }
                else
                {
                    jumping = true;
                    grounded = false;
                    slide.gameObject.SetActive(false);
                }
            }

            if (!stop && !wait)
            {
                if (!gameOver)
                {
                    rb.velocity = new Vector3(speed * Time.fixedDeltaTime, rb.velocity.y, rb.velocity.z);
                    rb.constraints = RigidbodyConstraints.None;
                    rb.constraints = RigidbodyConstraints.FreezeRotation;
                    animator.speed = 1;
                }
            }
            else if (!stop && wait)
            {
                rb.velocity = new Vector3(0, 0, 0);
            }
            else if (stop && !wait)
            {
                animator.speed = 0;
                rb.velocity = new Vector3(0, 0, 0);
                rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
            }

            if ((this.transform.position.x + 2f) < kamera.transform.position.x)
            {
                speed = 200f;
            }
            if ((this.transform.position.x + 2f) >= kamera.transform.position.x)
            {
                speed = 150f;
            }

            if (tutor)
            {
                if (transform.position.x >= 12.3f && manager.tutor1 == false)
                {
                    if (!tapped)
                    {
                        stop = true;
                        kamera.stop = true;
                        manager.tutorial.text = "Sentuh disini untuk lompat!";
                        manager.gray.gameObject.SetActive(true);
                        manager.tutorial.gameObject.SetActive(true);
                        jumps.gameObject.SetActive(true);
                        jump.gameObject.SetActive(true);
                    }
                    else if (tapped)
                    {
                        stop = false;
                        kamera.stop = false;
                        manager.gray.gameObject.SetActive(false);
                        manager.tutorial.gameObject.SetActive(false);
                        jumps.gameObject.SetActive(false);
                        tapped = false;
                        manager.tutor1 = true;
                        AudioSource audio = GetComponent<AudioSource>();
                        audio.PlayOneShot(up);
                        jumping = true;
                        animator.SetInteger("Animation", 3);
                        rb.velocity = new Vector3((speed - 3f) * Time.fixedDeltaTime, jump1, rb.velocity.z);
                        jump.gameObject.SetActive(false);
                    }
                }
                else if (transform.position.x >= 22f && manager.tutor2 == false)
                {
                    if (!tapped)
                    {
                        stop = true;
                        kamera.stop = true;
                        manager.tutorial.text = "Ambil buah sesuai dengan Karaktermu dan Lompatlah sekarang!";
                        manager.gray.gameObject.SetActive(true);
                        manager.tutorial.gameObject.SetActive(true);
                        jump.gameObject.SetActive(true);
                    }
                    else if (tapped)
                    {
                        stop = false;
                        kamera.stop = false;
                        manager.gray.gameObject.SetActive(false);
                        manager.tutorial.gameObject.SetActive(false);
                        tapped = false;
                        manager.tutor2 = true;
                        AudioSource audio = GetComponent<AudioSource>();
                        audio.PlayOneShot(up);
                        jumping = true;
                        animator.SetInteger("Animation", 3);
                        rb.velocity = new Vector3((speed - 3f) * Time.fixedDeltaTime, jump1, rb.velocity.z);
                        jump.gameObject.SetActive(false);
                    }
                }
                else if (transform.position.x >= 28f && manager.tutor3 == false)
                {
                    if (!tapped)
                    {
                        stop = true;
                        kamera.stop = true;
                        manager.tutorial.text = "Jangan sentuh Kaktus, Lompat sekarang!";
                        manager.gray.gameObject.SetActive(true);
                        manager.tutorial.gameObject.SetActive(true);
                        jump.gameObject.SetActive(true);
                    }
                    else if (tapped)
                    {
                        stop = false;
                        kamera.stop = false;
                        manager.gray.gameObject.SetActive(false);
                        manager.tutorial.gameObject.SetActive(false);
                        tapped = false;
                        manager.tutor3 = true;
                        AudioSource audio = GetComponent<AudioSource>();
                        audio.PlayOneShot(up);
                        jumping = true;
                        animator.SetInteger("Animation", 3);
                        rb.velocity = new Vector3((speed - 3f) * Time.fixedDeltaTime, jump1, rb.velocity.z);
                        jump.gameObject.SetActive(false);
                    }
                }
                else if (transform.position.x >= 31f && manager.tutor4 == false)
                {
                    if (!tapped)
                    {
                        stop = true;
                        kamera.stop = true;
                        manager.tutorial.text = "Lompat lagi untuk Lompatan yang kedua, cobalah!";
                        manager.gray.gameObject.SetActive(true);
                        manager.tutorial.gameObject.SetActive(true);
                        jump.gameObject.SetActive(true);
                    }
                    else if (tapped)
                    {
                        stop = false;
                        kamera.stop = false;
                        manager.gray.gameObject.SetActive(false);
                        manager.tutorial.gameObject.SetActive(false);
                        AudioSource audio = GetComponent<AudioSource>();
                        audio.PlayOneShot(doubleUp);
                        tapped = false;
                        manager.tutor4 = true;
                        StartCoroutine(doubleJumper());
                        jump.gameObject.SetActive(false);
                    }
                }
                else if (transform.position.x >= 39.5f && manager.tutor5 == false)
                {
                    if (!tapped)
                    {
                        stop = true;
                        kamera.stop = true;
                        manager.tutorial.text = "Sentuh layar ini untuk berseluncur, jangan menabrak tembok yang ada. Ingat! Ketika berseluncur kamu tidak bisa melompat!";
                        manager.gray.gameObject.SetActive(true);
                        manager.tutorial.gameObject.SetActive(true);
                        slides.gameObject.SetActive(true);
                        slide.gameObject.SetActive(true);
                    }
                    else if (tapped)
                    {
                        stop = false;
                        kamera.stop = false;
                        manager.gray.gameObject.SetActive(false);
                        manager.tutorial.gameObject.SetActive(false);
                        slides.gameObject.SetActive(false);
                        tapped = false;
                        manager.tutor5 = true;
                        AudioSource audio = GetComponent<AudioSource>();
                        audio.PlayOneShot(down);
                        StartCoroutine(slider());
                        slide.gameObject.SetActive(false);
                    }
                }
                else if (transform.position.x >= 44.5f && manager.tutor6 == false)
                {
                    if (!tapped)
                    {
                        stop = true;
                        kamera.stop = true;
                        manager.tutorial.text = "Jika mengambil buah yang berbeda dengan jenis karaktermu, maka poinmu akan berkurang." +
                            "Sekarang mainkanlah sendiri!";
                        manager.gray.gameObject.SetActive(true);
                        manager.tutorial.gameObject.SetActive(true);
                        jump.gameObject.SetActive(true);
                        slide.gameObject.SetActive(true);
                    }
                    else if (tapped)
                    {
                        stop = false;
                        kamera.stop = false;
                        manager.gray.gameObject.SetActive(false);
                        manager.tutorial.gameObject.SetActive(false);
                        tapped = false;
                        manager.tutor6 = true;
                    }
                }
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "destroy")
        {
            gameOver = true;
            animator.SetInteger("Animation", -1);
            jump.gameObject.SetActive(false);
            slide.gameObject.SetActive(false);
            kamera.stop = true;
            rb.velocity = new Vector3(0, 0, 0);
            pause.interactable = false;
            manager.gameOver.gameObject.SetActive(true);
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(dead);
        }

        if (col.gameObject.tag == "destroy2")
        {
            gameOver = true;
            animator.SetInteger("Animation", -2);
            jump.gameObject.SetActive(false);
            slide.gameObject.SetActive(false);
            kamera.stop = true;
            rb.velocity = new Vector3(0, 0, 0);
            pause.interactable = false;
            manager.gameOver.gameObject.SetActive(true);
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(dead);
        }

        if (col.gameObject.tag == "finish")
        {
            kamera.stop = true;
            rb.velocity = new Vector3(0, 0, 0);
            pause.interactable = false;
            manager.victory.gameObject.SetActive(true);
            jump.gameObject.SetActive(false);
            slide.gameObject.SetActive(false);
            finish = true;
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(clear);
        }

        if (col.gameObject.tag == "orange")
        {
            Destroy(col.gameObject);
            manager.scoreCount += 1;
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(plus);
        }

        if (col.gameObject.tag == "strawberry" || col.gameObject.tag == "pineapple")
        {
            Destroy(col.gameObject);
            manager.scoreCount -= 1;
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(minus);
        }
    }

    public void Jump()
    {
        if (wait && !start)
        {
            wait = false;
        }
        else if (manager.tutor1 == false && manager.gray.gameObject.activeInHierarchy == true)
        {
            tapped = true;
            stop = false;
            kamera.stop = false;
        }
        else if (manager.tutor2 == false && manager.gray.gameObject.activeInHierarchy == true)
        {
            tapped = true;
            stop = false;
            kamera.stop = false;
        }
        else if (manager.tutor3 == false && manager.gray.gameObject.activeInHierarchy == true)
        {
            tapped = true;
            stop = false;
            kamera.stop = false;
        }
        else if (manager.tutor4 == false && manager.gray.gameObject.activeInHierarchy == true)
        {
            tapped = true;
            stop = false;
            kamera.stop = false;
        }
        else if (manager.tutor6 == false && manager.gray.gameObject.activeInHierarchy == true)
        {
            tapped = true;
            stop = false;
            kamera.stop = false;
        }
        else if (start && !tapped)
        {
            if (grounded)
            {
                AudioSource audio = GetComponent<AudioSource>();
                audio.PlayOneShot(up);
                StartCoroutine(jumper());
            }
            else if (doubleJump)
            {
                AudioSource audio = GetComponent<AudioSource>();
                audio.PlayOneShot(doubleUp);
                StartCoroutine(doubleJumper());
            }
        }     
    }

    public void Slide()
    {
        if (wait && !start)
        {
            wait = false;
        }
        else if (manager.tutor5 == false && manager.gray.gameObject.activeInHierarchy == true)
        {
            tapped = true;
            stop = false;
            kamera.stop = false;
        }
        else if (manager.tutor6 == false && manager.gray.gameObject.activeInHierarchy == true)
        {
            tapped = true;
            stop = false;
            kamera.stop = false;
        }
        else
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(down);
            StartCoroutine(slider());
        }
    }

    public IEnumerator idle()
    {
        yield return new WaitForSeconds(2.2f);
        done = true;
    }

    public IEnumerator delay()
    {
        yield return new WaitForSeconds(0.2f);
    }

    public IEnumerator jumper()
    {
        jumping = true;
        animator.SetInteger("Animation", 3);
        rb.velocity = new Vector3((speed - 3f) * Time.fixedDeltaTime, jump1, rb.velocity.z);
        yield return new WaitForSeconds(0f);
    }

    public IEnumerator doubleJumper()
    {
        jump.gameObject.SetActive(false);
        doubleJump = false;
        if(animator.GetInteger("Animation") == 3)
        {
            animator.SetInteger("Animation", 5);
        }
        else
        {
            animator.SetInteger("Animation", 7);
        }
        rb.velocity = new Vector3((speed - 3f) * Time.fixedDeltaTime, 0, rb.velocity.z);
        rb.velocity = new Vector3((speed - 3f) * Time.fixedDeltaTime, jump2, rb.velocity.z);
        yield return new WaitForSeconds(0);
    }

    public IEnumerator slider()
    {
        sliding = true;
        animator.SetInteger("Animation", 8);
        slide.gameObject.SetActive(false);
        jump.gameObject.SetActive(false);
        colChar.height = 0;
        colChar.center = new Vector3(0, -0.3f, 0.08f);
        yield return new WaitForSeconds(1f);
        colChar.height = 0.7f;
        colChar.center = new Vector3(0, -0.1f, 0.08f);
        if (!gameOver)
        {
            sliding = false;
            animator.SetInteger("Animation", 9);
        }
    }
}