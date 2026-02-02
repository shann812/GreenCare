import { ToastService } from "./toastService";

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

        ToastService.show('Unexpected error', 'danger');
    }

    static showSuccess(message){
        ToastService.show(message, 'success');
    }
}