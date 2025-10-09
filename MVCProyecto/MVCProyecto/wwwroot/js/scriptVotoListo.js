//Votos-Listo
document.addEventListener('DOMContentLoaded', function () {
    let chart;
    const modalResultados = document.getElementById('resultadoModal');

    if (!modalResultados) return; // evita error si el modal no existe

    modalResultados.addEventListener('show.bs.modal', async function (event) {
        const button = event.relatedTarget;
        const eleccionId = button.getAttribute('data-id');
        const nombre = button.getAttribute('data-nombre');

        // título del modal
        modalResultados.querySelector('.modal-title').textContent = `Resultados - ${nombre}`;

        try {
            const response = await fetch(`/Resultado/Obtener/${eleccionId}`);
            if (!response.ok) throw new Error("No hay resultados disponibles.");

            const data = await response.json();
            if (!data || data.length === 0) {
                alert("No hay resultados disponibles.");
                return;
            }

            const labels = data.map(r => r.nombreLista);
            const votos = data.map(r => r.totalVotos);
            const total = votos.reduce((a, b) => a + b, 0);

            // colores automáticos
            const colores = labels.map((_, i) =>
                `hsl(${(i * 360 / labels.length)}, 70%, 50%)`
            );

            if (chart) chart.destroy();

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
                                    let porcentaje = ((votos / total) * 100).toFixed(2);
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

//Votos-Emitir
document.addEventListener("DOMContentLoaded", () => {
    if (typeof bootstrap === "undefined") {
        console.warn("Bootstrap no está disponible todavía para inicializar tooltips.");
        return;
    }

    const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]');
    [...tooltipTriggerList].map(el => new bootstrap.Tooltip(el));
});

//Buscar Eleccion
document.addEventListener("DOMContentLoaded", function () {
    const btnBuscar = document.getElementById("btnBuscar");
    const inputBuscar = document.getElementById("buscarEleccion");

    if (btnBuscar && inputBuscar) {
        btnBuscar.addEventListener("click", function () {
            let valor = inputBuscar.value.toLowerCase().trim();
            let tarjetas = document.querySelectorAll(".eleccion-card");

            tarjetas.forEach(tarjeta => {
                let titulo = tarjeta.querySelector(".card-title")?.textContent.toLowerCase() || "";

                if (valor === "") {
                    tarjeta.style.display = "";
                } else {
                    tarjeta.style.display = titulo.includes(valor) ? "" : "none";
                }
            });
        });
    }
});
