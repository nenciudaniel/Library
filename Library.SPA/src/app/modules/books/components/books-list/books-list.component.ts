import { Component, OnInit } from '@angular/core';
import { Filters, GridResult } from 'src/app/core/models';
import { BookService } from '../../services/book.service';
import { PageEvent } from '@angular/material/paginator';
import { AlertService } from 'src/app/core/services/alert.service';
import { AlertType } from 'src/app/core/enums';
import { MatDialog } from '@angular/material/dialog';
import { BookDetailsDialogComponent } from '../book-details-dialog/book-details-dialog.component';
import { AuthorDialogComponent } from '../author-dialog/author-dialog.component';
import { CommonService } from 'src/app/core/services/common.service';

@Component({
  selector: 'books-list',
  templateUrl: './books-list.component.html'
})

export class BooksComponent implements OnInit {
  books: GridResult;
  filters: Filters = { PageSize: 6, CurrentPage: 0 };

  timeout: any = null;
  
  constructor(
    private _alertService: AlertService,
    private _bookService: BookService,
    private _commonService: CommonService,
    public _dialogService: MatDialog){}

  ngOnInit(){
    this._commonService.changeTitle("books.title");

    this.getBooks();
  }

  onSearchChange(event: any) {
    clearTimeout(this.timeout);

    this.filters.SearchText = event.target.value;
    let $this = this;

    //add timeout to wait for user input before making the request to server
    this.timeout = setTimeout(function () {
      if (event.keyCode != 13) {
        $this.getBooks();
      }
    }, 500);
  }

  handlePageEvent(event: PageEvent) {
    this.filters.CurrentPage = event.pageIndex;
    this.getBooks();
  }

  getBooks(){
    this._bookService.filter(this.filters).subscribe(result => {
      this.books = result;
    })
  }

  onBookChanged($event: any){
    if($event.action === 'add'){
      this._alertService.show(AlertType.Success, 'books.messages.add');
    }

    if($event.action === 'author_add'){
      this._alertService.show(AlertType.Success, 'books.messages.add');
    }

    if($event.action === 'edit'){
      this._alertService.show(AlertType.Success, 'books.messages.update');
    }

    if($event.action === 'delete'){
      this._alertService.show(AlertType.Success, 'books.messages.delete');
    }

    //reload list of books
    this.getBooks();
  }

  showAddBookDialog(){
    const dialogRef = this._dialogService.open(BookDetailsDialogComponent, {
      width: '700px',
      disableClose: true,
      data: {
        bookId: null
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result !== undefined && result.action !== undefined) {
        this.onBookChanged(result);
      }
    });
  }

  showAddAuthorDialog(){
    const dialogRef = this._dialogService.open(AuthorDialogComponent, {
      width: '500px',
      disableClose: true
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result !== undefined && result.action !== undefined) {
        this.onBookChanged(result);
      }
    });
  }
}
