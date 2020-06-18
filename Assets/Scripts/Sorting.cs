using System.Collections.Generic;
using UnityEngine;

public class Sorting : MonoBehaviour
{
    public GameManager config;

    private List<int> PossibleRoute()
    {
        List<int> aux = new List<int>();

        //0 = left || 1 = down || 2 = right || 3 = up
        for (int i = 0; i < 4; i++)
        {
            switch (i)
            {
                case 0:

                    int moveLeft = config.buttonEmpty.i + 1;

                    if (moveLeft < config.buttons.Length && config.buttons[moveLeft] != null && config.isPosValid(config.buttons[moveLeft].myRect.position))
                        aux.Add(moveLeft);

                    break;

                case 1:

                    int moveDown = config.buttonEmpty.i + config.columnNumber;

                    if (moveDown < config.buttons.Length && config.buttons[moveDown] != null && config.isPosValid(config.buttons[moveDown].myRect.position))
                        aux.Add(moveDown);

                    break;

                case 2:

                    int moveRight = config.buttonEmpty.i - 1;

                    if (moveRight > 0 && config.buttons[moveRight] != null && config.isPosValid(config.buttons[moveRight].myRect.position))
                        aux.Add(moveRight);

                    break;

                case 3:

                    int moveUp = config.buttonEmpty.i - config.columnNumber;

                    if (moveUp > 0 && config.buttons[moveUp] != null && config.isPosValid(config.buttons[moveUp].myRect.position))
                        aux.Add(moveUp);

                    break;
            }
        }
        return aux;
    }

    public void Sort(int times)
    {
        for (int i = 0; i < times; i++)
        {
            List<int> route = PossibleRoute();

            int rand = route[Random.Range(0, route.Count)];

            ChangePosInSort(config.buttons[rand]);
        }
    }

    private void ChangePosInSort(Item me)
    {
        if (config.isPosValid(me.myRect.position))
        {
            int btnI = me.i, btnEmpt = config.buttonEmpty.i;
            Vector2 buttonAux = new Vector2(config.buttonEmpty.myRect.position.x, config.buttonEmpty.myRect.position.y);

            config.buttons[me.i] = config.buttonEmpty;
            config.buttons[config.buttonEmpty.i] = me;

            config.buttons[btnEmpt].i = btnEmpt;
            config.buttonEmpty.i = btnI;

            config.buttonEmpty.myRect.position = me.myRect.position;
            me.myRect.position = buttonAux;
        }
    }
}
