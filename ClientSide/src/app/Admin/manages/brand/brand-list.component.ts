import { Component, OnInit, ViewChild, Injectable, EventEmitter } from '@angular/core';
import { MatTableDataSource} from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { Brand } from 'src/app/models/brand';
import { BrandService } from 'src/app/services/brand-service';
import { DataSource } from '@angular/cdk/collections';
import { BehaviorSubject } from 'rxjs';
import { Router } from '@angular/router';
import { BrandCreateComponent } from './brand-create.component';
import { ConfilmDeleteDialogServiece } from 'src/app/services/confirm-dialog-serviece';


@Component({
  selector: 'app-brand-list',
  templateUrl: './brand-list.component.html',
  styleUrls: ['./brand-list.component.css']
})
export class BrandListComponent implements OnInit {

  searchValue: string;
  showProgressBar: boolean = true;
  dataSource = new MatTableDataSource();
  data: Brand = {
    ID: null,
    CategoryID: null,
    ParentBandID: null,
    BandName: '',
  };
  constructor(private _brandService: BrandService, private router: Router, 
    private brandCreate: BrandCreateComponent, private confilmDeleteDialogServiece: ConfilmDeleteDialogServiece){}

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  ngAfterViewInit(){
    this.dataSource.paginator = this.paginator;
  }
  ngOnInit() {
    this._brandService.getAllBrand().subscribe(data=> {
      this.dataSource.data = data;
      this.showProgressBar = false;
    });
  }
  filterData(){
    this.dataSource.filter = this.searchValue.trim().toLowerCase();
  }  
  onEdit(row){
    this.router.navigate(["/admin/manage/brand/edit/"], row.id);
  }
  onDelete(id){
    this.confilmDeleteDialogServiece.confilmDeleteDialog()
    .afterClosed().subscribe(data => this.deleteBrand(data, id));
  }
  deleteBrand(data, id){
    if(data){
      this._brandService.deleteBrandById(id).subscribe((data)=>{
        this._brandService.getAllBrand().subscribe(data=> this.dataSource.data = data);
      });
    }
  }
  editData = new BehaviorSubject(this.data);
  currentData = this.editData.asObservable();
  displayedColumns: string[] = [ 'CategoryID','ParentBrandID', 'BrandName',  'Action'];
}
