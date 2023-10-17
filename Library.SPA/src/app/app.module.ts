import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { HTTP_INTERCEPTORS, HttpClient, HttpClientModule } from '@angular/common/http';
import { TranslateHttpLoader } from "@ngx-translate/http-loader";
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { ToastrModule } from 'ngx-toastr';
import { CoreModule } from './core/core.module';
import { HttpRequestInterceptor } from './core/interceptors/http-request-interceptor';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    TranslateModule.forRoot({
      loader:{
        provide:TranslateLoader,
        useFactory: (httpClient: HttpClient) => {
          return new TranslateHttpLoader(httpClient, './assets/i18n/', '.json');
        },
        deps:[HttpClient]
      } 
    }),
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-center',
      preventDuplicates: true
    }),
    CoreModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS, 
      useClass: HttpRequestInterceptor, 
      multi: true
    },
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }
