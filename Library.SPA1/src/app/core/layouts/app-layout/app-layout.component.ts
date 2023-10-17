import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-layout',
  templateUrl: './app-layout.component.html'
})

export class AppLayoutComponent {
  constructor(private _translateService: TranslateService){}

  changeLanguage(lang: string){
    console.log(lang);
    this._translateService.use(lang);
  }
}
