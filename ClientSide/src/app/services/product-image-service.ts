import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import { ProductImage } from '../models/productImage';

@Injectable()
export class ProductImagesService{
    baseUrl: string;
    constructor(private _httpClient: HttpClient){
        this.baseUrl = `http://${location.hostname}:57087/api/`
    }
    getAllImages(): Observable<ProductImage[]>{
        return this._httpClient.get<ProductImage[]>(this.baseUrl + "ProductImage");
    }
    saveImages(data): Observable<any>{
        return this._httpClient.post(this.baseUrl + "ProductImage", data);
    }
    getProductImagesById(id: number): Observable<ProductImage[]>{
        return this._httpClient.get<ProductImage[]>(this.baseUrl + "ProductImage/" + id, {
            headers: new HttpHeaders({
                "Content-Type" : "Application/Json"
            })
        });
    }
}