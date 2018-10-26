import { Injectable } from '@angular/core';

@Injectable()
export class SelectedProductService {

  public selectedProductLineId: number;

  constructor() { }

  public getSelected(): number {
    return this.selectedProductLineId;
  }

  public setSelected(productLineId: number) {
    this.selectedProductLineId = productLineId;
  }

}
