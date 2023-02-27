using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public Camera camara;
    public int velocidad;
    public GameObject prefabSuelo;

    private Vector3 offset;
    private float valX;
    private float valZ;
    private Rigidbody rb;
    private Vector3 direccionActual;

    // Start is called before the first frame update
    void Start()
    {
        offset = camara.transform.position;
        valX = 0.0f;
        valZ = 0.0f;
        rb = GetComponent<Rigidbody>();
        direccionActual = Vector3.forward;

        SueloInicial();
    }

    // Update is called once per frame
    void Update()
    {
        camara.transform.position = this.transform.position + offset;
        if(Input.GetKeyUp(KeyCode.Space)){
            if(direccionActual == Vector3.forward)
                direccionActual = Vector3.right;
            else
                direccionActual = Vector3.forward;
        }
        float tiempo = velocidad * Time.deltaTime;
        rb.transform.Translate(direccionActual * tiempo);
    }

    void SueloInicial()
    {
        for (int n=0; n<3; n++)
        {
            valZ += 6.0f;
            GameObject elsuelo = Instantiate(prefabSuelo, new Vector3(valX, 0.0f, valZ), Quaternion.identity) as GameObject;
        }

    }

    void onCollisionExit(Collision other){
        if(other.transform.tag == "suelo"){
            StartCoroutine(CrearSuelo(other));
        }
    }

    IEnumerator CrearSuelo(Collision col){
        Debug.Log("cae");
        yield return new WaitForSeconds(0.5f);
        col.rigidbody.isKinematic = false;
        col.rigidbody.useGravity = true;
        yield return new WaitForSeconds(0.5f);
        Destroy(col.gameObject);
        float ran = Random.Range(0f, 1f);
        if (ran < 0.5f)
            valX += 6.0f;
        else   
            valZ += 6.0f;
        GameObject elsuelo = Instantiate(prefabSuelo, new Vector3(valX, 0.0f, valZ), Quaternion.identity) as GameObject;

    }
}
