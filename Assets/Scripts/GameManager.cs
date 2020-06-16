using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int winNumber; // total number of buttons
    public int minimumDistance = 80;
    public Text winText;
    public GameObject restartButton;

    public ButtonP buttonEmpty;
    public ButtonP[] buttons;
    
    public void ChangePos(ButtonP me)
    {
        int xPos = Mathf.Abs((int)me.myRect.position.x - (int)buttonEmpty.myRect.position.x);
        int yPos = Mathf.Abs((int)me.myRect.position.y - (int)buttonEmpty.myRect.position.y);

        Debug.LogFormat("Minimum distance = {0}", (xPos + yPos));

        if ((xPos + yPos) <= minimumDistance)
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

    public void Sort(int times)
    {
        for (int i = 0; i < times; i++)
        {
            int rand = Random.Range(0, buttons.Length);

            ChangePosInSort(buttons[rand]);
        }
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

    private void ChangePosInSort(ButtonP me)
    {
        int xPos = Mathf.Abs((int)me.myRect.position.x - (int)buttonEmpty.myRect.position.x);
        int yPos = Mathf.Abs((int)me.myRect.position.y - (int)buttonEmpty.myRect.position.y);

        if ((xPos + yPos) <= 55)
        {
            int btnI = me.i, btnEmpt = buttonEmpty.i;
            Vector2 buttonAux = new Vector2(buttonEmpty.myRect.position.x, buttonEmpty.myRect.position.y);

            buttons[me.i] = buttonEmpty;
            buttons[buttonEmpty.i] = me;

            buttons[btnEmpt].i = btnEmpt;
            buttonEmpty.i = btnI;

            buttonEmpty.myRect.position = me.myRect.position;
            me.myRect.position = buttonAux;
        }
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
