export class Validator{
    static validateUserRegistration(user){
        const errors = [];

        if(!user.login || user.login.trim() === ''){
            errors.push("Enter your login"); 
        } else if(user.login.length < 4 || user.login.length > 15){
            errors.push("Login must be 4-15 characters");
        }

        if(!user.email || user.email.trim() === ''){
            errors.push("Enter your email"); 
        } else if (!user.email.includes("@")){ 
            errors.push("Enter correct email");
        }

        if(!user.password || user.password.trim() === ''){
            errors.push("Enter your password"); 
        } else if(user.password.length < 6 || user.password.length > 20){
            errors.push("Password must be 6-20 characters");
        }
 
        if(!user.passwordRepeat || user.passwordRepeat.trim() === ''){
            errors.push("Repeat your password"); 
        } else if(user.password !== user.passwordRepeat){
            errors.push("Passwords don't match");
        }

        return errors;
    }
}