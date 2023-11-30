using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Down : MonoBehaviour {
    private bool estaSiendoArrastrada = false;
    private Vector3 posicionInicial;
    public Sprite[] sprites; // Array de sprites para asignar aleatoriamente
    public float tiempoEntreObjetos = 1f; // Tiempo en segundos entre la creación de nuevos objetos
    public float velocidadCaida = 1f;

    void Start() {
        // Comienza el ciclo de creación de objetos
        InvokeRepeating("CrearNuevoObjeto", 0f, tiempoEntreObjetos);
    }

    void CrearNuevoObjeto() {
        // Configurar posición inicial
        transform.position = new Vector2(Random.Range(-5f, 5f), 10f);

        // Asignar un sprite aleatorio
        int indiceSprite = Random.Range(0, sprites.Length);
        GetComponent<SpriteRenderer>().sprite = sprites[indiceSprite];
    }

    void Update() {
        // Verificar si el botón del mouse está siendo presionado
        if (Input.GetMouseButton(0)) {
            // Si la basura no está siendo arrastrada, registrar la posición inicial
            if (!estaSiendoArrastrada) {
                posicionInicial = transform.position;
                estaSiendoArrastrada = true;
            }

            // Obtener la posición del mouse en el mundo y actualizar la posición de la basura en el eje X
            Vector3 posicionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(posicionMouse.x, posicionInicial.y, posicionInicial.z);
        } else {
            // Si el botón del mouse no está siendo presionado, la basura ya no está siendo arrastrada
            estaSiendoArrastrada = false;
        }

        // Mover hacia abajo
        transform.Translate(Vector2.down * velocidadCaida * Time.deltaTime);

        // Verificar si el objeto está fuera de la pantalla y destruirlo
        if (transform.position.y < -20f) {
            Destroy(gameObject);
        }
    }
}
