using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Xml.Schema;

public class GameController : MonoBehaviour
{
    public Text CrystalCounterText;
    public Text CountDownText;
    public Text EndOfGameText;

    public AudioClip winAudio;
    public AudioClip loseAudio;


    void Start()
    {
        UpdateCrystalCounterText();
        EndOfGameText.enabled = false;
        StartCoroutine(CountDownCoroutine());
    }

    void Update()
    {
        
    }

    IEnumerator CountDownCoroutine()
    {
        setIfSphereCanMove(false);
        CountDownText.enabled = true;

        for(int i = 5; i > 0; i--)
        {
            CountDownText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        FindObjectOfType<Sphere>().canMove = true;

        CountDownText.text = "START";
        yield return new WaitForSeconds(1f);

        CountDownText.enabled = false;       

    }

    void setIfSphereCanMove(bool canMove)
    {
        var sphere = FindObjectOfType<Sphere>();
            sphere.canMove = canMove;

        sphere.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
         

    public void UpdateCrystalCounterText()
    {
        var crystals = FindObjectsOfType<Crystal>();

        var crystalCount = crystals.Length;
        var crystalInactive = crystals.Count(crystal => !crystal.active);

        var text = crystalInactive + " / " + crystalCount;
        CrystalCounterText.text = text;
    }


    public void CheckIfEndOfGame()
    {
       
        var endOfGame = FindObjectsOfType<Crystal>().All(crystal => !crystal.active);

        if (!endOfGame) return;

        EndOfGame(true);
    }

    public void EndOfGame(bool win)
    {
        StartCoroutine(EndOfGameCoroutine(win));
    }


    IEnumerator EndOfGameCoroutine(bool win)
    {
        setIfSphereCanMove(false);

        EndOfGameText.enabled = true;
        EndOfGameText.text = win ? "WIN" : "LOSE";

        var audioSource = GetComponent<AudioSource>();
        audioSource.clip = win ? winAudio : loseAudio;

        audioSource.Play();
        yield return new WaitForSeconds(3f);

        Debug.Log("Koniec GRY XD");
        Application.Quit();
    }
}
