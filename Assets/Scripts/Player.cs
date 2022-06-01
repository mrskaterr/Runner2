using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.UI; 
using TMPro; 
using UnityEngine.SceneManagement; 
 
public class Player : MonoBehaviour 
{ 
    float cameraPos=0; 
    float ParticlePos=0;
    int life=2; 
    public bool isPlayingAnimation=false; 
    bool isDied=false; 
    bool isGrounded=true; 
    bool isWallRunning=false; 
    bool isMonkeyJumping=false; 
    public bool isMonkeyJumping2=false; 
    bool isWallClimb=false;

    [SerializeField] Component AudioSource;
    private Component allAudio;
    [SerializeField] ParticleSystem JumpParticle; 
    [SerializeField] ParticleSystem SlideParticle; 
    [SerializeField] TextMeshProUGUI Score; 
    [SerializeField] TextMeshProUGUI Record; 
    [SerializeField] GameObject DeadScreen; 
    [SerializeField] GameObject PauseButton; 
    int intScore; 
    [SerializeField] Camera MainCamera; 
    [Space] 
    [SerializeField] AudioSource JumpAudio;
    [SerializeField] AudioSource SlideAudio;
    [SerializeField] AudioSource WallClimbAudio;
    [SerializeField] AudioSource JoggingStumbleAudio;
    [SerializeField] AudioSource yhhhAudio;
    [Space]
    [SerializeField] Animator animator; 
    [SerializeField] Transform person; 
    [Space] 
    [SerializeField] List<Rigidbody> Ragdoll; 
    [Space] 
    [SerializeField] float speed; 
    [SerializeField] float jumpSpeed; 
    [SerializeField] float gravity; 
    public AudioSource audiooo;
 
    float gameSpeed=1f; 
    bool isJumpSwipe=false; 
    bool isJumpOverSwipe=false; 
    bool isSlideSwipe=false; 
    bool grav; 
 
    private Vector3 moveDirection = Vector3.zero; 
    void Start() 
    { 
        
        Record.text=PlayerPrefs.GetInt("Record").ToString(); 
        for(int i =0 ;i<Ragdoll.Count;i++) 
        { 
            Ragdoll[i].isKinematic = true; 
            Ragdoll[i].detectCollisions = false; 
        } 
    } 
    void FixedUpdate() 
    { 
        if(!isDied && life>=0) 
        { 
            intScore=((int)transform.position.x/10); 
            Score.text=intScore.ToString(); 
            if (isGrounded) 
            { 
                animator.speed=gameSpeed+0.001f*transform.position.x; 
                moveDirection = new Vector3(gameSpeed+0.001f*transform.position.x, 0f, 0f); 
                 
                moveDirection *= speed; 
 
 
                if ((Input.GetKey(KeyCode.W) || isJumpSwipe ) && !isMonkeyJumping && !isPlayingAnimation && !isWallRunning) 
                { 
                    moveDirection.y = jumpSpeed; 
                    animator.SetTrigger("maly skok");
                    JumpAudio.Play();
                    JumpParticle.Play(); 
                    isJumpSwipe=false; 
 
 
                } 
                else if(isWallClimb && isJumpSwipe) 
                { 
                    animator.SetTrigger("wspiecie sie"); 
                    moveDirection.y = jumpSpeed; 
                    WallClimbAudio.Play();
                    isWallClimb=false; 
                    isJumpSwipe=false; 
                } 
                else if ((Input.GetKey(KeyCode.W) || isJumpSwipe ) && isMonkeyJumping && !isPlayingAnimation && !isWallRunning) 
                { 
                    isMonkeyJumping2=true; 
                    isJumpSwipe=false; 
                } 
                else if ((Input.GetKey(KeyCode.S) || isSlideSwipe) && !isPlayingAnimation) 
                { 
                    transform.GetComponent<CapsuleCollider>().height=0.5f; 
                    transform.GetComponent<CapsuleCollider>().center=new Vector3(0f,-1f,0f); 
                    animator.SetTrigger("slide"); 
                    SlideAudio.Play();
                    SlideParticle.Play(); 
                    StartCoroutine(Wait(1f)); 
                    isSlideSwipe=false; 
                } 
            } 
            else if(isWallRunning) 
            { 
                 
                if(grav)gameObject.GetComponent<Rigidbody>().velocity=new Vector3(0,0,0); 
                 
                transform.rotation=Quaternion.Euler(new Vector3(-30, 0, 0)); 
                if (Input.GetKey(KeyCode.Space) || isJumpOverSwipe) 
                { 
                    animator.SetTrigger("jump over"); 

                    transform.GetComponent<Rigidbody>().velocity=new Vector3(2f,0f,0f); 
                    isWallRunning=false; 
                    moveDirection.y = jumpSpeed; 
                    isJumpOverSwipe=false; 
                } 
            } 
            else 
            { 
                moveDirection.y -= gravity * Time.deltaTime; 
            } 
            transform.position += moveDirection * Time.deltaTime; 
            person.position=new Vector3(    transform.position.x, 
                                            person.position.y, 
                                            transform.position.z); 
            MainCamera.transform.position=new Vector3(  transform.position.x + cameraPos, 
                                                        MainCamera.transform.position.y, 
                                                        MainCamera.transform.position.z 
                                                        ); 
        } 
        else 
        { 
            Dead(); 
        } 
 
    } 
    void Dead() 
    { 
        if(!yhhhAudio.gameObject.active)yhhhAudio.gameObject.SetActive(true);
        if(PlayerPrefs.GetInt("Record")<intScore)PlayerPrefs.SetInt("Record",intScore); 
        for(int i =0 ;i<Ragdoll.Count;i++) 
        { 
            animator.enabled=false; 
            Ragdoll[i].isKinematic = false; 
            Ragdoll[i].detectCollisions = true; 
        } 
        DeadScreen.SetActive(true); 
    } 
    public void JumpOverSwipe() 
    { 
        isJumpOverSwipe=true; 
    } 
    public void JumpSwipe() 
    { 
        isJumpSwipe=true; 
    } 
    public void SlideSwipe() 
    { 
        isSlideSwipe=true; 
    } 
    IEnumerator WallGravity(float waitTime) 
    { 
        grav=true; 
        yield return new WaitForSeconds(waitTime); 
        grav=false; 
    } 
    IEnumerator Wait(float waitTime) 
    { 
        yield return new WaitForSeconds(waitTime); 
        transform.GetComponent<CapsuleCollider>().height=1.8f; 
        transform.GetComponent<CapsuleCollider>().center=new Vector3(0f,-0.3f,0f); 
    } 
    void OnCollisionEnter(Collision collision) 
    { 
         
        if(collision.gameObject.GetComponent<Cube>()) 
        { 
            isDied=true; 
        } 
         
        else if(collision.gameObject.GetComponentInChildren<Ground>()) 
        { 
            isGrounded=true; 
        } 
 
 
    } 
    void OnCollisionExit(Collision collision) 
    { 
        if(collision.gameObject.GetComponentInChildren<Ground>()) 
        { 
            isGrounded=false; 
        } 
    } 
    void OnTriggerEnter(Collider collision) 
    { 
 
 
        if(collision.gameObject.GetComponent<Slowling>()) 
        { 
            collision.gameObject.GetComponentInChildren<Rigidbody>().velocity+=new Vector3(0,2f,0);
            isJumpSwipe=false; 
            life--; 
            animator.SetTrigger("potkniecie"); 
            JoggingStumbleAudio.Play();
            ParticlePos=0;
        } 
        if(collision.gameObject.GetComponent<Wall>()) 
        { 
 
            StartCoroutine(WallGravity(0.7f)); 
            isWallRunning=true; 
        } 
        if(collision.gameObject.GetComponent<Rail>() && !isPlayingAnimation ) 
        { 
            animator.SetTrigger("monkey jump");
            JumpAudio.Play(); 
            collision.gameObject.GetComponent<Rail>().DisableCollider(); 
        } 
 
 
    } 
    void OnTriggerStay(Collider collision) 
    { 
        if(collision.gameObject.GetComponent<Slowling>()) 
        { 
            
            cameraPos+=0.5f;
            JumpParticle.transform.position=new Vector3(transform.position.x,JumpParticle.transform.position.y,JumpParticle.transform.position.z);
        } 
 
        if(collision.gameObject.GetComponentInChildren<BigCube>()) 
        { 
 
            GetComponent<Rigidbody>().velocity=new Vector3(0f,2f,0f); 
            isWallClimb=true; 
        } 
        if(collision.gameObject.GetComponent<MonkeyJumpDetect>()) 
        { 
            isMonkeyJumping=true; 
        } 
 
    } 
    void OnTriggerExit(Collider collision) 
    { 
 
        if(collision.gameObject.GetComponent<Slowling>()) 
        { 
            isJumpSwipe=false;
            //JumpParticle.transform.position=new Vector3(transform.position.x,JumpParticle.transform.position.y,JumpParticle.transform.position.z); 
            //SlideParticle.transform.position+=new Vector3(ParticlePos,0,0); 
        } 
        if(collision.gameObject.GetComponent<Wall>()) 
        { 
            transform.rotation=Quaternion.Euler(new Vector3(0, 0, 0)); 
            isWallRunning=false; 
        } 
        if(collision.gameObject.GetComponent<MonkeyJumpDetect>()) 
        { 
            isMonkeyJumping=false; 
        } 
    } 
 
}