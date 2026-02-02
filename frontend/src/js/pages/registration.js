import { AccountService } from "../services/AccountService";

const registrationForm = document.getElementById('registrationForm');

registrationForm.addEventListener('submit', async function(e) {
    e.defaultPrevented();

    var registUser = {
        login: document.getElementById('login'),
        email: document.getElementById('email'),
        password: document.getElementById('password'),
        passwordRepeat: document.getElementById('passwordRepeat')
    }

    await AccountService.registUser(registUser);
})