// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


//Funciones de búsqueda
// Buscar persona 
document.addEventListener("DOMContentLoaded", function () {  // Espera a que la página cargue
    const btnBuscar = document.getElementById("btnBuscar");
    const inputBuscar = document.getElementById("buscarPersona");

    if (btnBuscar && inputBuscar) {
        btnBuscar.addEventListener("click", function () {
            let valor = inputBuscar.value.toLowerCase().trim();
            let filas = document.querySelectorAll("table tbody tr");

            filas.forEach(fila => {
                let texto = fila.textContent.toLowerCase();

                if (valor === "") {
                    fila.style.display = "";
                } else {
                    fila.style.display = texto.includes(valor) ? "" : "none";
                }
            });
        });
    }
});

//Buscar candidato
document.addEventListener("DOMContentLoaded", function () {  
    const btnBuscar = document.getElementById("btnBuscar");
    const inputBuscar = document.getElementById("buscarCandidato");

    if (btnBuscar && inputBuscar) {
        btnBuscar.addEventListener("click", function () {
            let valor = inputBuscar.value.toLowerCase().trim();
            let filas = document.querySelectorAll("table tbody tr");

            filas.forEach(fila => {
                let texto = fila.textContent.toLowerCase();

                if (valor === "") {
                    fila.style.display = "";
                } else {
                    fila.style.display = texto.includes(valor) ? "" : "none";
                }
            });
        });
    }
});

//Buscar lista
document.addEventListener("DOMContentLoaded", function () {
    const btnBuscar = document.getElementById("btnBuscar");
    const inputBuscar = document.getElementById("buscarLista");

    if (btnBuscar && inputBuscar) {
        btnBuscar.addEventListener("click", function () {
            let valor = inputBuscar.value.toLowerCase().trim();
            let filas = document.querySelectorAll("table tbody tr");

            filas.forEach(fila => {
                let texto = fila.textContent.toLowerCase();

                if (valor === "") {
                    fila.style.display = "";
                } else {
                    fila.style.display = texto.includes(valor) ? "" : "none";
                }
            });
        });
    }
});

//Buscar elección
document.addEventListener("DOMContentLoaded", function () {
    const btnBuscar = document.getElementById("btnBuscar");
    const inputBuscar = document.getElementById("buscarEleccion");

    if (btnBuscar && inputBuscar) {
        btnBuscar.addEventListener("click", function () {
            let valor = inputBuscar.value.toLowerCase().trim();
            let filas = document.querySelectorAll("table tbody tr");

            filas.forEach(fila => {
                let texto = fila.textContent.toLowerCase();

                if (valor === "") {
                    fila.style.display = "";
                } else {
                    fila.style.display = texto.includes(valor) ? "" : "none";
                }
            });
        });
    }
});
