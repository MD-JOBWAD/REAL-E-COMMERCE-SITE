import { Component, OnInit } from '@angular/core';
import { FormControl, Validators, FormGroup, FormBuilder } from '@angular/forms';
import {Brand} from 'src/app/models/brand';
import { BrandService } from 'src/app/services/brand-service';
import { Router, ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-brand-create',
  templateUrl: './brand-create.component.html',
  styleUrls: ['./brand-create.component.css']
})

export class BrandCreateComponent implements OnInit {
  allBrand: Brand[];
  brand: Brand = new Brand();
  brandForm: FormGroup;
  constructor(private formBuilder: FormBuilder,
     private brandService: BrandService, 
    private router: Router, private activateRoute: ActivatedRoute) { }

  ngOnInit() {
    this.brandService.getAllBrand().subscribe(data=> this.allBrand = data);
    this.brandForm = this.formBuilder.group({
      id: [0],
      categoryId: ['', [Validators.required]],
      parentBrandId: ['', [Validators.required]],
      name: ['', [Validators.required]]
    });
    this.activateRoute.paramMap.subscribe(param=> 
      {
        const id = +param.get('id');
        if(id){
          this.brandService.getBrandById(id).subscribe(data=> this.editBrand(data));
        }
      })
  }
  editBrand(brand){
    this.brandForm.patchValue({      
      id: brand.id,
      categoryId: brand.categoryID,
      parentBrandId: brand.parentBandID,
      name: brand.bandName
    });
  }
  onSubmit(){
    this.setDataToBrand();
      this.brandService.save(this.brand).subscribe(
        data => {
          this.router.navigate(["/admin/manage/brand/list"]);
        }
      );
  }
  onClear(){
    this.brandForm.reset();
  }
  onCancel(){
    this.router.navigate(["/admin/manage/brand/list"]);
  }
  setDataToBrand(){
    this.brand.ID = this.brandForm.value.id;
    this.brand.CategoryID = this.brandForm.value.categoryId;
    this.brand.ParentBandID = this.brandForm.value.parentBrandId;
    this.brand.BandName = this.brandForm.value.name;
  }
}