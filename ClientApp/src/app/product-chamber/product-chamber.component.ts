import { Component, OnInit, Input, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { IProductLine } from './product-line';
import { SelectedProductService } from './selected-product.service';

@Component({
  selector: 'app-product-chamber',
  templateUrl: './product-chamber.component.html',
  styleUrls: ['./product-chamber.component.css']
})
export class ProductChamberComponent implements OnInit {

  ///#region Properties

  productLines: IProductLine[];
  baseUrl: string;

  ///#endregion

  ///#region Constructor

  constructor(private _http: HttpClient, private _selectedProductService: SelectedProductService, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ///#endregion

  ///#region Methods

  public getProductLines(): Observable<IProductLine[]> {
    return this._http.get<IProductLine[]>(this.baseUrl + 'api/VendingMachine/GetProductLines')
      .pipe(
        catchError(this.handleError)
      );
  }

  public selectProduct(productLineId: number) {
    this._selectedProductService.setSelected(productLineId);
  }

  public isSelected(i: number): boolean {
    return this.productLines[i].productLineId == this._selectedProductService.getSelected();
  }

  private handleError(err) {
    console.log(err.message); // Maybe it should be better using a logging framework for this.
    return Observable.throw(err.message);
  }

  ngOnInit(): void {
    this.getProductLines().subscribe(
      items => this.productLines = items
    );
  }

  ///#endregion

}
