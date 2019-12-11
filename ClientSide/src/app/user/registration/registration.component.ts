import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { FormBuilder, Validators, FormGroup, FormControl } from '@angular/forms';
import { UserService } from 'src/app/services/loginService/user.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styles: []
})

export class RegistrationComponent implements OnInit {

  constructor(public service: UserService, private toastr: ToastrService, private fb: FormBuilder) {
    
   }

  ngOnInit() {
    //this.formModel.reset();
    //this.formModel.controls["Role"].setValue("123");
  }

  formModel = this.fb.group({
    UserName: new FormControl("", Validators.required),
    Email: ['', Validators.email],
    Address: [""],
    Phone: ["", Validators.required],
    Role: ['General'],
    IsMale: ["false"],
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
    this.service.register(this.formModel).subscribe(
      (res: any) => {
        if (res.succeeded) {
          this.formModel.reset();
          this.toastr.success('New user created!', 'Registration successful.');
        } else {
          res.errors.forEach(element => {
            switch (element.code) {
              case 'DuplicateUserName':
                this.toastr.error('Username is already taken','Registration failed.');
                break;

              default:
              this.toastr.error(element.description,'Registration failed.');
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
