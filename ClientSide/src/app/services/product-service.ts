import { Injectable } from '@angular/core';
import { Product } from '../Models/product';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class ProductService{
    baseUrl: string;
    constructor(private _httpClient: HttpClient){
        this.baseUrl = `http://${location.hostname}:57087/api/`
    }
    getAllProduct(): Observable<Product[]>{
        return this._httpClient.get<Product[]>(this.baseUrl + "product");
    }
    SaveProduct(data: Product): Observable<Product>{
        console.log(data);
        return this._httpClient.post<Product>(this.baseUrl + "product", data, {
            headers: new HttpHeaders({
                'Content-Type': 'Application/Json'
            })
        });
    }
    getProductById(id: number): Observable<Product>{
        return this._httpClient.get<Product>(this.baseUrl + "product/" + id, {
            headers: new HttpHeaders({
                'Content-Type': 'Application/Json'
            })
        });
    }
    getProductByCategoryId(id: number): Observable<Product[]>{
        return this._httpClient.get<Product[]>("http://localhost:57087/api/ProductByCategory/" + id, {
            headers: new HttpHeaders({
                "Content-Type": "Application/Json"
            })
        })
    }
}