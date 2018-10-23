import { Component, OnInit, Input, Inject } from '@angular/core';
import { ICarouselItem } from "./carousel-item";
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Component({
  selector: 'app-carousel',
  templateUrl: './carousel.component.html',
  styleUrls: ['./carousel.component.css']
})
export class CarouselComponent implements OnInit {

  ///#region Properties

  @Input() carouselId: string;
  carouselItems: ICarouselItem[];
  baseUrl: string;
  selectedProductLineId: number;

  ///#endregion

  ///#region Constructor

  constructor(private _http: HttpClient, @Inject('BASE_URL') baseUrl: string)
  {
    this.baseUrl = baseUrl;
  }

  ///#endregion

  ///#region Methods

  public getCarouselItems(): Observable<ICarouselItem[]> {
    return this._http.get<ICarouselItem[]>(this.baseUrl + 'api/VendingMachine/GetProductLines')
      .pipe(
        catchError(this.handleError)
      );
  }

  public isActive(i: number): boolean {
    var active = this.carouselItems[i].product.productId == this.carouselItems[0].product.productId;
    return active;
  }

  private handleError(err) {
    console.log(err.message); // Maybe it should be better using a logging framework for this.
    return Observable.throw(err.message);
  }

  ngOnInit(): void {
    this.getCarouselItems().subscribe(
      items => this.carouselItems = items
    );
  }

  ///#endregion

}
