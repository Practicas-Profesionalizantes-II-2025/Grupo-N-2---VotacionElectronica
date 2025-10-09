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

    // ---------- MODAL DINÁMICO PERSONA ----------
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
