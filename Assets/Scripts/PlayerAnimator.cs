using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    // var untuk mengambil fungsi IsWalking yang dimana mengembalikan kondisi move dari player
    [SerializeField] private Player player;
    // define konstanta untuk mengurangi kesalahan string pada pengisian parameter di method setBool()
    private const  string IS_WALKING = "IsWalking";
    private Animator animator;

    private void Awake() {
        // Jika component masih ditempel di object yang sama bisa menggunakan ini walaupun serializefield juga bisa
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //set bool dari parameter animasi 
        animator.SetBool(IS_WALKING, player.IsWalking());
    }
}
