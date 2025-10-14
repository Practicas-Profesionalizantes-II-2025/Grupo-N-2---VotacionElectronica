document.addEventListener('DOMContentLoaded', function () {

    // ---------- TOAST ----------
    const toastContainer = document.getElementById('toastContainer') || (() => {
        const div = document.createElement('div');
        div.id = 'toastContainer';
        div.style.position = 'fixed';
        div.style.top = '1rem';
        div.style.right = '1rem';
        div.style.zIndex = '9999';
        document.body.appendChild(div);
        return div;
    })();

    function showToast(message, type = 'success', duration = 4000) {
        const toastEl = document.createElement('div');
        toastEl.className = `toast align-items-center text-bg-${type} border-0`;
        toastEl.setAttribute('role', 'alert');
        toastEl.setAttribute('aria-live', 'assertive');
        toastEl.setAttribute('aria-atomic', 'true');
        toastEl.style.minWidth = '200px';
        toastEl.innerHTML = `
            <div class="d-flex">
                <div class="toast-body">${message}</div>
                <button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast"></button>
            </div>
        `;
        toastContainer.appendChild(toastEl);
        const toast = new bootstrap.Toast(toastEl, { delay: duration });
        toast.show();
        toastEl.addEventListener('hidden.bs.toast', () => toastEl.remove());
    }

    // ---------- MODAL DINÁMICO  ----------
    const modalPersona = document.getElementById('ModalLista');
    if (!modalPersona) return;

    modalPersona.addEventListener('show.bs.modal', function (event) {
        const button = event.relatedTarget;
        const url = button.getAttribute('data-url');
        const modalContent = document.getElementById('ModalListaContent');

        if (!url || !modalContent) return;

        modalContent.innerHTML = '<p>Cargando...</p>';

        fetch(url)
            .then(resp => resp.text())
            .then(html => {
                modalContent.innerHTML = html;

                const form = modalContent.querySelector('form');
                if (!form) return;

                // Crear contenedor de mensajes dentro del modal si no existe
                let msgContainer = modalContent.querySelector('#modalMessage');
                if (!msgContainer) {
                    msgContainer = document.createElement('div');
                    msgContainer.id = 'modalMessage';
                    modalContent.prepend(msgContainer);
                }

                form.addEventListener('submit', function (e) {
                    e.preventDefault();
                    const formData = new FormData(form);

                    fetch(form.action, {
                        method: form.method,
                        body: formData
                    })
                        .then(resp => resp.json())
                        .then(data => {
                            if (data.success) {
                                showToast(data.message || 'Acción realizada correctamente.', 'success');
                                const bsModal = bootstrap.Modal.getInstance(modalPersona);
                                bsModal.hide();
                                setTimeout(() => location.reload(), 500);
                            } else {
                                // Mostrar mensaje dentro del modal arriba del formulario
                                msgContainer.innerHTML = `
                                    <div class="alert alert-danger alert-dismissible fade show" role="alert">
                                        ${data.message || 'Ocurrió un error.'}
                                        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                                    </div>
                                `;
                            }
                        })
                        .catch(err => {
                            console.error(err);
                            msgContainer.innerHTML = `
                                <div class="alert alert-danger alert-dismissible fade show" role="alert">
                                    Error inesperado.
                                    <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                                </div>
                            `;
                        });
                });
            })
            .catch(err => {
                console.error(err);
                modalContent.innerHTML = `<p class="text-danger">Error al cargar modal.</p>`;
                showToast('Error al cargar modal.', 'danger');
            });
    });
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
            const response = await fetch(`/Resultado/ObtenerResultados?eleccionId=${eleccionId}`);
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


//Busqueda
document.addEventListener("DOMContentLoaded", function () {
    const btnBuscar = document.getElementById("btnBuscar");
    const inputBuscar = document.getElementById("busqueda");

    if (btnBuscar && inputBuscar) {
        btnBuscar.addEventListener("click", function () {
            let valor = inputBuscar.value.toLowerCase().trim();
            let tbody = document.querySelector("table tbody");
            let filas = tbody.querySelectorAll("tr");
            let coincidencias = 0;

            filas.forEach(fila => {
                let texto = fila.textContent.toLowerCase();

                if (valor === "" || texto.includes(valor)) {
                    fila.style.display = "";
                    coincidencias++;
                } else {
                    fila.style.display = "none";
                }
            });

            // Ver si existe fila de mensaje
            let filaMensaje = tbody.querySelector(".mensaje-busqueda");
            if (!filaMensaje) {
                filaMensaje = document.createElement("tr");
                filaMensaje.classList.add("mensaje-busqueda");
                filaMensaje.innerHTML = `<td colspan="7" style="text-align:center; color:red;">No se encontraron resultados.</td>`;
                tbody.appendChild(filaMensaje);
            }

            // Mostrar o ocultar mensaje según coincidencias
            filaMensaje.style.display = (coincidencias === 0) ? "" : "none";
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
    // ---------- ASIGNAR LISTAS (con búsqueda y selección múltiple) ----------
    const modalListas = document.getElementById('modalAsignarLista');
    let listasCache = [];

    if (modalListas) {
        modalListas.addEventListener('show.bs.modal', async function (event) {
            const button = event.relatedTarget;
            const eleccionId = button.getAttribute('data-id');
            document.getElementById('EleccionIdLista').value = eleccionId;

            const tbody = document.getElementById('tablaListasDisponibles');
            tbody.innerHTML = `<tr><td colspan="3" class="text-center text-muted">Cargando...</td></tr>`;

            try {
                const response = await fetch(`/Eleccion/ObtenerListasDisponibles?eleccionId=${eleccionId}`);
                if (!response.ok) throw new Error('No se pudieron cargar las listas.');
                listasCache = await response.json();
                renderListas(listasCache);
            } catch (err) {
                console.error(err);
                tbody.innerHTML = `<tr><td colspan="3" class="text-center text-danger">Error al cargar</td></tr>`;
            }
        });
    }

    // 🔍 Búsqueda
    const inputBuscarLista = document.getElementById('buscarLista');
    if (inputBuscarLista) {
        inputBuscarLista.addEventListener('input', function () {
            const filtro = this.value.toLowerCase();
            const filtradas = listasCache.filter(l =>
                l.nombreLista.toLowerCase().includes(filtro)
            );
            renderListas(filtradas);
        });
    }

    // 🧭 Renderizar filas
    function renderListas(lista) {
        const tbody = document.getElementById('tablaListasDisponibles');
        if (!lista || lista.length === 0) {
            tbody.innerHTML = `<tr><td colspan="3" class="text-center text-muted">No hay listas disponibles</td></tr>`;
            return;
        }

        tbody.innerHTML = '';
        lista.forEach(l => {
            const tr = document.createElement('tr');
            tr.innerHTML = `
            <td><input type="checkbox" name="ListaIds" value="${l.id}" /></td>
            <td>${l.nombreLista}</td>
            <td>${l.descripcionLista ?? ''}</td>
        `;
            tbody.appendChild(tr);
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
    let personasCache = []; // Guardamos la lista original para poder filtrar

    if (modalPersona) {
        modalPersona.addEventListener('show.bs.modal', async function (event) {
            const button = event.relatedTarget;
            const eleccionId = button.getAttribute('data-id');
            document.getElementById('EleccionIdPersona').value = eleccionId;

            const tbody = document.getElementById('tablaPersonasDisponibles');
            tbody.innerHTML = `<tr><td colspan="4" class="text-center text-muted">Cargando...</td></tr>`;

            try {
                const response = await fetch(`/Eleccion/ObtenerPersonasDisponibles?eleccionId=${eleccionId}`);
                if (!response.ok) throw new Error('No se pudieron cargar las personas.');

                personasCache = await response.json();
                renderPersonas(personasCache);

            } catch (err) {
                console.error(err);
                tbody.innerHTML = `<tr><td colspan="4" class="text-center text-danger">Error al cargar</td></tr>`;
            }
        });
    }

    // 🔍 Búsqueda
    const inputBuscar = document.getElementById('buscarPersona');
    if (inputBuscar) {
        inputBuscar.addEventListener('input', function () {
            const filtro = this.value.toLowerCase();
            const filtradas = personasCache.filter(p =>
                p.dni.toString().includes(filtro) ||
                p.nombrePersona.toLowerCase().includes(filtro) ||
                p.apellidoPersona.toLowerCase().includes(filtro)
            );
            renderPersonas(filtradas);
        });
    }

    // 🧭 Renderizar filas
    function renderPersonas(lista) {
        const tbody = document.getElementById('tablaPersonasDisponibles');
        if (!lista || lista.length === 0) {
            tbody.innerHTML = `<tr><td colspan="4" class="text-center text-muted">No hay personas disponibles</td></tr>`;
            return;
        }

        tbody.innerHTML = '';
        lista.forEach(p => {
            const tr = document.createElement('tr');
            tr.innerHTML = `
            <td><input type="checkbox" name="PersonaIds" value="${p.id}" /></td>
            <td>${p.dni}</td>
            <td>${p.nombrePersona}</td>
            <td>${p.apellidoPersona}</td>
        `;
            tbody.appendChild(tr);
        });
    }
});

// ---------- CREAR PERSONA (modal AJAX) ----------
document.addEventListener("DOMContentLoaded", function () {
    const modalCrear = document.getElementById("modalCrearPersona");

    if (!modalCrear) return; // Si no existe en esta vista, no hace nada

    // Cuando se abre el modal, carga el contenido parcial
    modalCrear.addEventListener("show.bs.modal", async function (event) {
        const button = event.relatedTarget;
        const url = button.getAttribute("data-url"); // ej: /Persona/CrearPersona
        const modalContent = modalCrear.querySelector(".modal-content");

        try {
            const response = await fetch(url);
            if (!response.ok) throw new Error("Error al cargar el formulario.");
            const html = await response.text();
            modalContent.innerHTML = html;
        } catch (err) {
            modalContent.innerHTML = `<div class="p-3 text-danger">${err.message}</div>`;
        }
    });

    // Delegación: manejar el submit del formulario dentro del modal
    modalCrear.addEventListener("submit", async function (event) {
        const form = event.target;
        if (!form.matches("form")) return; // solo formularios
        event.preventDefault();

        const modalContent = modalCrear.querySelector(".modal-content");
        const formData = new FormData(form);

        try {
            const response = await fetch(form.action, {
                method: "POST",
                body: formData,
                headers: { "X-Requested-With": "XMLHttpRequest" } // indica petición AJAX
            });

            // Si devuelve JSON => creación exitosa
            const contentType = response.headers.get("content-type");
            if (response.ok && contentType && contentType.includes("application/json")) {
                const data = await response.json();
                if (data.success) {
                    bootstrap.Modal.getInstance(modalCrear).hide(); // cierra el modal
                    location.reload(); // o actualizá solo la tabla si querés
                    return;
                }
            }

            // Si devuelve HTML => hubo error de validación, se reemplaza el contenido del modal
            const html = await response.text();
            modalContent.innerHTML = html;

        } catch (err) {
            console.error(err);
            modalContent.innerHTML = `<div class="p-3 text-danger">Error al enviar el formulario.</div>`;
        }
    });
});

