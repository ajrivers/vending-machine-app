import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { CarouselComponent } from './carousel/carousel.component';
import { CoinAcceptorComponent } from './coin-acceptor/coin-acceptor.component';
import { ProductChamberComponent } from './product-chamber/product-chamber.component';
import { SelectedProductService } from './product-chamber/selected-product.service';

@NgModule({
  declarations: [
    AppComponent,
    CarouselComponent,
    CoinAcceptorComponent,
    ProductChamberComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule
  ],
  providers: [SelectedProductService],
  bootstrap: [AppComponent]
})
export class AppModule { }
