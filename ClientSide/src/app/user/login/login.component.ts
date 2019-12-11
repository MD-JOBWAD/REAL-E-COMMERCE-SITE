import { Component, OnInit } from '@angular/core';


import { ToastrService } from 'ngx-toastr';
import { FormBuilder, Validators} from '@angular/forms';
import { UserService } from 'src/app/services/loginService/user.service';
import { RepoStorage } from 'src/app/services/loginService/repo-storage';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(public service: UserService, public UserSession: RepoStorage, private toastr: ToastrService, private fb: FormBuilder) { }

  ngOnInit() {
    this.formLoginModel.reset();
  }
  formLoginModel = this.fb.group({
    UserName : ['', Validators.required],
    Password: ['', Validators.required],
    RememberMe: ['']
  });

  onSubmit() {
    this.service.login(this.formLoginModel).subscribe(
      (res: any) => { 
            
        if (res != null) {
         
          sessionStorage.setItem("Token", res.token);
          this.formLoginModel.reset();
          console.log(sessionStorage.getItem("Token"));
          this.toastr.success('New user SignIn!', 'LogIn successful.');
        } else {
          res.errors.forEach(element => {
            switch (element.code) {
              case 'DuplicateUserName':
                this.toastr.error('Username or Password invalid','LogIn failed.');
                break;

              default:
              this.toastr.error(element.description,'LogIn failed.');
                break;
            }
          });
        }
      },
      err => {
        console.log(err);
      }
    );
  }

}
