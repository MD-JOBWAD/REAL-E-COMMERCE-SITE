import { Component, OnInit, ViewChild, Injectable, EventEmitter } from '@angular/core';
import { MatTableDataSource} from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { Color } from 'src/app/models/color';
import { ColorService } from 'src/app/services/color-service';
import { DataSource } from '@angular/cdk/collections';
import { BehaviorSubject } from 'rxjs';
import { Router } from '@angular/router';
import { ColorCreateComponent } from './color-create.component';
 import { ConfilmDeleteDialogServiece } from 'src/app/services/confirm-dialog-serviece';



@Component({
  selector: 'app-color-list',
  templateUrl: './color-list.component.html',
  styleUrls: ['./color-list.component.css']
})
export class ColorListComponent implements OnInit {
  searchValue: string;
    showProgressBar: boolean = true;
    dataSource = new MatTableDataSource();
    data: Color = {
      ID: null,
      Name: '',
    };
    constructor(private _colorService: ColorService, private router: Router, 
      private colorCreate: ColorCreateComponent, private confilmDeleteDialogServiece: ConfilmDeleteDialogServiece){}
  
    @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
    ngAfterViewInit(){
      this.dataSource.paginator = this.paginator;
    }
    ngOnInit() {
      this._colorService.getAllColor().subscribe(data=> {
        this.dataSource.data = data;
        this.showProgressBar = false;
      });
    }
    filterData(){
      this.dataSource.filter = this.searchValue.trim().toLowerCase();
    }  
    onEdit(row){
      this.router.navigate(["/admin/manage/color/edit/"], row.id);
    }
    onDelete(id){
      //console.log(id);
      this.confilmDeleteDialogServiece.confilmDeleteDialog()
      .afterClosed().subscribe(data => this.deleteColor(data, id));
    }
    deleteColor(data, id){
      if(data){
        this._colorService.deleteColorById(id).subscribe((data)=>{
          this._colorService.getAllColor().subscribe(data=> this.dataSource.data = data);
        });
      }
    }
    editData = new BehaviorSubject(this.data);
    currentData = this.editData.asObservable();
    displayedColumns: string[] = ['Name', 'Action'];
  }


