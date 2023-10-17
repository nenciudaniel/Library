import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Book, ConfirmationDialogData } from 'src/app/core/models';
import { BookDetailsDialogComponent } from '../book-details-dialog/book-details-dialog.component';
import { BookService } from '../../services/book.service';
import { ConfirmationType } from 'src/app/core/enums';
import { ConfirmationDialogComponent } from 'src/app/core/components/confirmation-dialog/confirmation-dialog.component';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'book-card',
  templateUrl: './book-card.component.html',
  styleUrls: ['./book-card.component.css']
})

export class BookCardComponent {
  @Input() book: Book;
  @Output() output = new EventEmitter<{ action: string }>();

  constructor(
    private _bookService: BookService,
    public _dialogService: MatDialog,
    private _sanitizer: DomSanitizer){}

  get shortDescription(){
    return this.book.Description.substring(0, 200) + "...";
  }

  showEditBookDialog(){
    const dialogRef = this._dialogService.open(BookDetailsDialogComponent, {
      width: '700px',
      disableClose: true,
      data: {
        bookId: this.book.Id
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result !== undefined && result.action !== undefined) {
        //reset companies grid
        this.output.emit({ action : "edit" });
      }
    });
  }

  showDeleteBookDialog(){
    const dialogData: ConfirmationDialogData = {
      textTranslateKey: "books.question.delete",
      icon: "delete",
      confirmationType: ConfirmationType.DANGER
    };

    const dialogRef = this._dialogService.open(ConfirmationDialogComponent, {
      width: '350px',
      disableClose: true,
      data: dialogData
    });

    dialogRef.afterClosed().subscribe(value => {
      if (value) {
        this._bookService.delete(this.book.Id)?.subscribe((result: any) =>{
           this.output.emit({ action : "delete" });
        });
      }
    });
  }
  
  sanitizedCoverImage(coverImageContent: string){
    return this._sanitizer.bypassSecurityTrustResourceUrl('data:image/png;base64,' + coverImageContent);
  }
}
