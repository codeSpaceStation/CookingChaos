using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // serializeField digunakan agar variable/property yang private bisa di akses editor aja
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rotateSpeed = 10f;
    private bool isWalking;

    private void Update() {
        // Vektor2 dikarenakan gerakan (move) player cuma dua sumbu yaitu atas, bawah (sumbu y) & kanan, kiri(sumbu x)
        Vector2 inputVector = new Vector2(0, 0);
        //Input User
        if (Input.GetKey(KeyCode.W)) {
            inputVector.y = +1;
        }
        if (Input.GetKey(KeyCode.S)) {
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.D)) {
            inputVector.x = +1;
            
        }if (Input.GetKey(KeyCode.A)) {
            inputVector.x = -1;
        }

        // Menormalisasikan input vektor dimana ketika konbinasi tombol diklik bersamaan size magnitude(besaran)nya ataupun kecepatan setiap sumbu bisa sama 
        inputVector = inputVector.normalized;

        //Mengkonver(cast) vektor2(input move) ke vektor 3 dikarenakan transform position itu vektor 3 (x,y,z)
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        // Me add input ke transform.position
        // Penambahan delta time untuk membuat kecepatan move karakter player tidak mengikuti/berdasarkan fps dari devicenya
        transform.position += moveDir * moveSpeed *  Time.deltaTime;

        //Membuat  visual karakter(transform) mengarah ke arah pergerakan karakter tsb 
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
        // Menyimpan kondisi atau value karakter bergerak (moveDir != Vector3(0,0,0)) 
        isWalking = moveDir != Vector3.zero;
    }

    // fungsi untuk mengembalikan kodisi dari karakter
    public bool IsWalking() {
        return isWalking;
    }
}
