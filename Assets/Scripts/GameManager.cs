using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text TimeField;
    public GameObject[] Hangman;
    public GameObject winText;
    public GameObject loseText;
    private float time;
    public Text WfindField;
    private string[] wlocal = { "BK", "SK", "Yasin", "Sreeraj", "Aromal", "Anupam", "Vinay" };
    private string cword;
    private string hword;
    private int fails;
    public GameObject ReplayButton;
    private bool GameEnd = false;


    // Start is called before the first frame update
    void Start()
    {
     

       cword = wlocal[Random.Range(0, wlocal.Length)];
       for(int i = 0; i < cword.Length; i++)
        {
            char letter = cword[i];
            if(char.IsWhiteSpace(letter))
            {
                hword = " ";
            }
            hword += "_ ";
        }
        WfindField.text = cword;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameEnd == false)
        {
            time += Time.deltaTime;
            TimeField.text = time.ToString();
        }
    }

    private void OnGUI()
    {
        Event e = Event.current;
        if(e.type == EventType.KeyDown && e.keyCode.ToString().Length == 1)
        {
            string pressedkey = e.keyCode.ToString();
            Debug.Log("Keydown event was triggered" + pressedkey);
            if(cword.Contains(pressedkey))
            {
                int i = cword.IndexOf(pressedkey);
                while(i!= -1)
                {
                    hword = hword.Substring(0, i)+pressedkey + hword.Substring(i+1);
                    Debug.Log(hword);


                    cword = cword.Substring(0,i) + "_" + cword.Substring(i+1);
                    Debug.Log(cword);

                    i = cword.IndexOf(pressedkey);
                }
                WfindField.text = hword;
             }
            else
            {
                Hangman[fails].SetActive(true);
                fails++;
            }
            if(fails == Hangman.Length)
            {
                loseText.SetActive(true);
                ReplayButton.SetActive(true);
                GameEnd = true;
            }
            if(!hword.Contains("_"))
            {
                winText.SetActive(true);
                ReplayButton.SetActive(true);
                GameEnd = true;
            }
        }
    }
}
