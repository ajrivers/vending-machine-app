import { IProduct } from './product';

export interface ICarouselItem {
  productLineId: number;
  amount: number;
  product: IProduct;
}
