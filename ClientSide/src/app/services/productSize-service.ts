import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ProductSize } from '../models/productSize';

@Injectable()
export class ProductSizeService{
    baseUrl: string;
    constructor(private _httpClient: HttpClient){
        this.baseUrl = `http://${location.hostname}:57087/api/`
    }
    getAllProductSize(): Observable<ProductSize[]>{
        return this._httpClient.get<ProductSize[]>(this.baseUrl + "productSize");
    }
}