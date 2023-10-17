import { Component, ElementRef, Inject, OnInit, ViewChild } from '@angular/core';
import { FormArray, FormControl, UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Author, Book } from 'src/app/core/models';
import { BookService } from '../../services/book.service';
import { CommonService } from 'src/app/core/services/common.service';
import { Observable, map, startWith } from 'rxjs';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { AuthorService } from '../../services/author.service';

@Component({
  selector: 'book-details-dialog',
  templateUrl: './book-details-dialog.component.html',
  styleUrls: ['./book-details-dialog.component.css']
})

export class BookDetailsDialogComponent implements OnInit {
  @ViewChild('search') searchTextBox: ElementRef;

  form: UntypedFormGroup = null;
  authors: Author[] = [];
  selectedAuthors: Author[] = [];
  searchTextboxControl = new FormControl();
  filteredOptions: Observable<any[]>;
  
  constructor(
    private _authorService: AuthorService,
    private _bookService: BookService,
    private _commonService: CommonService,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private _formBuilder: UntypedFormBuilder,
    public dialogRef: MatDialogRef<BookDetailsDialogComponent>,
    public _sanitizer: DomSanitizer){}

  get isNew(): boolean{
    return this._commonService.objectIsNull(this.data.bookId);
  }

  get authorsControl(): FormControl{
    return this.form.get("Authors") as FormControl;
  }

  get coverImageFileNameControl(): FormControl{
    return this.form.get("CoverImageFileName") as FormControl;
  }

  get coverImageContentControl(): FormControl{
    return this.form.get("CoverImageContent") as FormControl;
  }

  get fields(){
    return this.form.controls;
  }

  get sanitizedCoverImage(): SafeResourceUrl{
    if(this._commonService.objectIsNull(this.coverImageContentControl.value))
      return null;

    if(this.coverImageContentControl.value.indexOf('data:image') > -1)
      return this.coverImageContentControl.value;

    return this._sanitizer.bypassSecurityTrustResourceUrl('data:image/png;base64,' + this.coverImageContentControl.value);
  }
  
  ngOnInit() {
    this._authorService.getAllAuthors().subscribe(authors => {
      this.authors = authors;

      if(this.isNew){
        this.initFormForNewBook();
      }
      else{
        this._bookService.get(this.data.bookId).subscribe(result => {
          this.initFormForExistingBook(result);
        })
      }
  
      this.filteredOptions = this.searchTextboxControl.valueChanges
        .pipe(
          startWith<string>(''),
          map(name => this.filterAuthors(name))
        );
    })
  }

  initFormForExistingBook(book: Book){
    this.form = this._formBuilder.group({
      Id: [book.Id, [Validators.required]],
      Title: [book.Title, [Validators.required]],
      Description: [book.Description, [Validators.required]],
      Authors:[book.Authors, [Validators.required]],
      CoverImageFileName: [book.CoverImageFileName],
      CoverImageContent: [book.CoverImageContent]
    });
  }

  initFormForNewBook(){
    this.form = this._formBuilder.group({
      Title: [null, [Validators.required]],
      Description: [null, [Validators.required]],
      Authors: [null, [Validators.required]],
      CoverImageFileName: [null],
      CoverImageContent: [null]
    });
  }

  onSubmit(){
    if(this.form.valid){
      if(this.isNew){
        this._bookService.add(this.form.value).subscribe(_ =>{
          this.dialogRef.close({ action: 'add' });
        });
      }
      else{
        this._bookService.update(this.form.value).subscribe(_ => {
          this.dialogRef.close({ action: 'edit' });
        });
      }
    }
  }
 
  private filterAuthors(name: string): Author[] {
    const filterValue = name.toLowerCase();
    // Set selected values to retain the selected checkbox state 
    this.setSelectedAuthors();

    this.authorsControl.patchValue(this.selectedAuthors);
    let filteredList = this.authors.filter((option: Author) => (option.LastName.toLowerCase() + ' ' + option.FirstName.toLowerCase()).indexOf(filterValue) === 0);
    return filteredList;
  }
  
  clearSearch(event: any) {
    event.stopPropagation();
    this.searchTextboxControl.patchValue('');
  }

  openedChange(e: any) {
    this.searchTextboxControl.patchValue('');

    if (e == true) {
      this.searchTextBox.nativeElement.focus();
    }
  }

  selectionChange(event: any) {
    if (event.isUserInput && event.source.selected == false) {
      let index = this.selectedAuthors.indexOf(event.source.value);
      this.selectedAuthors.splice(index, 1)
    }
  }

  setSelectedAuthors() {
    if (this.authorsControl.value && this.authorsControl.value.length > 0) {
      this.authorsControl.value.forEach((e: Author) => {
        if (this.selectedAuthors.indexOf(e) === -1) {
          this.selectedAuthors.push(e);
        }
      });
    }
  }

  compareCategoryObjects(object1: Author, object2: Author) {
    return object1 && object2 && object1.Id === object2.Id;
  } 

  uploadFile($event: any){
    const file: File = $event.target.files[0];

    if (file) {
      var reader = new FileReader();
      reader.readAsDataURL(file); 
      reader.onload = (event) => { 
        this.coverImageContentControl.setValue(event.target.result);
        this.coverImageFileNameControl.setValue(file.name);
      }
    }
  }
}
