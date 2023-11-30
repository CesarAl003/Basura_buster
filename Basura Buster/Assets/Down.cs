using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Down : MonoBehaviour
{
    public Sprite[] sprites; // Array de sprites para asignar aleatoriamente
    public float tiempoEntreObjetos = 1f; // Tiempo en segundos entre la creación de nuevos objetos
    public float velocidadCaida = 5f;
    // Start is called before the first frame update
    void Start() {
         // Comienza el ciclo de creación de objetos
        InvokeRepeating("CrearNuevoObjeto", 0f, tiempoEntreObjetos);
    }

void CrearNuevoObjeto()
    {
        // Configurar posición inicial
        transform.position = new Vector2(Random.Range(-5f, 5f), 10f);
 
        // Asignar un sprite aleatorio si hay al menos un sprite en el arreglo
        if (sprites.Length > 0)
        {
            int indiceSprite = Random.Range(0, sprites.Length);
            GetComponent<SpriteRenderer>().sprite = sprites[indiceSprite];
        }
        else
        {
            Debug.LogError("No hay sprites asignados al arreglo. Asigna sprites en el Inspector.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Mover hacia abajo
        transform.Translate(Vector2.down * velocidadCaida * Time.deltaTime);

        // Verificar si el objeto está fuera de la pantalla y destruirlo
        if (transform.position.y < -20f)
        {
            Destroy(gameObject);
        }
    }
}
