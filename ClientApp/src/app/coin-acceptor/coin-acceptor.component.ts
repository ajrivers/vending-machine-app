import { Component, OnInit, Inject } from '@angular/core';
import { ICoinBudget, CoinBudget } from './coin-budget';
import { IOperationResult, OperationResult } from './operation-result';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { getBaseUrl } from '../../main';
import { catchError } from 'rxjs/operators';
import { SelectedProductService } from '../product-chamber/selected-product.service';

@Component({
  selector: 'app-coin-acceptor',
  templateUrl: './coin-acceptor.component.html',
  styleUrls: ['./coin-acceptor.component.css']
})
export class CoinAcceptorComponent implements OnInit {

  //#region Attributes

  currentCredit: number = 0.0;
  coinsInserted: ICoinBudget[] = [];
  operationResult: IOperationResult;
  baseUrl: string;

  //#endregion

  //#region Constructor

  constructor(private _http: HttpClient, private _selectedProductService: SelectedProductService, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  //#endregion

  //#region Methods

  public addCredit(insertedValue: number): void {
    var coinBudget = this.coinsInserted.find(c => c.value == insertedValue);
    if (coinBudget == null) {
      coinBudget = new CoinBudget();
      coinBudget.value = insertedValue;
      coinBudget.amount = 1;

      this.coinsInserted.push(coinBudget);
    }
    else
      coinBudget.amount += 1;

    this.currentCredit += insertedValue;
  }

  public returnCredit(): void {
    this.resetCredit();
  }

  public confirmCredit(): void {
    this.operationResult = new OperationResult();
    this.operationResult.message = "";
    var selectedProduct = this._selectedProductService.getSelected();

    if (selectedProduct != undefined) {
      this.callVendingMachine(selectedProduct).subscribe(
        result => {
          this.operationResult = result;
          if (this.operationResult.success) {
            this.resetCredit();
          }
        }
      );
    }
    else {
      this.operationResult.success = false;
      this.operationResult.message = this.operationResult.message.concat("You must select one product.");
    }
  }

  public retrieveProduct(): void {
    this.resetCredit();
    this.operationResult = undefined;
  }

  private callVendingMachine(selectedProduct: number): Observable<IOperationResult> {
    this.operationResult.coinsReturned = [];
    var order = {
      coins: this.coinsInserted,
      productId: selectedProduct,
      credit: this.currentCredit
    };
    return this._http.post<OperationResult>(this.baseUrl + 'api/VendingMachine/SellProduct', order)
      .pipe(
        catchError(this.handleError)
      );
  }

  private resetCredit(): void {
    this.currentCredit = 0.0;
    this.coinsInserted = [];
  }

  ngOnInit() {
  }

  //#endregion

  //#region Private Functions

  private handleError(err) {
    console.log(err.message); // Maybe it should be better using a logging framework for this.
    return Observable.throw(err.message);
  }

  //#endregion

}
