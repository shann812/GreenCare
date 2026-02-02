export class ToastService {
    static show(message, type = "info") {
        const container = document.getElementById("toast-container");
        
        if (!container) {
            const newContainer = document.createElement("div");
            newContainer.id = "toast-container";
            document.body.appendChild(newContainer);
        }

        const toast = document.createElement("div");
        toast.className = `toast align-items-center text-bg-${type} border-0`;
        toast.role = "alert";
        toast.setAttribute("aria-live", "assertive");
        toast.setAttribute("aria-atomic", "true");

        toast.innerHTML = `
            <div class="toast-body">${message}</div>
        `;

        document.getElementById("toast-container").appendChild(toast);

        const bsToast = new bootstrap.Toast(toast, {
            delay: 2500,
            autohide: true,
            animation: true
        });
        
        bsToast.show();

        toast.addEventListener("hidden.bs.toast", () => {
            toast.remove();
        });
    }
}