import { Component, OnInit } from '@angular/core';
import { ICoinBudget, CoinBudget } from './coin-budget';

@Component({
  selector: 'app-coin-acceptor',
  templateUrl: './coin-acceptor.component.html',
  styleUrls: ['./coin-acceptor.component.css']
})
export class CoinAcceptorComponent implements OnInit {

  //#region Attributes

  currentCredit: number = 0.0;
  coinsInserted: ICoinBudget[] = [];

  //#endregion

  //#region Constructor

  constructor() { }

  //#endregion

  //#region Methods

  addCredit(insertedValue: number): void {
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

  resetCredit(): void {
    this.coinsInserted = [];
    this.currentCredit = 0.0;
  }

  confirmCredit(): ICoinBudget[] {

  }

  ngOnInit() {
  }

  //#endregion

}
