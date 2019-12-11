import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Color } from '../models/color';

@Injectable()
export class ColorService{
    baseUrl: string;
    constructor(private _httpClient: HttpClient){
        this.baseUrl = `http://${location.hostname}:57087/api/`
    }
    getAllColor(): Observable<Color[]>{
        return this._httpClient.get<Color[]>(this.baseUrl + "color");
    }
    save(data: Color): Observable<Color> {
        if (data.ID > 0) {
            return this._httpClient.put<Color>(this.baseUrl + "Color/", data, {
                headers: new HttpHeaders({
                    'Content-Type': 'Application/json'
                })
            });
        }
        return this._httpClient.post<Color>(this.baseUrl + "Color", data, {            
            headers: new HttpHeaders({
                'Content-Type': 'Application/json'
            })
        });
    }
    getColorById(id) {
        return this._httpClient.get(this.baseUrl + "Color/" + id)
    }
    deleteColorById(id): Observable<void> {
        return this._httpClient.delete<void>(this.baseUrl + "Color/" + id)
    }
}