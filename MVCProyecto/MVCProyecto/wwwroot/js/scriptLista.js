
// Cargar el contenido del modal dinámicamente
document.addEventListener('DOMContentLoaded', function () {
    var listaModal = document.getElementById('ModalLista');
    if (listaModal) {
        listaModal.addEventListener('show.bs.modal', function (event) {
            var button = event.relatedTarget;
            var url = button.getAttribute('data-url');
            var modalContent = document.getElementById('ModalListaContent');

            fetch(url)
                .then(response => response.text())
                .then(html => modalContent.innerHTML = html);
        });
    }
});

//--------Funciones de búsqueda--------
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
