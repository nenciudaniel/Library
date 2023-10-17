import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ConfirmationType } from '../../enums';
import { ConfirmationDialogData } from '../../models';

@Component({
  selector: 'confirmation-dialog',
  templateUrl: './confirmation-dialog.component.html',
  styleUrls: ['./confirmation-dialog.component.css']
})

export class ConfirmationDialogComponent {
  constructor(
    private dialogRef: MatDialogRef<ConfirmationDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: ConfirmationDialogData) {}

  onConfirmClick() {
    this.dialogRef.close(true);
  }

  getIconClass(): string{
    switch (this.data?.confirmationType){
      case ConfirmationType.INFO:
        return 'medium-blue-color';
      
      case ConfirmationType.DANGER:
        return 'red-color';
      
      case ConfirmationType.WARNING:
        return 'amber-color';
    }

    return "";
  }

  getSubmitButtonClass(): string{
    switch (this.data?.confirmationType){
      case ConfirmationType.INFO:
        return 'btn-medium-blue';
      
      case ConfirmationType.DANGER:
        return 'btn-red';
      
      case ConfirmationType.WARNING:
        return 'btn-amber';
    }

    return "";
  }
}
