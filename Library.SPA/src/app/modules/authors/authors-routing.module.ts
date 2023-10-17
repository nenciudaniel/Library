import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

//components
import { AppLayoutComponent } from 'src/app/core/layouts/app-layout/app-layout.component';
import { AuthorsListComponent } from './authors-list/authors-list.component';

//components

const routes: Routes = [
  {
    path: '',
    component: AppLayoutComponent,
    children: [
      { 
        path: '', 
        component: AuthorsListComponent 
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class AuthorsRoutingModule { }
