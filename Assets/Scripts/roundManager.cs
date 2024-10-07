using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roundManager : MonoBehaviour
{

    private int _BomberNum = 5;

    public int BomberNum
    {
        get { return _BomberNum; }

        set { _BomberNum = value; }
    }

    private int _FighterNum = 5;

    public int FighterNum
    {
        get { return _FighterNum; }

        set { _FighterNum = value; }
    }

    public enum Rounds {One, Two, Three};

    public Rounds specificRound;

    GameObject Bombers;

    GameObject Fighters;
    void Awake()
    {
        specificRound = Rounds.One;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RoundFunction()
    {
        switch(specificRound)
        {
            case Rounds.One:
                {
                    BomberNum += 0;

                    FighterNum += 0;

                    //GM.Instance.RoundStart(BomberNum, FighterNum);
                    break;
                }
            case Rounds.Two:
                {
                    BomberNum += 5;

                    FighterNum += 5;

                    //GM.Instance.RoundStart(BomberNum, FighterNum);
                    break;
                }
                case Rounds.Three:
                {
                    BomberNum += 5;

                    FighterNum += 5;

                    //GM.Instance.RoundStart(BomberNum, FighterNum);
                    break;
                }
        }

        if (BomberNum == 0 && FighterNum == 0)
        {
            ChangeRound();
        }
    }

    public void ChangeRound()
    {
        
        //GM.instance.Changestage Function.


    }
}
