using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject DeathEffect;
    [SerializeField] private GameObject scorePopUp;
    // Start is called before the first frame update

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.currentGamestatus != GameManager.gameStates.playing)
        {
            StartCoroutine(DestroyEnemy());
        }
    }

    public void death()
    {

        if(GameManager.currentGamestatus == GameManager.gameStates.playing)
        {
            float distanceFromPlayer = Vector3.Distance(transform.position, CharacterPos.instance.characterPos.position);
            int bonusPoints = (int)(distanceFromPlayer);
            int gameScore = 10 * bonusPoints;

            //pass the score to the game manager
            gameManager.UpdatePlayerScore(gameScore);

            anim.SetBool("Died", true);

            //instantiate score pop up
            scorePopUp.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = gameScore.ToString();
            Instantiate(scorePopUp, transform.position, Quaternion.identity);

            //adjust the scale of the score pop up
            scorePopUp.transform.localScale = new Vector3(transform.localScale.x * (distanceFromPlayer / 10),
                                                          transform.localScale.y * (distanceFromPlayer / 10),
                                                          transform.localScale.z * (distanceFromPlayer / 10));
        }


        StartCoroutine(DestroyEnemy());

    }

    IEnumerator DestroyEnemy()
    {
        //EnemyMovement.instance.isMoving = false;
        yield return new WaitForSeconds(0.5f);
        Instantiate(DeathEffect, transform.position += new Vector3 (0, 1, 0), transform.rotation);
        Destroy(gameObject);
    }

    
}
