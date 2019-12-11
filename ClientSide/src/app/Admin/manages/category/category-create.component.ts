import { Component, OnInit, Injectable } from '@angular/core';
import { FormControl, Validators, FormGroup, FormBuilder } from '@angular/forms';
import { Category } from 'src/app/models/category';
import { CategoryService } from 'src/app/services/category-service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-category-create',
  templateUrl: './category-create.component.html',
  styleUrls: ['./category-create.component.css']
})
@Injectable()
export class CategoryCreateComponent implements OnInit {
  allCategory: Category[];
  category: Category = new Category();
  categoryForm: FormGroup;
  constructor(private formBuilder: FormBuilder, private categoryService: CategoryService, 
    private router: Router, private activateRoute: ActivatedRoute) { }

  ngOnInit() {
    this.categoryService.getAllCategory().subscribe(data=> this.allCategory = data);
    this.categoryForm = this.formBuilder.group({
      id: [0],
      name: ['', [Validators.required]],
      parentCategoryID: [''],
      displayOrder: ['', [Validators.min(1), Validators.pattern(/^-?(0|[1-9]\d*)?$/)]],
      isActive: ['']
    });
    this.activateRoute.paramMap.subscribe(param=> 
      {
        const id = +param.get('id');
        if(id){
          this.categoryService.getCategoryById(id).subscribe(data=> this.editCategory(data));
        }
      })
  }
  editCategory(category){
    this.categoryForm.patchValue({      
      id: category.id,
      name: category.name,
      parentCategoryID: category.parentCategoryID,
      displayOrder: category.displayOrder,
      isActive: category.isActive
    });
  }
  onSubmit(){
    this.setDataToCategory();
      this.categoryService.save(this.category).subscribe(
        data => {
          this.router.navigate(["/admin/manage/category/list"]);
        }
      );
  }
  onClear(){
    this.categoryForm.reset();
  }
  onCancel(){
    this.router.navigate(["/admin/manage/category/list"]);
  }
  setDataToCategory(){
    this.category.ID = this.categoryForm.value.id;
    this.category.Name = this.categoryForm.value.name;
    this.category.IsActive = this.categoryForm.value.isActive;
    this.category.DisplayOrder = this.categoryForm.value.displayOrder;
    this.category.ParentCategoryID = this.categoryForm.value.parentCategoryID;
  }
}
