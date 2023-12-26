function validarLogIn() {
    var email = document.getElementById('tboxEmail');
    var pass = document.getElementById('tboxPass');
    var mensaje = document.getElementById('mensajeLogIn');

    var validarCampo = function (campo, validation) {
        if (campo.value == "" || validation.test(campo.value) == false) {
            campo.classList.add("is-invalid");
            return false;
        }
        else
            return true;
    };

    var emailValido = validarCampo(email, /^[^\s@]+@[^\s@]+\.[^\s@]+$/);
    var passValido = validarCampo(pass, /\S/);

    if ((emailValido && passValido) == true) {
        return emailValido && passValida;
    }
    else {
        mensaje.textContent = 'Las credenciales son incorrectas';
        return emailValido && passValida;
    };
}

function validarSingUp() {
    var email = document.getElementById('tboxEmail');
    var pass = document.getElementById('tboxPass');
    var passConfirm = document.getElementById('tboxPassConfirm');
    var mensajeEmail = document.getElementById('mensajeEmail');
    var mensajePass = document.getElementById('mensajePass');
    var mensajePassConfirm = document.getElementById('mensajePassConfirm');

    var validarCampo = function (campo,mensaje, validation, confirm) {
        if (campo.value == "") {
            campo.classList.remove("is-valid");
            campo.classList.add("is-invalid");
            mensaje.textContent = "El campo no puede quedar vacío";

            return false;
        }
        else if (!validation.test(campo.value)) {
            campo.classList.remove("is-valid");
            campo.classList.add("is-invalid");
            mensaje.textContent = "El formato no es valido";

            return false;
        }
        else if (confirm != null && campo.value != confirm.value) {
            campo.classList.remove("is-valid");
            campo.classList.add("is-invalid");
            mensaje.textContent = "Las contraseñas no coinciden";

            return false;
        }
        else {
            campo.classList.remove("is-invalid");
            campo.classList.add("is-valid");
            return true;
        };
    };

    var emailValido = validarCampo(email,mensajeEmail, /^[^\s@]+@[^\s@]+\.[^\s@]+$/, null);
    var passValido = validarCampo(pass, mensajePass, /\S/, null);
    var passConfirmValido = validarCampo(passConfirm, mensajePassConfirm, /\S/, pass);

    return emailValido && passValido && passConfirmValido;
}

function validarChangePass() {
    var email = document.getElementById('tboxEmail');
    var pass = document.getElementById('tboxPass');
    var newPass = document.getElementById('tboxNewPass');
    var newPassConfirm = document.getElementById('tboxNewPassConfirm');
    var mensajeEmail = document.getElementById('mensajeEmail');
    var mensajePass = document.getElementById('mensajePass');
    var mensajeNewPass = document.getElementById('mensajeNewPass');
    var mensajeNewPassConfirm = document.getElementById('mensajeNewPassConfirm');

    var validarCampo = function (campo, mensaje, validation, confirm) {
        if (campo.value == "") {
            campo.classList.remove("is-valid");
            campo.classList.add("is-invalid");
            mensaje.textContent = "El campo no puede quedar vacío";

            return false;
        }
        else if (!validation.test(campo.value)) {
            campo.classList.remove("is-valid");
            campo.classList.add("is-invalid");
            mensaje.textContent = "El formato no es valido";

            return false;
        }
        else if (confirm != null && campo.value != confirm.value) {
            campo.classList.remove("is-valid");
            campo.classList.add("is-invalid");
            mensaje.textContent = "Las contraseñas no coinciden";

            return false;
        }
        else {
            campo.classList.remove("is-invalid");
            campo.classList.add("is-valid");
            return true;
        };
    };

    var emailValido = validarCampo(email, mensajeEmail, /^[^\s@]+@[^\s@]+\.[^\s@]+$/, null);
    var passValido = validarCampo(pass, mensajePass, /\S/, null);
    var newPassValido = validarCampo(newPass, mensajeNewPass, /\S/, null);
    var newPassConfirmValido = validarCampo(newPassConfirm, mensajeNewPassConfirm, /\S/, newPass);

    return emailValido && passValido && newPassValido && newPassConfirmValido;
}

//"^[A-Za-z]+$" solo letras
function validarPerfil() {
    var nombre = document.getElementById('tboxNombre');
    var apellido = document.getElementById('tboxApellido');
    var mensajeNombre = document.getElementById('mensajeNombre');
    var mensajeApellido = document.getElementById('mensajeApellido');

    var validar = function (campo, mensaje, formato) {
        if (!formato.test(campo.value)) {
            campo.classList.remove("is-valid");
            campo.classList.add("is-invalid");
            mensaje.textContent = "Solo letras";

            return false;
        }
        campo.classList.remove("is-invalid");
        campo.classList.add("is-valid");
        return true;
    };

    var validarNombre = validar(nombre, mensajeNombre, /^[A-Za-z ]+$/);
    var validarApellido = validar(apellido, mensajeApellido, /^[A-Za-z ]+$/);

    return validarApellido && validarNombre;
}
