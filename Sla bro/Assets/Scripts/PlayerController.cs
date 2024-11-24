using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Rigidbody2D playerRB;
    Animator animator;
    private string currentState;
    public string PlayerSide;

    Vector2 movement;

    const string Player_Idle_Back = "Player_Idle_Back";
    const string Player_Idle_Front = "Player_Idle_Front";
    const string Player_Idle_Left = "Player_Idle_Left";
    const string Player_Idle_Right = "Player_Idle_Right";

    const string Player_Walk_Front = "Player_Walk_Front";
    const string Player_Walk_Back = "Player_Walk_Back";
    const string Player_Walk_Left = "Player_Walk_Left";
    const string Player_Walk_Right = "Player_Walk_Right";


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        ChangeAnimationState(PlayerSide);
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        playerRB.MovePosition(playerRB.position + movement * speed * Time.deltaTime);
        CharIsWalking();

    }

    private void CharIsWalking()
    {
        if (movement.magnitude > 0) //Verifica se o Player está se Mexendo, e é uma Boa Forma de Rodar as Animações Certas quando se Anda pras Diagonais.
        {
            if (movement.x < 0) //Se o Player Estiver Andando pra Esquerda Trocar Animação pra "Andando pra Esquerda"
            {
                ChangeAnimationState(Player_Walk_Left);
            }
            else if (movement.x > 0) //Se o Player Estiver Andando pra Direita Trocar Animação pra "Andando pra Direita"
            {
                ChangeAnimationState(Player_Walk_Right);
            }
            else if (movement.y > 0) //Se o Player Estiver Andando pra Baixo Trocar Animação pra "Andando pra Baixo"
            {
                ChangeAnimationState(Player_Walk_Back);
            }
            else if (movement.y < 0) //Se o Player Estiver Andando pra Trás Trocar Animação pra "Andando pra Trás"
            {
                ChangeAnimationState(Player_Walk_Front);
            }
        }
        else //Se o Player não Estiver se Movendo, Verifique as Seguintes Condições
        {
            if (currentState == Player_Walk_Left) //Se o Player Estiver Parado mas sua Animação atual for "Andando pra Esquerda"
            {
                ChangeAnimationState(Player_Idle_Left);
            }
            else if (currentState == Player_Walk_Right) //Se o Player Estiver Parado mas sua Animação atual for "Andando pra Direita"
            {
                ChangeAnimationState(Player_Idle_Right);
            }
            else if (currentState == Player_Walk_Back) //Se o Player Estiver Parado mas sua Animação atual for "Andando pra Tras"
            {
                ChangeAnimationState(Player_Idle_Back);
            }
            else if (currentState == Player_Walk_Front) //Se o Player Estiver Parado mas sua Animação atual for "Andando pra Frente"
            {
                ChangeAnimationState(Player_Idle_Front);
            }
        }
    }


    void ChangeAnimationState(string newState)
    {
        //Impede a Animação de Interromper ela Mesma
        if (currentState == newState) return;

        //Iniciar a Animação
        animator.Play(newState);

        //Reatribui o Estado Atual
        currentState = newState;
    }

}