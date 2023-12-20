using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class char_skinBuy : MonoBehaviour
{
    private int price;
    private int totalGem;

    public GameObject ckilit1;
    public GameObject ckilit2;
    public GameObject ckilit3;
    public GameObject ckilit4;
    public GameObject ckilit5;
    public GameObject ckilit6;
    public GameObject ckilit7;
    public GameObject ckilit8;
    public GameObject ckilit9;
    public GameObject ckilit10;
    public GameObject ckilit11;
    public GameObject ckilit12;
    public GameObject ckilit13;
    public GameObject ckilit14;
    public GameObject ckilit15;
    public GameObject ckilit16;
    public GameObject ckilit17;
    public GameObject ckilit18;

    public GameObject skilit1;
    public GameObject skilit2;
    public GameObject skilit3;
    public GameObject skilit4;
    public GameObject skilit5;
    public GameObject skilit6;
    public GameObject skilit7;
    public GameObject skilit8;
    public GameObject skilit9;
    public GameObject skilit10;

    private void Start()
    {
        totalGem = PlayerPrefs.GetInt("totalGem");
        if (PlayerPrefs.GetInt("char1") == 1)
            ckilit1.SetActive(false);
        if (PlayerPrefs.GetInt("char2") == 1)
            ckilit2.SetActive(false);
        if (PlayerPrefs.GetInt("char3") == 1)
            ckilit3.SetActive(false);
        if (PlayerPrefs.GetInt("char4") == 1)
            ckilit4.SetActive(false);
        if (PlayerPrefs.GetInt("char5") == 1)
            ckilit5.SetActive(false);
        if (PlayerPrefs.GetInt("char6") == 1)
            ckilit6.SetActive(false);
        if (PlayerPrefs.GetInt("char7") == 1)
            ckilit7.SetActive(false);
        if (PlayerPrefs.GetInt("char8") == 1)
            ckilit8.SetActive(false);
        if (PlayerPrefs.GetInt("char9") == 1)
            ckilit9.SetActive(false);
        if (PlayerPrefs.GetInt("char10") == 1)
            ckilit10.SetActive(false);
        if (PlayerPrefs.GetInt("char11") == 1)
            ckilit11.SetActive(false);
        if (PlayerPrefs.GetInt("char12") == 1)
            ckilit12.SetActive(false);
        if (PlayerPrefs.GetInt("char13") == 1)
            ckilit13.SetActive(false);
        if (PlayerPrefs.GetInt("char14") == 1)
            ckilit14.SetActive(false);
        if (PlayerPrefs.GetInt("char15") == 1)
            ckilit15.SetActive(false);
        if (PlayerPrefs.GetInt("char16") == 1)
            ckilit16.SetActive(false);
        if (PlayerPrefs.GetInt("char17") == 1)
            ckilit17.SetActive(false);
        if (PlayerPrefs.GetInt("char18") == 1)
            ckilit18.SetActive(false);

        if (PlayerPrefs.GetInt("bskin1") == 1)
            skilit1.SetActive(false);
        if (PlayerPrefs.GetInt("bskin2") == 1)
            skilit2.SetActive(false);
        if (PlayerPrefs.GetInt("bskin3") == 1)
            skilit3.SetActive(false);
        if (PlayerPrefs.GetInt("bskin4") == 1)
            skilit4.SetActive(false);
        if (PlayerPrefs.GetInt("bskin5") == 1)
            skilit5.SetActive(false);
        if (PlayerPrefs.GetInt("bskin6") == 1)
            skilit6.SetActive(false);
        if (PlayerPrefs.GetInt("bskin7") == 1)
            skilit7.SetActive(false);
        if (PlayerPrefs.GetInt("bskin8") == 1)
            skilit8.SetActive(false);
        if (PlayerPrefs.GetInt("bskin9") == 1)
            skilit9.SetActive(false);
        if (PlayerPrefs.GetInt("bskin10") == 1)
            skilit10.SetActive(false);





    }
    public void buyChar1()
    {
        totalGem = PlayerPrefs.GetInt("totalGem");

        if (PlayerPrefs.GetInt("totalGem") >= 500)
        {
            price = totalGem - 500;
            PlayerPrefs.SetInt("char1", 1);
            PlayerPrefs.SetInt("totalGem", price);
            ckilit1.SetActive(false);
        }
    }
    public void buyChar2()
    {
        totalGem = PlayerPrefs.GetInt("totalGem");

        if (PlayerPrefs.GetInt("totalGem") >= 1000)
        {
            price = totalGem - 1000;
            PlayerPrefs.SetInt("char2", 1);
            PlayerPrefs.SetInt("totalGem", price);
            ckilit2.SetActive(false);

        }
    }
    public void buyChar3()
    {
        totalGem = PlayerPrefs.GetInt("totalGem");

        if (PlayerPrefs.GetInt("totalGem") >= 1500)
        {
            price = totalGem - 1500;
            PlayerPrefs.SetInt("char3", 1);
            PlayerPrefs.SetInt("totalGem", price);
            ckilit3.SetActive(false);

        }
    }
    public void buyChar4()
    {
        totalGem = PlayerPrefs.GetInt("totalGem");

        if (PlayerPrefs.GetInt("totalGem") >= 2000)
        {
            price = totalGem - 2000;
            PlayerPrefs.SetInt("char4", 1);
            PlayerPrefs.SetInt("totalGem", price);
            ckilit4.SetActive(false);

        }
    }
    public void buyChar5()
    {
        totalGem = PlayerPrefs.GetInt("totalGem");

        if (PlayerPrefs.GetInt("totalGem") >= 2000)
        {
            price = totalGem - 2000;
            PlayerPrefs.SetInt("char5", 1);
            PlayerPrefs.SetInt("totalGem", price);
            ckilit5.SetActive(false);

        }
    }
    public void buyChar6()
    {
        totalGem = PlayerPrefs.GetInt("totalGem");

        if (PlayerPrefs.GetInt("totalGem") >= 2000)
        {
            price = totalGem - 2000;
            PlayerPrefs.SetInt("char6", 1);
            PlayerPrefs.SetInt("totalGem", price);
            ckilit6.SetActive(false);

        }
    }
    public void buyChar7()
    {
        totalGem = PlayerPrefs.GetInt("totalGem");

        if (PlayerPrefs.GetInt("totalGem") >= 2250)
        {
            price = totalGem - 2250;
            PlayerPrefs.SetInt("char7", 1);
            PlayerPrefs.SetInt("totalGem", price);
            ckilit7.SetActive(false);

        }
    }
    public void buyChar8()
    {
        totalGem = PlayerPrefs.GetInt("totalGem");

        if (PlayerPrefs.GetInt("totalGem") >= 2250)
        {
            price = totalGem - 2250;
            PlayerPrefs.SetInt("char8", 1);
            PlayerPrefs.SetInt("totalGem", price);
            ckilit8.SetActive(false);

        }
    }
    public void buyChar9()
    {
        totalGem = PlayerPrefs.GetInt("totalGem");

        if (PlayerPrefs.GetInt("totalGem") >= 2250)
        {
            price = totalGem - 2250;
            PlayerPrefs.SetInt("char9", 1);
            PlayerPrefs.SetInt("totalGem", price);
            ckilit9.SetActive(false);

        }
    }
    public void buyChar10()
    {
        totalGem = PlayerPrefs.GetInt("totalGem");

        if (PlayerPrefs.GetInt("totalGem") >= 2500)
        {
            price = totalGem - 2500;
            PlayerPrefs.SetInt("char10", 1);
            PlayerPrefs.SetInt("totalGem", price);
            ckilit10.SetActive(false);

        }
    }

    public void buyChar11()
    {
        totalGem = PlayerPrefs.GetInt("totalGem");

        if (PlayerPrefs.GetInt("totalGem") >= 2500)
        {
            price = totalGem - 2500;
            PlayerPrefs.SetInt("char11", 1);
            PlayerPrefs.SetInt("totalGem", price);
            ckilit11.SetActive(false);

        }
    }

    public void buyChar12()
    {
        totalGem = PlayerPrefs.GetInt("totalGem");

        if (PlayerPrefs.GetInt("totalGem") >= 2500)
        {
            price = totalGem - 2500;
            PlayerPrefs.SetInt("char12", 1);
            PlayerPrefs.SetInt("totalGem", price);
            ckilit12.SetActive(false);

        }
    }

    public void buyChar13()
    {
        totalGem = PlayerPrefs.GetInt("totalGem");

        if (PlayerPrefs.GetInt("totalGem") >= 2500)
        {
            price = totalGem - 2500;
            PlayerPrefs.SetInt("char13", 1);
            PlayerPrefs.SetInt("totalGem", price);
            ckilit13.SetActive(false);

        }
    }

    public void buyChar14()
    {
        totalGem = PlayerPrefs.GetInt("totalGem");

        if (PlayerPrefs.GetInt("totalGem") >= 2500)
        {
            price = totalGem - 2500;
            PlayerPrefs.SetInt("char14", 1);
            PlayerPrefs.SetInt("totalGem", price);
            ckilit14.SetActive(false);

        }
    }

    public void buyChar15()
    {
        totalGem = PlayerPrefs.GetInt("totalGem");

        if (PlayerPrefs.GetInt("totalGem") >= 3000)
        {
            price = totalGem - 3000;
            PlayerPrefs.SetInt("char15", 1);
            PlayerPrefs.SetInt("totalGem", price);
            ckilit15.SetActive(false);

        }
    }

    public void buyChar16()
    {
        totalGem = PlayerPrefs.GetInt("totalGem");

        if (PlayerPrefs.GetInt("totalGem") >= 2500)
        {
            price = totalGem - 2500;
            PlayerPrefs.SetInt("char16", 1);
            PlayerPrefs.SetInt("totalGem", price);
            ckilit16.SetActive(false);

        }
    }

    public void buyChar17()
    {
        totalGem = PlayerPrefs.GetInt("totalGem");

        if (PlayerPrefs.GetInt("totalGem") >= 3000)
        {
            price = totalGem - 3000;
            PlayerPrefs.SetInt("char17", 1);
            PlayerPrefs.SetInt("totalGem", price);
            ckilit17.SetActive(false);

        }
    }

    public void buyChar18()
    {
        totalGem = PlayerPrefs.GetInt("totalGem");

        if (PlayerPrefs.GetInt("totalGem") >= 3000)
        {
            price = totalGem - 3000;
            PlayerPrefs.SetInt("char18", 1);
            PlayerPrefs.SetInt("totalGem", price);
            ckilit18.SetActive(false);
        }
    }

    /// <summary>
    /// Buy Skin
    /// </summary>

    public void buySkin1()
    {
        totalGem = PlayerPrefs.GetInt("totalGem");

        if (PlayerPrefs.GetInt("totalGem") >= 1000)
        {
            price = totalGem - 1000;
            PlayerPrefs.SetInt("bskin1", 1);
            PlayerPrefs.SetInt("totalGem", price);
            skilit1.SetActive(false);
        }
    }
    public void buySkin2()
    {
        totalGem = PlayerPrefs.GetInt("totalGem");

        if (PlayerPrefs.GetInt("totalGem") >= 1500)
        {
            price = totalGem - 1500;
            PlayerPrefs.SetInt("bskin2", 1);
            PlayerPrefs.SetInt("totalGem", price);
            skilit2.SetActive(false);
        }
    }
    public void buySkin3()
    {
        totalGem = PlayerPrefs.GetInt("totalGem");

        if (PlayerPrefs.GetInt("totalGem") >= 1500)
        {
            price = totalGem - 1500;
            PlayerPrefs.SetInt("bskin3", 1);
            PlayerPrefs.SetInt("totalGem", price);
            skilit3.SetActive(false);
        }
    }
    public void buySkin4()
    {
        totalGem = PlayerPrefs.GetInt("totalGem");

        if (PlayerPrefs.GetInt("totalGem") >= 2000)
        {
            price = totalGem - 2000;
            PlayerPrefs.SetInt("bskin4", 1);
            PlayerPrefs.SetInt("totalGem", price);
            skilit4.SetActive(false);
        }
    }
    public void buySkin5()
    {
        totalGem = PlayerPrefs.GetInt("totalGem");

        if (PlayerPrefs.GetInt("totalGem") >= 2000)
        {
            price = totalGem - 2000;
            PlayerPrefs.SetInt("bskin5", 1);
            PlayerPrefs.SetInt("totalGem", price);
            skilit5.SetActive(false);
        }
    }
    public void buySkin6()
    {
        totalGem = PlayerPrefs.GetInt("totalGem");

        if (PlayerPrefs.GetInt("totalGem") >= 2500)
        {
            price = totalGem - 2500;
            PlayerPrefs.SetInt("bskin6", 1);
            PlayerPrefs.SetInt("totalGem", price);
            skilit6.SetActive(false);
        }
    }
    public void buySkin7()
    {
        totalGem = PlayerPrefs.GetInt("totalGem");

        if (PlayerPrefs.GetInt("totalGem") >= 2500)
        {
            price = totalGem - 2500;
            PlayerPrefs.SetInt("bskin7", 1);
            PlayerPrefs.SetInt("totalGem", price);
            skilit7.SetActive(false);
        }
    }
    public void buySkin8()
    {
        totalGem = PlayerPrefs.GetInt("totalGem");

        if (PlayerPrefs.GetInt("totalGem") >= 3000)
        {
            price = totalGem - 3000;
            PlayerPrefs.SetInt("bskin8", 1);
            PlayerPrefs.SetInt("totalGem", price);
            skilit8.SetActive(false);
        }
    }
    public void buySkin9()
    {
        totalGem = PlayerPrefs.GetInt("totalGem");

        if (PlayerPrefs.GetInt("totalGem") >= 4000)
        {
            price = totalGem - 4000;
            PlayerPrefs.SetInt("bskin9", 1);
            PlayerPrefs.SetInt("totalGem", price);
            skilit9.SetActive(false);
        }
    }
    public void buySkin10()
    {
        totalGem = PlayerPrefs.GetInt("totalGem");

        if (PlayerPrefs.GetInt("totalGem") >= 5000)
        {
            price = totalGem - 5000;
            PlayerPrefs.SetInt("bskin10", 1);
            PlayerPrefs.SetInt("totalGem", price);
            skilit10.SetActive(false);
        }
    }
}
