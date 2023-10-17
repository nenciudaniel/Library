import { DOCUMENT } from '@angular/common';
import { Inject, Injectable } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Injectable({
  providedIn: 'root'
})

export class CommonService {
    constructor(
        @Inject(DOCUMENT) private _document: HTMLDocument,
        private _translateService: TranslateService){}

    public objectIsNull(obj: any): boolean{
        return obj === null || obj === undefined;
    }

    public modelToQueryParams(obj: any): string{
        let query = '';

        for(const[k, v] of Object.entries(obj)){
            if(!this.objectIsNull(v)){
                query = query + '&' + k + '=' + v.toString();
            }
        }

        if(query.charAt(0) === '&'){
            query = '?' + query.slice(1);
        }

        return query;
    }

    changeTitle(translationKey: string){
        let element = this._document.querySelectorAll('.page-title')[0];
        element.innerHTML = this._translateService.instant(translationKey);
    }
}
