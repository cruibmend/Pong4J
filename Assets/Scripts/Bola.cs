using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{

    //Velocidad
    public float velocidad = 30.0f;

    //Toques
    public int toques = 1;

    //Contadores de goles
    public int golesIzquierda = 0;
    public int golesDerecha = 0;
    public int golesSuperior = 0;
    public int golesInferior = 0;

    //Último golpe
    public string posesion;

    //Cajas de texto de los contadores
    public TMPro.TextMeshProUGUI ContadorIzquierdo, ContadorDerecho, ContadorSuperior, ContadorInferior;

    // Start is called before the first frame update
    void Start()
    {
        float inicio = Random.Range(0, 4);
        //Velocidad inicial hacia una dirección aleatoria
        switch (inicio)
        {
            case 0:
                GetComponent<Rigidbody2D>().velocity = Vector2.right * velocidad;
            break;
            case 1:
                GetComponent<Rigidbody2D>().velocity = Vector2.left * velocidad;
            break;
            case 2:
                GetComponent<Rigidbody2D>().velocity = Vector2.up * velocidad;
            break;
            case 3:
                GetComponent<Rigidbody2D>().velocity = Vector2.down * velocidad;
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Se ejecuta al colisionar
    void OnCollisionEnter2D(Collision2D micolision){
        //transform.position es la posición de la bola
        //micolision contiene toda la información de la colisión
        //Si la bola colisiona con la raqueta:
        //micolision.gameObject es la raqueta
        //micolision.transform.position es la posición de la raqueta

        //Vector2 pos = new Vector2 (Random.Range (-10, 20), Random.Range (-5, 5));

        //Instantiate (GetComponent<Rigidbody2D>(), pos, transform.rotation);

        //Si choca con la raqueta izquierda
        if (micolision.gameObject.name == "RaquetaIzq"){

            //Valor de x
            int x = 1;

            //Aumento la variable de toques
            toques++;

            //Asigno el último golpe
            posesion = "Izquierda";

            //Valor de y
            int y = direccionY(transform.position, micolision.transform.position);

            //Vector de dirección
            Vector2 direccion = new Vector2(x, y);

            //Aplico velocidad y modifico por número de toques
            GetComponent<Rigidbody2D>().velocity = direccion * (velocidad + (velocidad * (toques / 4)));

        }

        //Si choca con la raqueta derecha
        if (micolision.gameObject.name == "RaquetaDer"){

            //Valor de x
            int x = -1;

            //Aumento la variable de toques
            toques++;

            //Asigno el último golpe
            posesion = "Derecha";

            //Valor de y
            int y = direccionY(transform.position, micolision.transform.position);

            //Vector de dirección
            Vector2 direccion = new Vector2(x, y);

            //Aplico velocidad
            GetComponent<Rigidbody2D>().velocity = direccion * (velocidad + (velocidad * (toques / 4)));

        }

        //Si choca con la raqueta superior
        if (micolision.gameObject.name == "RaquetaSup"){

            //Valor de x
            int x = direccionX(transform.position, micolision.transform.position);;

            //Valor de y
            int y = -1;

            //Aumento la variable de toques
            toques++;

            //Asigno el último golpe
            posesion = "Superior";

            //Vector de dirección
            Vector2 direccion = new Vector2(x, y);

            //Aplico velocidad
            GetComponent<Rigidbody2D>().velocity = direccion * (velocidad + (velocidad * (toques / 4)));

        }

        //Si choca con la raqueta inferior
        if (micolision.gameObject.name == "RaquetaInf"){

            //Valor de x
            int x = direccionX(transform.position, micolision.transform.position);;

            //Valor de y
            int y = 1;

            //Aumento la variable de toques
            toques++;

            //Asigno el último golpe
            posesion = "Inferior";

            //Vector de dirección
            Vector2 direccion = new Vector2(x, y);

            //Aplico velocidad
            GetComponent<Rigidbody2D>().velocity = direccion * (velocidad + (velocidad * (toques / 4)));

        }
    }

    //Método para calcular la direccion de Y (deevuelve un número entero int)
    int direccionY(Vector2 posicionBola, Vector2 posicionRaqueta){
        if (posicionBola.y > posicionRaqueta.y){
            return 1; //Si choca por la parte superior de la raqueta, sale hacia arriba
        }
        else if (posicionBola.y < posicionRaqueta.y){
            return -1; //Si choca por la parte inferior de la raqueta, sale hacia abajo
        }
        else{
            return 0; //Si choca por la parte central de la raqueta, sale en horizontal
        }
    }

    //Método para calcular la direccion de X (deevuelve un número entero int)
    int direccionX(Vector2 posicionBola, Vector2 posicionRaqueta){
        if (posicionBola.x > posicionRaqueta.x){
            return 1;
        }
        else if (posicionBola.x < posicionRaqueta.x){
            return -1;
        }
        else{
            return 0;
        }
    }

    public void reiniciarBola(){
        //Posición 0 de la bola
        transform.position = Vector2.zero;

        //Velocidad inicial de la bola
        velocidad = 30;

        if(toques > 0){
            if (posesion == "Derecha"){
                //Incremento goles al de la derecha
                golesDerecha++;
                //Lo escribo en el marcador
                ContadorDerecho.text = golesDerecha.ToString();
            }
            else if (posesion == "Izquierda"){
                //Incremento goles al de la izquierda
                golesIzquierda++;
                //Lo escribo en el marcador
                ContadorIzquierdo.text = golesIzquierda.ToString();
            }
            else if (posesion == "Superior"){
                //Incremento goles al de la izquierda
                golesSuperior++;
                //Lo escribo en el marcador
                ContadorSuperior.text = golesSuperior.ToString();
            }
            else if (posesion == "Inferior"){
                //Incremento goles al de la izquierda
                golesInferior++;
                //Lo escribo en el marcador
                ContadorInferior.text = golesInferior.ToString();
            }
        }
        //Reinicio los toques
        toques = 0;

        //Velocidad y dirección
        if (posesion == "Derecha"){
            GetComponent<Rigidbody2D>().velocity = Vector2.left * velocidad;
        }
        else if (posesion == "Izquierda"){
            GetComponent<Rigidbody2D>().velocity = Vector2.right * velocidad;
        }
        else if (posesion == "Superior"){
            GetComponent<Rigidbody2D>().velocity = Vector2.down * velocidad;
        }
        else if (posesion == "Inferior"){
            GetComponent<Rigidbody2D>().velocity = Vector2.up * velocidad;
        }
    }
}
