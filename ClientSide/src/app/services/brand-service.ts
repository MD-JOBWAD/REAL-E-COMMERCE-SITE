import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHandler, HttpHeaders } from '@angular/common/http';
import { Brand } from '../models/brand';

@Injectable()
export class BrandService{
    baseUrl: string;
    constructor(private _httpClient: HttpClient){
        this.baseUrl = `http://${location.hostname}:57087/api/`
    }
    getAllBrand(): Observable<Brand[]>{
        return this._httpClient.get<Brand[]>(this.baseUrl + "brand");
    }
    
    save(data: Brand): Observable<Brand> {
        if (data.ID > 0) {
            return this._httpClient.put<Brand>(this.baseUrl + "brand", data, {
                headers: new HttpHeaders({
                    'Content-Type': 'Application/json'
                })
            });
        }
        return this._httpClient.post<Brand>(this.baseUrl + "brand", data, {            
            headers: new HttpHeaders({
                'Content-Type': 'Application/json'
            })
        });
    }
    getBrandById(id) {
        return this._httpClient.get(this.baseUrl + "brand/" + id)
    }
    deleteBrandById(id): Observable<void> {
        return this._httpClient.delete<void>(this.baseUrl + "brand/" + id)
    }
}