import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { FormGroup } from '@angular/forms';
import { RepoStorage} from './repo-storage';
import { HttpHeaders } from '@angular/common/http';




@Injectable({
  providedIn: 'root'
})

export class UserService {

  constructor(private http: HttpClient, private UserSession: RepoStorage) { }
  readonly BaseURI = 'http://localhost:57087/api';


 

  register( formModel : FormGroup) {
  console.log( formModel.value.Role);

    var body = {
      UserName: formModel.value.UserName,
      Email:  formModel.value.Email,
      Address: formModel.value.Address,
      PhoneNumber: formModel.value.Phone,
      Role: formModel.value.Role,
      IsMale: Boolean(formModel.value.IsMale),
      Password: formModel.value.Passwords.Password
    };

    
    return this.http.post(this.BaseURI + '/Account/register', body,
                           { headers: new HttpHeaders({'Content-Type': 'Application/json'}) 
                           }
                         );
  }

 login(formLoginModel : FormGroup){
   var body = {
     UserName: formLoginModel.value.UserName,
     Password: formLoginModel.value.Password,
     RememberMe: Boolean(formLoginModel.value.RememberMe)
   };
   return this.http.post(this.BaseURI + '/Account/SignIn' , body);
 }

 logout(){
  //Remove token from session
   var token = sessionStorage.getItem("Token");
   //const headers = new HttpHeaders({'Authorization':'bearer '+ token});
  
    sessionStorage.removeItem("Token");
  return this.http.get(this.BaseURI + '/Account/logout', { headers: new HttpHeaders({'Authorization': 'Bearer ' + token}) }); 
 }

  changePassword(formChangeModel : FormGroup){
    var body = {
      OldPassword: formChangeModel.value.OldPassword,
      NewPassword: formChangeModel.value.Passwords.Password
    };
    var token = sessionStorage.getItem("Token");
    console.log(sessionStorage.getItem("Token"));
    let headers = new HttpHeaders();
    headers = headers.set('Authorization', 'Bearer ' + token);
    return this.http.post(this.BaseURI + '/Account/resetPassword' , body, {headers : headers});
  }
}
