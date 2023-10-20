﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// function validarContraseña(contra, contra2){
//     const regex = /^(?=.*[A-Z])(?=.*[$@$!%*?&-_])[A-Za-z\d$@$!%*?&-_]{8,}$/;
//     if(regex.test(contra) && contra === contra2){
    
//     }else if(!regex.test(contra)){
//         alert("La contraseña no cumple con los requisitos")
//     }else{
//         alert("Las contraseñas no coinciden")
//     }
    
//     }

function ConfirmarRegistro()
{

    let mensajeA = document.getElementById("mensajeA");
    let mensajeB = document.getElementById("mensajeB");
    let mensajeC = document.getElementById("mensajeC");

    const contraseña = document.getElementById("password").value;
    const caracteres = /[-_!(){}"#%&=°¿¡'?]/;
   

    let caracterencontrado = false;
    let caractermayus = false;

    if(contraseña.length < 8 || caracterencontrado == false || caractermayus == false)
    {
        if(contraseña != contraseña.toLowerCase())
        {
            caractermayus == true;   
        }


        for(i = 0; i < contraseña.length; i++)
        {
            for(a = 0; a < caracteres.length; a++)
            {
                if(contraseña[i] == caracteres[a])
                {
                    caracterencontrado == true;
                }
            }
                     
        }


    }
    console.log(caracterencontrado);
    console.log(caractermayus);

    mensajeA.style.color= (contraseña.length > 7 ? "green" : "red");
    mensajeB.style.color= (contraseña == contraseña.toLowerCase() ? "red" : "green");
    mensajeC.style.color= (caracteres.test(contraseña) ? "green" : "red");

    return(mensajeA.style.color == "green" && mensajeB.style.color == "green" && mensajeC.style.color == "green");
} 