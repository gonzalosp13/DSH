using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pulsar : MonoBehaviour
{
    private Button btn;
    public Image img;
    public Text texto;
    public Sprite[] spNumeros;

    private bool contar;
    private int numero;

    // Start is called before the first frame update
    void Start()
    {
        //btn = GameObject.FindAnyObjectByType<Button>();
        btn = GameObject.FindWithTag("btnStart").GetComponent<Button>();
        btn.onClick.AddListener(Pulsado);
        contar = false;
        numero = 3;
    }

    void Pulsado()
    {
        Debug.Log("pulsado");
        img.gameObject.SetActive(true);
        btn.gameObject.SetActive(false);
        texto.gameObject.SetActive(true);
        contar = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (contar)
        {
            switch (numero)
            {
                case 0: 
                    Debug.Log("Terminado - Salto a otra Escena");
                    break;
                case 1: 
                    img.sprite = spNumeros[0];
                    texto.text = "UNO";
                    break;
                case 2:
                    img.sprite = spNumeros[1];
                    texto.text = "DOS";
                    break;
                case 3:
                    img.sprite = spNumeros[2];
                    texto.text = "TRES";
                    break;
            }
            StartCoroutine(Esperar());
            contar = false;
            numero--;

        }
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(1);
        contar=true;

    }
}
