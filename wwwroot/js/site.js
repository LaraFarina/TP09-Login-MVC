// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function validarContraseña() {
    var contraseña = document.getElementById("contrasena").value;
    var confirmarContraseña = document.getElementById("confirmar-contrasena").value;

    if (contraseña !== confirmarContraseña) {
        alert("Las contraseñas no coinciden.");
        return false;
    }

    // Verificar que la contraseña cumpla con los requisitos
    var caracteres = /^(?=.*[A-Z])(?=.*[!@#$%^&*])[A-Za-z\d!@#$%^&*]{8,}$/;
    if (!caracteres.test(contraseña)) {
        alert("La contraseña debe tener al menos 8 caracteres, una letra en mayúscula y un carácter especial.");
        return false;
    }

    return true;
}