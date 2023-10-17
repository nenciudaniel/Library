import { NgModule } from '@angular/core';

import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon'
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatListModule } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu'
import { MatSelectModule } from '@angular/material/select';
import { MatPaginatorIntl, MatPaginatorModule } from '@angular/material/paginator';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatTabsModule } from '@angular/material/tabs';
import { MatExpansionModule } from '@angular/material/expansion';
import { CustomMatPaginatorIntl } from '../custom-paginator-configuration';

@NgModule({
    imports: [
        MatCardModule,
        MatIconModule,
        MatFormFieldModule,
        MatToolbarModule,
        MatButtonModule,
        MatInputModule,
        MatDialogModule, 
        MatCheckboxModule,
        MatListModule,
        MatMenuModule,
        MatSelectModule,
        MatPaginatorModule,
        MatDatepickerModule,
        MatNativeDateModule,
        MatTabsModule,
        MatExpansionModule
    ],
    exports:[
        MatCardModule,
        MatIconModule,
        MatFormFieldModule,
        MatToolbarModule,
        MatButtonModule,
        MatInputModule,
        MatDialogModule,
        MatCheckboxModule,
        MatListModule,
        MatMenuModule,
        MatSelectModule,
        MatPaginatorModule,
        MatDatepickerModule,
        MatNativeDateModule,
        MatTabsModule,
        MatExpansionModule
    ],
    providers: [
        { provide: MatPaginatorIntl, useClass: CustomMatPaginatorIntl }
      ]
  })
  
  export class MaterialModule { }