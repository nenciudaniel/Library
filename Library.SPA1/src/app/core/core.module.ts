import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';
import { MaterialModule } from './modules/material.module';

//components
import { ConfirmationDialogComponent } from './components/confirmation-dialog/confirmation-dialog.component';


@NgModule({
  declarations: [
    ConfirmationDialogComponent
  ],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    MaterialModule,
    TranslateModule
  ],
  exports:[
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    MaterialModule,
    TranslateModule,

    ConfirmationDialogComponent
  ]
})

export class CoreModule { }
