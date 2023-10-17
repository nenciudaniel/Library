import { NgModule } from '@angular/core';

//modules
import { AppLayoutModule } from 'src/app/core/layouts/layout.module';
import { AuthorsRoutingModule } from './authors-routing.module';
import { CoreModule } from 'src/app/core/core.module';
//modules

//components
import { AuthorsListComponent } from './authors-list/authors-list.component';
//components

@NgModule({
  declarations: [
    AuthorsListComponent
  ],
  imports: [
    AppLayoutModule,
    CoreModule,
    AuthorsRoutingModule
  ]
})

export class AuthorsModule { }
