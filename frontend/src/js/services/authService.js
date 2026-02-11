import { ApiClient } from "../api/apiClient.js";

export class AuthService{
    static async login(data){
        return ApiClient.request('/auth/login', {
            method: 'POST',
            body: JSON.stringify(data)
        });
    }
}