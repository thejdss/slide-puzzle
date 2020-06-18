using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int winNumber; // total number of buttons
    public int minimumDistance = 80;
    public int columnNumber; // number of columns (in Grid Layout Group component)
    public Text winText;

    public Item buttonEmpty;
    public Item[] buttons;
    
    public void ChangePos(Item me)
    {
        if (isPosValid(me.myRect.position))
        {
            int btnI = me.i, btnEmpt = buttonEmpty.i; 
            Vector2 buttonAux = new Vector2(buttonEmpty.myRect.position.x, buttonEmpty.myRect.position.y);

            buttons[me.i] = buttonEmpty;
            buttons[buttonEmpty.i] = me;

            buttons[btnEmpt].i = btnEmpt;
            buttonEmpty.i = btnI;
            
            buttonEmpty.myRect.position = me.myRect.position;
            me.myRect.position = buttonAux;

            CheckWin();
        }
    }

    public bool isPosValid(Vector2 pos)
    {
        int xPos = Mathf.Abs((int)pos.x - (int)buttonEmpty.myRect.position.x);
        int yPos = Mathf.Abs((int)pos.y - (int)buttonEmpty.myRect.position.y);

        if ((xPos + yPos) <= minimumDistance)
        {
            return true;
        }

        return false;
    }

    private void CheckWin()
    {
        int count = 0;

        for (int i = 0; i < buttons.Length; i++)
        {
            Text[] btnText = buttons[i].GetComponentsInChildren<Text>();

            if (btnText.Length > 0)
            {
                if (int.Parse(btnText[0].text).Equals(i + 1))
                    count++;
                else
                    break;
            }
            else
                break;
        }

        if (count.Equals(winNumber))
        {
            winText.text = "You Win !!";
        }
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
