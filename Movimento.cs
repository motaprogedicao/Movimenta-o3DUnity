using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController character;
    private Animator animator;
    private Vector3 inputs;
 

    private float velocidade = 2f;

    void Start()
    {
        character = GetComponent<CharacterController>(); //o metodo GetComponent passa por todos os componentes dentro do objeto do script procurando um componente do tipo especificado, quando ele encotrar ele vincula com a variavel que recebe o metodo.
        animator = GetComponent<Animator>();

         

    }

    // Update is called once per frame
    void Update()
    {
        inputs.Set(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); //Variavel de entrada, set para definir valores, Input.GetAxis para receber os inputs de cada eixo.
        character.Move(inputs * Time.deltaTime * velocidade); //funçao Move na qual você passa um vector3, que no caso é um Input, a função time.deltatime faz a movimentação ser suave e constante. 
        //character.Move(Vector3.down * Time.deltaTime); //Simulando a gravidade através de uma força que puxa o char pra baixo multiplicada pela velocidade.
       
        if(inputs != Vector3.zero) //Quando meu vetor de entrada for diferente de 0 
        {
            animator.SetBool("andando", true); //você está andando.
            //transform.forward = inputs; // direcionar o personagem para o mesmo eixo que esta apontando o input.
            transform.forward = Vector3.Slerp(transform.forward, inputs, Time.deltaTime * 10); //a função slerp faz a interpolação entre 2 vector3. 
            //no caso a interpolação é entre a rotação atual que é o primeiro parametro"transform.forward" e nova rotação a partir do input "input" e para o intervalo o timeDeltime vezes o valor que representa a interpolação   
        }

        else
        {
            animator.SetBool("andando", false); //senao você está parado.
        }
    }   
}
