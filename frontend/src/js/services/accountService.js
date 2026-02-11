import { ApiClient } from '../api/apiClient.js';

export class AccountService{
    static async registUser(user){
        return ApiClient.request('/users/register', {
            method: 'POST',
            body: JSON.stringify(user)
        });    
    }
}
