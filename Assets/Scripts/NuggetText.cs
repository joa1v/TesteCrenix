using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NuggetText : MonoBehaviour
{
    public TMP_Text nuggetText;

    public void TaskCompletedTXT()
    {
        nuggetText.text = "Yay, Parabéns, Task concluída!";
    }

    public void DefaulTXT()
    {
        nuggetText.text = "Encaixe as engrenagens em qualquer ordem!";

    }
}
