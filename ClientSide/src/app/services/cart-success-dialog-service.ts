import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material';
import { CartSuccessfullDialogComponent } from '../store/cart/cart-successfull-dialog/cart-successfull-dialog.component';

@Injectable()
export class CartSuccessfullDialogService{

    constructor(private matDialog: MatDialog){
    }
    cartSuccessfullDialog(){
        return this.matDialog.open(CartSuccessfullDialogComponent,{
            width: '400px',
            disableClose: true
        })
    }
}