import { AccountService } from "../services/AccountService.js";
import { Validator } from "../validators/validator.js";
import { UIHelper } from "../shared/UIHelper.js";

const registrationForm = document.getElementById('registrationForm');
const login = document.getElementById('login');
const email = document.getElementById('email');
const password = document.getElementById('password');
const passwordRepeat = document.getElementById('passwordRepeat');


registrationForm.addEventListener('submit', async function(e) {
    e.preventDefault();

    var user = {
        login: login.value.trim(),
        email: email.value.trim(),
        password: password.value,
        passwordRepeat: passwordRepeat.value
    }

    const errors = Validator.validateUserRegistration(user);
    if(errors.length > 0){
        UIHelper.showErrors(errors);
        return;
    }   

    try{
        await AccountService.registUser(user);
        UIHelper.showSuccess('Account created');
        //to main
    }
    catch(errors){
        UIHelper.showErrors(errors);
    }
})