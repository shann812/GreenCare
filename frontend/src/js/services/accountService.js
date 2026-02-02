import { ApiClient } from '../api/apiClient';

export class AccountService{
    static async registUser(user){
        return ApiClient.request('/users/register', {
                method: 'POST',
                body: JSON.stringify(user)
            });    
    }
}
