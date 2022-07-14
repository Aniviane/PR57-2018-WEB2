import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RegisterDTO } from '../Models/RegisterDTO';
import { UserUrl } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserServiceService {

  constructor(private http:HttpClient) { 

  }


verifyUser(id:number):void {
  this.http.put(UserUrl + '/Users/Verify/${id}',{});
}

deleteUser(id:number):void {
  this.http.delete(UserUrl + '/api/Users/${id}');
}

getUsers():Observable<any[]> {
  return this.http.get<any[]>(UserUrl + '/api/Users');
}

  login(data:any):Observable<any[]> {
    return this.http.post<any[]>(UserUrl + 'Login', data); 
  }

  register(data:any):Observable<RegisterDTO> {
    return this.http.post<any>(UserUrl + 'api/Users', data);
  }
}

