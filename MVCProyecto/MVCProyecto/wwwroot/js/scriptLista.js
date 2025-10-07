
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

//Resultado-Gráficos

document.addEventListener('DOMContentLoaded', function () {
    let chart;
    const modalResultados = document.getElementById('resultadoModal');

    if (!modalResultados) return;

    // Función para generar colores distintos según cantidad de listas
    function generarColores(cantidad) {
        return Array.from({ length: cantidad }, (_, i) =>
            `hsl(${(i * 360) / cantidad}, 70%, 60%)`
        );
    }

    modalResultados.addEventListener('show.bs.modal', async function (event) {
        const button = event.relatedTarget;
        const eleccionId = button.getAttribute('data-id');
        const nombre = button.getAttribute('data-nombre');

        // Setear título con el nombre de la elección
        modalResultados.querySelector('.modal-title').textContent = `Resultados - ${nombre}`;

        try {
            const response = await fetch(`/Resultado/Obtener/${eleccionId}`);
            if (!response.ok) throw new Error("No hay resultados disponibles.");

            const data = await response.json();
            if (!data || data.length === 0) {
                alert("No hay resultados disponibles.");
                return;
            }

            // Datos para gráfico
            const labels = data.map(r => r.nombreLista);
            const votos = data.map(r => r.totalVotos);
            const total = votos.reduce((a, b) => a + b, 0);
            const colores = generarColores(labels.length);

            // Destruir gráfico previo
            if (chart) chart.destroy();

            // Crear gráfico
            const ctx = document.getElementById("resultadoChart").getContext("2d");
            chart = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: labels,
                    datasets: [{
                        label: "Votos",
                        data: votos,
                        backgroundColor: colores,
                        borderColor: colores,
                        borderWidth: 1
                    }]
                },
                options: {
                    responsive: true,
                    plugins: {
                        tooltip: {
                            callbacks: {
                                label: function (context) {
                                    let votos = context.raw;
                                    let porcentaje = total > 0
                                        ? ((votos / total) * 100).toFixed(2)
                                        : 0;
                                    return `${votos} votos (${porcentaje}%)`;
                                }
                            }
                        }
                    }
                }
            });

        } catch (err) {
            alert(err.message);
        }
    });
});

//Votos

document.addEventListener('DOMContentLoaded', function () {
    const modalCandidatos = document.getElementById('candidatosModal');

    if (!modalCandidatos) return; // evita error si el modal no existe en esta vista

    modalCandidatos.addEventListener('show.bs.modal', async function (event) {
        const button = event.relatedTarget;
        const listaId = button.getAttribute('data-id');
        const content = document.getElementById('candidatosContent');

        content.innerHTML = "Cargando...";

        try {
            const response = await fetch(`/Candidatos/PorLista/${listaId}`);
            if (!response.ok) throw new Error("Error al cargar candidatos");

            const data = await response.json();

            if (data && data.length > 0) {
                let html = "<ul class='list-group'>";
                data.forEach(c => {
                    html += `
                        <li class='list-group-item'>
                            <strong>${c.puestoCandidato}</strong> - ${c.nombreCandidato}
                        </li>`;
                });
                html += "</ul>";
                content.innerHTML = html;
            } else {
                content.innerHTML = "<p>No hay candidatos para esta lista.</p>";
            }
        } catch (err) {
            console.error(err);
            content.innerHTML = "<p class='text-danger'>Error al cargar los candidatos.</p>";
        }
    });
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

//Eleccion
document.addEventListener('DOMContentLoaded', function () {

    // Helper: tomar token AntiForgery global
    function getCsrfToken() {
        const input = document.querySelector('#__afForm input[name="__RequestVerificationToken"]');
        return input ? input.value : '';
    }

    // ---------- ASIGNAR LISTA ----------
    const modalLista = document.getElementById('modalAsignarLista');
    if (modalLista) {
        modalLista.addEventListener('show.bs.modal', async function (event) {
            const button = event.relatedTarget;
            const eleccionId = button.getAttribute('data-id');
            document.getElementById('EleccionIdLista').value = eleccionId;

            try {
                const response = await fetch(`/Eleccion/ObtenerListasDisponibles?eleccionId=${eleccionId}`);
                if (!response.ok) throw new Error('No se pudieron cargar las listas disponibles.');
                const listas = await response.json();

                const select = document.getElementById('ListaId');
                select.innerHTML = '<option value="">-- Seleccione --</option>';
                listas.forEach(l => {
                    const opt = document.createElement('option');
                    opt.value = l.id;
                    opt.text = l.nombreLista;
                    select.appendChild(opt);
                });
            } catch (err) {
                alert(err.message);
            }
        });
    }

    // ---------- VER LISTAS ASIGNADAS ----------
    const modalVer = document.getElementById('modalVerListas');
    if (modalVer) {
        modalVer.addEventListener('show.bs.modal', async function (event) {
            const button = event.relatedTarget;
            const eleccionId = button.getAttribute('data-id');

            try {
                const response = await fetch(`/Eleccion/ObtenerListasAsignadas?eleccionId=${eleccionId}`);
                if (!response.ok) throw new Error('No se pudieron cargar las listas asignadas.');
                const listas = await response.json();

                const token = getCsrfToken();
                const tbody = document.getElementById('listasAsignadasBody');
                tbody.innerHTML = '';

                if (!listas || listas.length === 0) {
                    tbody.innerHTML = "<tr><td colspan='4' class='text-center'>No hay listas asignadas</td></tr>";
                    return;
                }

                listas.forEach(l => {
                    const tr = document.createElement('tr');
                    tr.innerHTML = `
                        <td>${l.id}</td>
                        <td>${l.nombreLista ?? ''}</td>
                        <td>${l.descripcionLista ?? ''}</td>
                        <td>
                            ${l.nombreLista && l.nombreLista.toLowerCase() === "voto en blanco"
                            ? "<em>No se puede quitar</em>"
                            : `
                                    <form method="post" action="/Eleccion/QuitarLista">
                                        <input type="hidden" name="__RequestVerificationToken" value="${token}" />
                                        <input type="hidden" name="eleccionId" value="${eleccionId}" />
                                        <input type="hidden" name="listaId" value="${l.id}" />
                                        <button type="submit" class="btn btn-danger btn-sm">Quitar</button>
                                    </form>
                                `
                        }
                        </td>
                    `;
                    tbody.appendChild(tr);
                });
            } catch (err) {
                alert(err.message);
            }
        });
    }

    // ---------- ASIGNAR PERSONA ----------
    const modalPersona = document.getElementById('modalAsignarPersona');
    if (modalPersona) {
        modalPersona.addEventListener('show.bs.modal', async function (event) {
            const button = event.relatedTarget;
            const eleccionId = button.getAttribute('data-id');
            document.getElementById('EleccionIdPersona').value = eleccionId;

            try {
                const response = await fetch(`/Eleccion/ObtenerPersonasDisponibles?eleccionId=${eleccionId}`);
                if (!response.ok) throw new Error('No se pudieron cargar las personas.');

                const personas = await response.json();
                const select = document.getElementById('PersonaId');
                select.innerHTML = '<option value="">-- Seleccione --</option>';

                personas.forEach(p => {
                    const opt = document.createElement('option');
                    opt.value = p.id;
                    opt.text = `${p.nombrePersona} ${p.apellidoPersona} - ${p.dni}`;
                    select.appendChild(opt);
                });
            } catch (err) {
                alert(err.message);
            }
        });
    }
});

