import { Injectable } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { AlertType } from '../enums';

@Injectable({
  providedIn: 'root'
})

export class AlertService {
   constructor(
    private _toastrService: ToastrService, 
    private _translateService: TranslateService){}

    show(alertType: string, translateKey: string){
      let message = this._translateService.instant(translateKey);

      if(alertType === AlertType.Success){
        console.log(alertType);
        this._toastrService.success(message);
      }
      else if(alertType === AlertType.Error){
        this._toastrService.error(message);
      }
      else if(alertType === AlertType.Info){
        this._toastrService.info(message);
      }
      else if(alertType === AlertType.Warning){
        this._toastrService.warning(message);
      }
    }
}
