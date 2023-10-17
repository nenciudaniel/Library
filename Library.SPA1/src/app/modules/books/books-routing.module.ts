import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

//components
import { BooksComponent } from './components/books-list/books-list.component';
import { AppLayoutComponent } from 'src/app/core/layouts/app-layout/app-layout.component';

//components

const routes: Routes = [
  {
    path: '',
    component: AppLayoutComponent,
    children: [
      { 
        path: '', 
        component: BooksComponent 
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class BooksRoutingModule { }
