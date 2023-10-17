import { NgModule } from '@angular/core';

//modules
import { AppLayoutModule } from 'src/app/core/layouts/layout.module';
import { BooksRoutingModule } from './books-routing.module';
import { CoreModule } from 'src/app/core/core.module';
//modules

//components
import { BookCardComponent } from './components/book-card/book-card.component';
import { BooksComponent } from './components/books-list/books-list.component';
import { BookDetailsDialogComponent } from './components/book-details-dialog/book-details-dialog.component';
import { AuthorDialogComponent } from './components/author-dialog/author-dialog.component';
//components

@NgModule({
  declarations: [
    AuthorDialogComponent,
    BookCardComponent,
    BooksComponent,
    BookDetailsDialogComponent
  ],
  imports: [
    AppLayoutModule,
    CoreModule,
    BooksRoutingModule
  ]
})

export class BooksModule { }
