import { ToastService } from "./toastService.js";

export class UIHelper {

    static showErrors(error){
        if (error?.error?.details) {
            Object.values(error.error.details).forEach(msg =>
                ToastService.show(msg, 'danger')
            );
            return;
        }

        if (error?.error?.message){
            ToastService.show(error.error.message, 'danger');
            return;
        }

        if (typeof error === 'string') {
            ToastService.show(error, 'danger');
            return;
        }

        if (Array.isArray(error)) {
            error.forEach(msg => ToastService.show(msg, 'danger'));
            return;
        }
        
        ToastService.show('Unexpected error', 'danger');
    }

    static showSuccess(message){
        ToastService.show(message, 'success');
    }
}