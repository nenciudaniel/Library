import { Component, OnInit} from '@angular/core';
import { AuthorService } from '../../services/author.service';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'author-dialog',
  templateUrl: './author-dialog.component.html',
  styleUrls: ['./author-dialog.component.css']
})

export class AuthorDialogComponent implements OnInit {
  form: UntypedFormGroup = null;

  constructor(
    private _authorService: AuthorService,
    public dialogRef: MatDialogRef<AuthorDialogComponent>,
    private _formBuilder: UntypedFormBuilder){}

  get fields(){
    return this.form.controls;
  }

  ngOnInit() {
    this.form = this._formBuilder.group({
      FirstName: [null, [Validators.required]],
      LastName: [null, [Validators.required]]
    });
  }

  onSubmit(){
    if(this.form.valid){
        this._authorService.add(this.form.value).subscribe(_ =>{
          this.dialogRef.close({ action: 'author_add' });
      });
    }
  }
}
