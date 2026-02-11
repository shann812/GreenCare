import { updateAuthHeader } from "./header.js";
import { AuthService } from "../services/authService.js";
import { UIHelper } from "./UIHelper.js";

export function initLoginModal(){
    const form = document.getElementById('loginForm');
    
    form.addEventListener('submit', async (e) => {
        e.preventDefault();

        const data = {
            email: form.email.value,
            password: form.password.value
        };

        try{
            const result = await AuthService.login(data);
            if(!result.success){
                UIHelper.showErrors(result.error.message);
                return;
            }

            localStorage.setItem('token', result.data.token);
            localStorage.setItem('role', result.data.roleName);
            localStorage.setItem('userName', result.data.userName);
            localStorage.setItem('isLoggedIn', 'true');

            updateAuthHeader();
            UIHelper.showSuccess('Login success');

            bootstrap.Modal.getInstance(
                document.getElementById("loginModal")
            ).hide();
        }
        catch(err){
            UIHelper.showErrors(err);
        }
    })
}