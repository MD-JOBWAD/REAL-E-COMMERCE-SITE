import { Component, OnInit } from '@angular/core';
import { MatDialogRef} from '@angular/material';
@Component({
  selector: 'app-color-delete',
  templateUrl: './color-delete.component.html',
  styleUrls: ['./color-delete.component.css']
})
export class ColorDeleteComponent implements OnInit {
  constructor(private dialog: MatDialogRef<ColorDeleteComponent>) { }

  ngOnInit() {
  }

  public dismiss() {
    this.dialog.close(false);
  }
}
