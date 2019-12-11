import { Component, OnInit, Injectable } from '@angular/core';
import { FormControl, Validators, FormGroup, FormBuilder } from '@angular/forms';
import {Color} from 'src/app/models/color';
import { ColorService } from 'src/app/services/color-service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-color-create',
  templateUrl: './color-create.component.html',
  styleUrls: ['./color-create.component.css']
})
@Injectable()
export class ColorCreateComponent implements OnInit {
  allColor: Color[];
  color: Color = new Color();
  colorForm: FormGroup;
  constructor(private formBuilder: FormBuilder, private colorService: ColorService, 
    private router: Router, private activateRoute: ActivatedRoute) { }

  ngOnInit() {
    this.colorService.getAllColor().subscribe(data=> this.allColor = data);
    this.colorForm = this.formBuilder.group({
      id: [0],
      name: ['', [Validators.required]]
    });
    this.activateRoute.paramMap.subscribe(param=> 
      {
        const id = +param.get('id');
        if(id){
          this.colorService.getColorById(id).subscribe(data=> this.editColor(data));
        }
      })
  }
  editColor(color){
    this.colorForm.patchValue({      
      id: color.id,
      name: color.name
    });
  }
  onSubmit(){
    this.setDataToColor();
      this.colorService.save(this.color).subscribe(
        data => {
          this.router.navigate(["/admin/manage/color/list"]);
        }
      );
  }
  onClear(){
    this.colorForm.reset();
  }
  onCancel(){
    this.router.navigate(["/admin/manage/color/list"]);
  }
  setDataToColor(){
    this.color.ID = this.colorForm.value.id;
    this.color.Name = this.colorForm.value.name;
  }
}
