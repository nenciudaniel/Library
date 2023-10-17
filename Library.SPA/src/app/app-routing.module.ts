import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { 
    path: '',   
    redirectTo: '/books',
    pathMatch: 'full' 
  },
  {
    path:'books', 
    //canActivate: [AuthGuard],
    loadChildren:() => import('./modules/books/books.module').then(m => m.BooksModule)
  },
  // { 
  //   path: '**', 
  //   component: NotFoundComponent, 
  //   pathMatch: 'full' 
  // },
  // {
  //   path:'unauthorized', 
  //   component: null,
  //   children:[
  //     {
  //       path:'', 
  //       component: UnauthorizedComponent
  //     }
  //   ]
  // },
  { 
    path: '**',   
    redirectTo:'',
    pathMatch: 'full' 
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {onSameUrlNavigation: 'reload'})],
  exports: [RouterModule],
  providers:[]
})

export class AppRoutingModule { }