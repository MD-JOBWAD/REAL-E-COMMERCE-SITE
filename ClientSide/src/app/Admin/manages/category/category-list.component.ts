import { Component, OnInit, ViewChild, Injectable, EventEmitter } from '@angular/core';
import { MatTableDataSource} from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { Category } from 'src/app/models/category';
import { CategoryService } from 'src/app/services/category-service';
import { DataSource } from '@angular/cdk/collections';
import { BehaviorSubject } from 'rxjs';
import { Router } from '@angular/router';
import { CategoryCreateComponent } from './category-create.component';
import { ConfilmDeleteDialogServiece } from 'src/app/services/confirm-dialog-serviece';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {
  searchValue: string;
  showProgressBar: boolean = true;
  //ELEMENT_DATA: Category[];
  dataSource = new MatTableDataSource();
  //editData = new EventEmitter();
  data: Category = {
    ID: null,
    DisplayOrder: null,
    IsActive: false,
    Name: '',
    ParentCategoryID: null
  };
  constructor(private _categoryService: CategoryService, private router: Router, 
    private categoryCreate: CategoryCreateComponent, private confilmDeleteDialogServiece: ConfilmDeleteDialogServiece){}

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  ngAfterViewInit(){
    //console.log("hello");
    this.dataSource.paginator = this.paginator;
  }
  ngOnInit() {
    this._categoryService.getAllCategory().subscribe(data=> {
      this.dataSource.data = data;
      this.showProgressBar = false;
    });
    //console.log(this.ELEMENT_DATA);
  }
  filterData(){
    this.dataSource.filter = this.searchValue.trim().toLowerCase();
  }  
  onEdit(row){
    //console.log(row);
    //this.editData.emit(this.data);
    this.router.navigate(["/admin/manage/category/edit/"], row.id);
  }
  onDelete(id){
    //console.log(id);
    this.confilmDeleteDialogServiece.confilmDeleteDialog()
    .afterClosed().subscribe(data => this.deleteCategory(data, id));
  }
  deleteCategory(data, id){
    if(data){
      this._categoryService.deleteCategoryById(id).subscribe((data)=>{
        this._categoryService.getAllCategory().subscribe(data=> this.dataSource.data = data);
      });
    }
  }
  editData = new BehaviorSubject(this.data);
  currentData = this.editData.asObservable();
  displayedColumns: string[] = ['Name', 'ParentCategoryID', 'DisplayOrder', 'IsActive', 'Action'];
}
