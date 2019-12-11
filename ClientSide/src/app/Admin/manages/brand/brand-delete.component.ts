import { Component, OnInit } from '@angular/core';
import { MatDialogRef} from '@angular/material';

@Component({
  selector: 'app-brand-delete',
  templateUrl: './brand-delete.component.html',
  styleUrls: ['./brand-delete.component.css']
})

export class BrandDeleteComponent implements OnInit {

  constructor(private dialog: MatDialogRef<BrandDeleteComponent>) { }

  ngOnInit() {
  }

  public dismiss() {
    this.dialog.close(false);
  }
}
