using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public  class WordPool : MonoBehaviour
{
   

    private TextAsset[] txt;
    //public string[] dict;
    private int n;
    private string[] threeLetters;
    private string[] fourLetters;
    private string[] fiveLetters;
    private string[] sixLetters;
    private string[] sevenLetters;
    private string[] eightLetters;
    private string[] nineLetters;
    private string[] tenLetters;
    
    // Start is called before the first frame update
    void Start()
    {
        txt = new TextAsset[8] {null,null,null,null, null, null, null, null};
      
        LoadResources();
        n = Random.Range(0, 215);
       
        //dict = new string[216];
    }

    // Update is called once per frame
    void Update()
    {
        //CheckInput();
        /*if (Input.GetKeyDown(KeyCode.Space))
            n = Random.Range(0, 215);*/
    }

   public  string CheckInput(int size)
    {
        n = Random.Range(0, 215);
        switch (size)
        {

            case 3:                
                return threeLetters[n];
                
            case 4:
                return fourLetters[n];
              
            case 5:
                return fiveLetters[n];
                
            case 6:
                return sixLetters[n];
            case 7:
                return sevenLetters[n];
                
            case 8:
                return eightLetters[n];
                
            case 9:
                return nineLetters[n];
                
            case 10:
                return tenLetters[n];
                
            default:
                return null;
        }
    }

    void LoadResources()
    {
       
        txt[0] = (TextAsset)Resources.Load("3LetterWords");
        threeLetters = txt[0].text.Split("\n"[0]);
       
        txt[1] = (TextAsset)Resources.Load("4LetterWords");
        fourLetters = txt[1].text.Split("\n"[0]);

        txt[2] = (TextAsset)Resources.Load("5LetterWords");
        fiveLetters = txt[2].text.Split("\n"[0]);

        txt[3] = (TextAsset)Resources.Load("6LetterWords");
        sixLetters = txt[3].text.Split("\n"[0]);

        txt[4] = (TextAsset)Resources.Load("7LetterWords");
        sevenLetters = txt[4].text.Split("\n"[0]);

        txt[5] = (TextAsset)Resources.Load("8LetterWords");
        eightLetters = txt[5].text.Split("\n"[0]);

        txt[6] = (TextAsset)Resources.Load("9LetterWords");
        nineLetters = txt[6].text.Split("\n"[0]);

        txt[7] = (TextAsset)Resources.Load("10LetterWords");
        tenLetters = txt[7].text.Split("\n"[0]);
    }
}
