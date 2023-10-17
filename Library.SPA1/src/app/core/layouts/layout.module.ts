//modules
import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";

//components
import { AppLayoutComponent } from "./app-layout/app-layout.component";
import { CoreModule } from "../core.module";

@NgModule({
  declarations:[
    AppLayoutComponent
  ],
  imports: [
    RouterModule,
    CoreModule
  ],
  exports:[
    AppLayoutComponent
  ]
})

export class AppLayoutModule {}
