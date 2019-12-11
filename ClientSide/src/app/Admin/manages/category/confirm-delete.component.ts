import { Component, OnInit } from '@angular/core';
import { MatDialogRef} from '@angular/material';

@Component({
  selector: 'app-confirm-delete',
  templateUrl: './confirm-delete.component.html',
  styleUrls: ['./confirm-delete.component.css']
})
export class ConfirmDeleteComponent implements OnInit {

  constructor(private dialog: MatDialogRef<ConfirmDeleteComponent>) { }

  ngOnInit() {
  }

  public dismiss() {
    this.dialog.close(false);
  }
}
