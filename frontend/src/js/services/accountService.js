import { ApiClient } from '../api/apiClient';

export class AccountService{
    static async registUser(user){
        try{
            return ApiClient.request('/users/register', {
                method: 'POST',
                body: JSON.stringify(data)
            });
        }
        catch(err){
            //toast
        }
    }
}
