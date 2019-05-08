using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI enterText;
    public Canvas dialogueCanvas;
    public Text dialogueText;
    public string[] sentences;
    public float typingSpeed = 1;
    public HeadChefLogic[] headChefLogics;
    //public AudioClip buttonSound;

    private int index;
    private bool sentenceHasFinished;
    private PlayerMovement playerMovement;
    private AnimationInput animationInput;
    private FoodSpawner foodSpawner;

    void Start()
    {        
        dialogueCanvas.gameObject.SetActive(true);
        dialogueText.text = "";
        StartCoroutine("Type");
        foodSpawner = GetComponent<FoodSpawner>();
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        animationInput = GameObject.Find("Player").GetComponent<AnimationInput>();
        ScriptsAffectedByDialogue(false);
    }

    void Update ()
    {
        enterText.gameObject.SetActive(sentenceHasFinished);
        if (sentenceHasFinished)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                NextSentence();
            }
        }
    }

    IEnumerator Type ()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed * Time.deltaTime);
        }
        sentenceHasFinished = true;
    }

    public void NextSentence ()
    {
        dialogueText.text = "";
        sentenceHasFinished = false;
        if (index < sentences.Length - 1)
        {
            index++;            
            StartCoroutine("Type");
        }
        else
        {
            index = 0;
            dialogueCanvas.gameObject.SetActive(false);
            ScriptsAffectedByDialogue(true);
        }        
    }

    void ScriptsAffectedByDialogue (bool answer)
    {
        foreach (var item in headChefLogics)
        {
            item.enabled = answer;
        }
        foodSpawner.enabled = answer;
        playerMovement.enabled = answer;
        animationInput.enabled = answer;
    }
}