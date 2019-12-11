import { Injectable } from '@angular/core';
import { HttpClient, HttpHandler, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from '../models/category';

@Injectable()
export class CategoryService {
    baseUrl: string;
    constructor(private _httpClient: HttpClient) {
        this.baseUrl = `http://${location.hostname}:57087/api/`
    }
    getAllCategory(): Observable<Category[]> {
        return this._httpClient.get<Category[]>(this.baseUrl + "category");
    }
    save(data: Category): Observable<Category> {
        if (data.ID > 0) {
            return this._httpClient.put<Category>(this.baseUrl + "category/" + data.ID, data, {
                headers: new HttpHeaders({
                    'Content-Type': 'Application/json'
                })
            });
        }
        return this._httpClient.post<Category>(this.baseUrl + "category", data, {            
            headers: new HttpHeaders({
                'Content-Type': 'Application/json'
            })
        });
    }
    getCategoryById(id) {
        return this._httpClient.get(this.baseUrl + "category/" + id)
    }
    deleteCategoryById(id): Observable<void> {
        return this._httpClient.delete<void>(this.baseUrl + "category/" + id)
    }
}