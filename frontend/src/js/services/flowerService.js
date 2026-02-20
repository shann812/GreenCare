import { ApiClient } from '../api/apiClient.js';

export class FlowerService{

    static async getFlowerTypes(){
        return ApiClient.request('/user-flowers/types', {
            method: 'GET'
        })
    }

    static async createFlower(formData){
        return ApiClient.request('/user-flowers/create', {
            method: 'POST',
            body: formData
        })
    }

    static async getUserFlowerCards(page, pageSize){
        return ApiClient.request('/user-flowers/my?page=${page}&pageSize=${pageSize}', {
            method: 'GET'
        })
    }
}