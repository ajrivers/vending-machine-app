import { IProduct } from './product';

export interface ICarouselItem {
  productLineId: string;
  amount: number;
  product: IProduct;
}
