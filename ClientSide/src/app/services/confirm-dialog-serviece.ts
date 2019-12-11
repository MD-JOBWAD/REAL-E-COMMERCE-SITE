import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material';
import { ConfirmDeleteComponent } from '../admin/manages/category/confirm-delete.component';

@Injectable()
export class ConfilmDeleteDialogServiece{

    constructor(private matDialog: MatDialog){
    }
    confilmDeleteDialog(){
        return this.matDialog.open(ConfirmDeleteComponent,{
            width: '400px',
            disableClose: true
        })
    }
}