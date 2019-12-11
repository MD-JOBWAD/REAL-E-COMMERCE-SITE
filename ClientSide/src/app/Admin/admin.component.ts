import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { UserService } from '../services/loginService/user.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  constructor(public service: UserService, private toastr: ToastrService) { }

  ngOnInit() {
  }
  onSignOut(){
    this.service.logout().subscribe(
      (res: any) => {
        if (res == true) {
          this.toastr.success('User Logout!', 'User SignOut successful.');
        } else {        
                 err => {console.log(err);}
               }
      }
    );
  }
}
