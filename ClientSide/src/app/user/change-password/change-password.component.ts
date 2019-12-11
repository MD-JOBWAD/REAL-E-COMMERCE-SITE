import { FormBuilder, Validators, FormGroup } from '@angular/forms';

import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { UserService } from 'src/app/services/loginService/user.service';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css']
})
export class ChangePasswordComponent implements OnInit {

  constructor(public service: UserService, private toastr: ToastrService, private fb: FormBuilder) { }

  ngOnInit() {
    this.formChangeModel.reset();
  }

  formChangeModel = this.fb.group({
    OldPassword: ['', Validators.required],
    Passwords: this.fb.group({
      Password: ['', [Validators.required, Validators.minLength(4)]],
      ConfirmPassword: ['', Validators.required]
    }, { validator: this.comparePasswords })
  });
  comparePasswords(fb: FormGroup) {
    let confirmPswrdCtrl = fb.get('ConfirmPassword');
    //passwordMismatch
    //confirmPswrdCtrl.errors={passwordMismatch:true}
    if (confirmPswrdCtrl.errors == null || 'passwordMismatch' in confirmPswrdCtrl.errors) {
      if (fb.get('Password').value != confirmPswrdCtrl.value)
        confirmPswrdCtrl.setErrors({ passwordMismatch: true });
      else
        confirmPswrdCtrl.setErrors(null);
    }
  }

  onSubmit() {
    this.service.changePassword(this.formChangeModel).subscribe(
      (res: any) => {
        if (res.succeeded) {
          this.formChangeModel.reset();
          this.toastr.success('New Passwor Created!', 'Password Changed successful.');
        } else {
          res.errors.forEach(element => {
            switch (element.code) {
              case 'DuplicateUserName':
                this.toastr.error('Password is not matched','Password Changing failed.');
                break;

              default:
              this.toastr.error(element.description,'Password Changing failed.');
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
