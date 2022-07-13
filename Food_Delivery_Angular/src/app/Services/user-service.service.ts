import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RegisterDTO } from '../Models/RegisterDTO';

@Injectable({
  providedIn: 'root'
})
export class UserServiceService {
  readonly UserUrl = "https://localhost:7036/"
  constructor(private http:HttpClient) { 

  }

  login(data:any):Observable<any[]> {
    return this.http.post<any[]>(this.UserUrl + 'Login', data); 
  }

  register(data:any):Observable<RegisterDTO> {
    return this.http.post<any>(this.UserUrl + 'api/Users', data);
  }
}

