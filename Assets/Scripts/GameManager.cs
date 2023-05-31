  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float velocidad = 2;
    public GameObject columna;
    public Renderer fondo;
    //obtaculos
    public GameObject block1;
    public GameObject block2;
    public GameObject block3;
    public GameObject block4;
    public GameObject block5;
    public GameObject block6;
  


    public List<GameObject> columnaLista;
    public List<GameObject> obstaculos;
    // Start is called before the first frame update
    void Start()
    {
        //Crear Mapa
        for (int i = 0; i < 21; i++) {
            columnaLista.Add(Instantiate(columna,new Vector2(-10+i,-3),Quaternion.identity));
        }

        //Obstaculos
        obstaculos.Add(Instantiate(block1, new Vector2(15, 4), Quaternion.identity));
        obstaculos.Add(Instantiate(block2, new Vector2(20, -1), Quaternion.identity));
        obstaculos.Add(Instantiate(block3, new Vector2(25, 3), Quaternion.identity));
        obstaculos.Add(Instantiate(block4, new Vector2(30, 1), Quaternion.identity));
        obstaculos.Add(Instantiate(block5, new Vector2(35, 4), Quaternion.identity));
        obstaculos.Add(Instantiate(block6, new Vector2(40, 2), Quaternion.identity));
    }

    // Update is called once per frame
    void Update()
    {
        fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.15f, 0) * Time.deltaTime;

        //Mover Mapa
        for (int i = 0; i < columnaLista.Count; i++)
        {
            if (columnaLista[i].transform.position.x <= -10) {
                columnaLista[i].transform.position= new Vector3(10, -3, 0);
            }
            columnaLista[i].transform.position= columnaLista[i].transform.position+new Vector3(-1, 0, 0)*Time.deltaTime*velocidad;
        }

        //Mover obstaculos
        for (int i = 0; i < obstaculos.Count; i++)
        {
            if (obstaculos[i].transform.position.x <= -10)
            {
                /*puntuacion += 100;
                Debug.Log("Puntuación: " + puntuacion);*/
                float randowmObsX = Random.Range(5, 20);
                float randowmObsY = Random.Range(-2, 4);
                obstaculos[i].transform.position = new Vector3(randowmObsX, randowmObsY, 0);
                
            }
            obstaculos[i].transform.position = obstaculos[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
        }
    }

}
