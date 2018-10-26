import { Component, OnInit, Inject } from '@angular/core';
import { ICoinBudget, CoinBudget } from './coin-budget';
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
  coinsReturned: ICoinBudget[] = [];
  baseUrl: string;

  //#endregion

  //#region Constructor

  constructor(private _http: HttpClient, private _selectedProductService: SelectedProductService, @Inject('BASE_URL') baseUrl: string)
  {
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

  public resetCredit(): void {
    this.coinsInserted = [];
    this.currentCredit = 0.0;
  }

  public confirmCredit(): void {
    this.coinsReturned = [];
    var selectedProduct = this._selectedProductService.getSelected();
    var order = {
      coins: this.coinsInserted,
      productId: selectedProduct,
      credit: this.currentCredit
    };
    var result;
    this._http.post(this.baseUrl + 'api/VendingMachine/SellProduct', order)
      .subscribe(
        (val) => result = val
    );

    if (result != undefined) {
      this.coinsReturned = result.returnCoins;
    }
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
