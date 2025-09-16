// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


// Buscar persona 
document.addEventListener("DOMContentLoaded", function () {  // Espera a que la página cargue
    const btnBuscar = document.getElementById("btnBuscar");
    const inputBuscar = document.getElementById("buscarPersona");

    if (btnBuscar && inputBuscar) {
        btnBuscar.addEventListener("click", function () {
            let valor = inputBuscar.value.toLowerCase();
            let filas = document.querySelectorAll("table tbody tr");

            filas.forEach(fila => {
                let texto = fila.textContent.toLowerCase();
                fila.style.display = texto.includes(valor) ? "" : "none";
            });
        });
    }
});
