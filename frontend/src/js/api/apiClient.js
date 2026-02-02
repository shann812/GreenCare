export class ApiClient{
    static basicUrl = 'https://localhost:7181/api';

    static async request(url, options = {}){
        const token = localStorage.getItem('token');

        const headers = {
            'Content-Type': 'application/json',
            ...options.headers
        };

        if(token){
            headers['Authorization'] = `Bearer ${token}`;
        }

        const response = await fetch(this.basicUrl + url, {
            ...options,
            headers
        });

        const result = await response.json();

        if(!result){
            throw result;
        }

        return result;
    }
}