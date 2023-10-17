import { Overlay, OverlayRef } from '@angular/cdk/overlay';
import { ComponentPortal } from '@angular/cdk/portal';
import { Injectable } from '@angular/core';
import { NEVER, defer } from 'rxjs';
import { finalize, share } from 'rxjs/operators';
import { SpinnerOverlayComponent } from '../components/spinner-overlay/spinner-overlay.component';

@Injectable({
  providedIn: 'root',
})

export class SpinnerOverlayService {
  private overlayRef: OverlayRef = undefined;

  constructor(private overlay: Overlay) { }

  public readonly spinner$ = defer(() => {
    //show spinner
    this.show();

    return NEVER.pipe(
      finalize(() => {
        //hide spinner
        this.hide();
      })
    );
  }).pipe(share());

  public show(): void {
    Promise.resolve(null).then(() => {
      this.overlayRef = this.overlay.create({
        positionStrategy: this.overlay
          .position()
          .global()
          .centerHorizontally()
          .centerVertically(),
        hasBackdrop: true
      });

      this.overlayRef.attach(new ComponentPortal(SpinnerOverlayComponent));
    });
  }

  public hide(): void {
    this.overlayRef.detach();
    this.overlayRef = undefined;
  }
}
